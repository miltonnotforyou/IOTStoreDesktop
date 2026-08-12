using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;               // ← adicionar
using MaterialSkin.Controls;      // ← adicionar

namespace IOTStore
{
    public partial class formConsultaProduto : MaterialSkin.Controls.MaterialForm
    {
        public formConsultaProduto()
        {
            InitializeComponent();
            // Inicializa e aplica o tema
            var skinManager = MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false; // Como vimos, mude para false se quiser personalizar os painéis
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
            Primary.Indigo500,     // Cor principal (exatamente a da sua imagem)
            Primary.Indigo700,     // Tom mais escuro para abas/sombras (RGB: 48; 63; 159)
            Primary.Indigo300,     // Tom mais claro
            Accent.Pink200,        // Cor de destaque (Rosa costuma combinar muito bem com Indigo)
            TextShade.WHITE        // Texto branco

                );
        }

        private void formConsultaProduto_Load(object sender, EventArgs e)
        {
            // 1. CARREGAR COMBO DE OPÇÕES DE CONSULTA DE PRODUTOS
            cbOpcoes.Items.Add("Nome");
            cbOpcoes.Items.Add("Código");
            cbOpcoes.Items.Add("Categoria");
            cbOpcoes.Items.Add("Marca");
            cbOpcoes.Items.Add("Marca e Categoria");
            cbOpcoes.Items.Add("Faixa de Preço");
            cbOpcoes.Items.Add("Estoque");
            cbOpcoes.Items.Add("Promoção");
            cbOpcoes.Items.Add("Status");

            // Define "Nome" como o filtro padrão inicial
            cbOpcoes.SelectedIndex = 0;

            // ==============================================================
            // CARREGAR AS COMBOBOXES DE FILTROS COM DADOS DO BANCO
            // ==============================================================

            try
            {
                // 2. CARREGAR COMBO CATEGORIA
                classCategoria cCategoria = new classCategoria();
                cbCategoria.DataSource = cCategoria.BuscarCategoriaProduto();
                cbCategoria.DisplayMember = "nome";                 // Exibe o nome da categoria
                cbCategoria.ValueMember = "codigo_categoria";       // Guarda o ID oculto da categoria
                cbCategoria.SelectedIndex = -1;                     // Inicia em branco

                // 3. CARREGAR COMBO MARCA
                classMarca cMarca = new classMarca();
                cbMarca.DataSource = cMarca.BuscarMarcaProduto();
                cbMarca.DisplayMember = "nome";                     // Exibe o nome da marca
                cbMarca.ValueMember = "codigo_marca";               // Guarda o ID oculto da marca
                cbMarca.SelectedIndex = -1;                         // Inicia em branco
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os filtros do banco de dados: " + ex.Message,
                                "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            classProduto cProduto = new classProduto();

            //CRIAR VARIAVEL PARA ALIMENTAR O SWITCH
            string filtro = cbOpcoes.SelectedItem.ToString();

            switch (filtro)
            {
                // CÓDIGO
                case "Código":
                    if (int.TryParse(codigoProduto.Text, out int codigo))
                    {
                        dgvProduto.DataSource = cProduto.ConsultaProdutoCodigo(codigo);
                    }
                    else
                    {
                        MessageBox.Show("Favor informar um código numérico válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        codigoProduto.Focus();
                    }
                    break;

                // CATEGORIA
                case "Categoria":
                    if (cbCategoria.SelectedIndex != -1)
                    {
                        dgvProduto.DataSource = cProduto.ConsultaProdutoCategoria(Convert.ToInt32(cbCategoria.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar uma Categoria!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                // MARCA
                case "Marca":
                    if (cbMarca.SelectedIndex != -1)
                    {
                        dgvProduto.DataSource = cProduto.ConsultaProdutoMarca(Convert.ToInt32(cbMarca.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar uma Marca!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                // FAIXA DE PREÇO
                case "Faixa de Preço":
                    if (decimal.TryParse(txtPrecoMin.Text, out decimal min) && decimal.TryParse(txtPrecoMax.Text, out decimal max))
                    {
                        if (min <= max)
                        {
                            dgvProduto.DataSource = cProduto.ConsultaProdutoFaixaPreco(min, max);
                        }
                        else
                        {
                            MessageBox.Show("O preço mínimo não pode ser maior que o preço máximo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPrecoMin.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Favor digitar apenas números válidos nos campos de preço!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                // ESTOQUE
                case "Estoque":

                    string statusEstoque = "";

                    // Verifica qual RadioButton está marcado dentro do GroupBox
                    
                    if (rbNormal.Checked)
                    {
                        statusEstoque = "Normal";
                    }
                    else if (rbBaixo.Checked)
                    {
                        statusEstoque = "Baixo";
                    }
                    else if (rbZero.Checked)
                    {
                        statusEstoque = "Zero";
                    }

                    // Se alguma opção foi escolhida, faz a pesquisa
                    if (statusEstoque != "")
                    {
                        dgvProduto.DataSource = cProduto.ConsultaProdutoEstoqueStatus(statusEstoque);
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar uma opção de estoque (Normal, Baixo ou Zero)!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    break;

                // STATUS
                case "Status":
                    //INATIVO
                    if (rbInativo.Checked)
                    {
                        dgvProduto.DataSource = cProduto.ConsultaProdutoStatus(0);
                    }
                    else
                    {
                        dgvProduto.DataSource = cProduto.ConsultaProdutoStatus(1);
                    }
                    break;

                // PROMOÇÃO
                case "Promoção":
                    // Verifica qual RadioButton está marcado
                    if (rbPromoAtivo.Checked)
                    {
                        // 1 = Sim, está em promoção
                        dgvProduto.DataSource = cProduto.ConsultaProdutoPromocao(1);
                    }
                    else
                    {
                        // 0 = Não está em promoção
                        dgvProduto.DataSource = cProduto.ConsultaProdutoPromocao(0);
                    }
                    break;

                // MARCA E CATEGORIA JUNTAS
                case "Marca e Categoria":
                    // Verifica se o usuário realmente selecionou os dois antes de pesquisar
                    if (cbMarca.SelectedIndex != -1 && cbCategoria.SelectedIndex != -1)
                    {
                        // Passa os dois valores ocultos (ValueMember) para o banco de dados
                        dgvProduto.DataSource = cProduto.ConsultaProdutoMarcaCategoria(
                            Convert.ToInt32(cbMarca.SelectedValue),
                            Convert.ToInt32(cbCategoria.SelectedValue)
                        );
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar uma Marca e uma Categoria para realizar esta pesquisa!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                // NOME
                default:
                    //VERIFICAR SE O USUSARIO PREENCHEU O NOME
                    if (String.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        MessageBox.Show("Favor informar um nome!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gbNome.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        //VERIFICAR TIPO DE PESQUISA ESQCOLHIDA
                        //PESQUISA POR INICIO
                        if (rbInicio.Checked)
                        {
                            dgvProduto.DataSource = cProduto.ConsultaProdutoNomeInicio(txtNome.Text);
                        }
                        else
                        {
                            dgvProduto.DataSource = cProduto.ConsultaProdutoNomeContem(txtNome.Text);
                        }
                    }
                    break;

            }//FECHAMENTO DO SWITCH NÃO APAGAR

            FormatarGrid();
        }


        private void FormatarGrid()
        {
            // 1. Renomear os cabeçalhos (se a coluna existir no grid)
            if (dgvProduto.Columns.Contains("codigo_produto"))
                dgvProduto.Columns["codigo_produto"].HeaderText = "Código";

            if (dgvProduto.Columns.Contains("nome"))
                dgvProduto.Columns["nome"].HeaderText = "Nome do Produto";

            if (dgvProduto.Columns.Contains("descricao"))
                dgvProduto.Columns["descricao"].HeaderText = "Descrição";

            if (dgvProduto.Columns.Contains("status"))
                dgvProduto.Columns["status"].HeaderText = "Status";

            if (dgvProduto.Columns.Contains("data_cadastro"))
                dgvProduto.Columns["data_cadastro"].HeaderText = "Data Cadastro";

            // 2. Estilizar o cabeçalho (Cor, Fonte e Alinhamento)
            // OBRIGATÓRIO: Desativar os estilos visuais do Windows para a cor de fundo funcionar
            dgvProduto.EnableHeadersVisualStyles = false;

            // Cor de fundo do cabeçalho (usando a mesma cor azul escuro do seu form)
            dgvProduto.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);

            // Cor da letra
            dgvProduto.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Deixar a letra em Negrito e mudar a fonte
            dgvProduto.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);

            // Centralizar o texto do cabeçalho
            dgvProduto.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ====================================================================
            // ESTILIZAR AS LINHAS (REMOVER A LINHA BRANCA)
            // ====================================================================

            // Define a cor de fundo escuro e a fonte branca como padrão para todas as linhas
            dgvProduto.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvProduto.DefaultCellStyle.ForeColor = Color.White;

            // Define a MESMA cor de fundo para as linhas alternadas (removendo o zebrado)
            dgvProduto.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvProduto.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Cor da linha ao selecionar
            dgvProduto.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvProduto.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //CLICAR NO GRID DO CLIENTE E EDITAR OU EXCLUIR UM CLIENTE
            //USAR O EVENTO CELLCLICK (PODE CLICAR EM QUALQUER LUGAR DA CÉLULA, NÃO SOMENTE NO TEXTO)
            //USANDO O EVENTO CELLCONTENTCLICK (TEM QUE CLICAR NO CONTEÚDO (TEXTO))

            // PERGUNTAR PARA USUARIO SE REALMENTE DESEJA ALTERAR O PRODUTO SELECIONADO
            if (MessageBox.Show("Deseja alterar ou excluir o produto selecionado?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // INSTANCIAR A CLASSE PRODUTO
                classProduto cProduto = new classProduto();

                // INSTANCIAR O FORMULARIO DE CADASTRO DE PRODUTO (NOME CORRETO)
                formProdutocs fProduto = new formProdutocs();

                // PEGAR O PRODUTO ESCOLHIDO PELO USUARIO ATRAVES DA SELEÇÃO NA GRID
                cProduto.DadosProduto(Convert.ToInt32(dgvProduto.SelectedRows[0].Cells[0].Value));

                // PASSAR OS DADOS DO BANCO (cProduto) PARA OS ELEMENTOS DO FORM (fProduto)
                fProduto.txtCodigoProduto.Text = cProduto.codigo_produto.ToString();
                fProduto.txtNomeProduto.Text = cProduto.nome.ToString();
                fProduto.txtDescrição.Text = cProduto.descricao.ToString();
                fProduto.txtQuantidade.Text = cProduto.qtde_estoque.ToString();
                fProduto.txtPrecoCusto.Text = cProduto.preco_custo.ToString();
                fProduto.txtLucro.Text = cProduto.lucro.ToString();
                fProduto.maskedVenda.Text = cProduto.preco_venda.ToString();

                // STATUS DE PROMOÇÃO
                if (cProduto.status_promocao)
                {
                    fProduto.cBStatusPromocao.Text = "Sim";
                    fProduto.txtDesconto.Text = cProduto.desconto_promocao.ToString();
                    fProduto.maskedPrecoPromocao.Text = cProduto.preco_promocao.ToString();
                }
                else
                {
                    fProduto.cBStatusPromocao.Text = "Não";
                }

                // CARREGAR COMBOBOXES (Se necessário, você precisará forçar a seleção do ValueMember)
                fProduto.codigo_categoria_selecionada = cProduto.codigo_categoria;
                fProduto.codigo_marca_selecionada = cProduto.codigo_marca;

                // STATUS ATIVO/INATIVO
                if (cProduto.status == 1)
                {
                    fProduto.checkBoxStatus.Checked = true;
                }
                else
                {
                    fProduto.checkBoxStatus.Checked = false;
                }

                //CARREGAR A FOTO DO BD E EXIBIR NO PICTUREBOX
                if (!string.IsNullOrEmpty(cProduto.foto))
                {
                    try
                    {
                        string pastaFotosWeb = @"C:\xampp\htdocs\INFO_52\IOT_Store\images\\";
                        string caminhoCompleto = pastaFotosWeb + cProduto.foto;

                        // O TRUQUE DO CLONE DE MEMÓRIA:
                        // Abre a foto original, faz uma cópia na memória e fecha a original (using)
                        using (Image imgOriginal = Image.FromFile(caminhoCompleto))
                        {
                            fProduto.fotoProduto.Image = new Bitmap(imgOriginal);
                        }

                        fProduto.fotoProduto.SizeMode = PictureBoxSizeMode.Zoom;
                        fProduto.fotoProduto.Tag = cProduto.foto;
                    }
                    catch (Exception)
                    {
                        fProduto.fotoProduto.Image = null;
                        fProduto.fotoProduto.Tag = cProduto.foto;
                    }
                }
                else
                {
                    fProduto.fotoProduto.Image = null;
                    fProduto.fotoProduto.Tag = null;
                }

                // CAMPO DE DATA CORRIGIDO
                fProduto.txtDataCadastroProduto.Text = cProduto.data_cadastro.ToString("dd/MM/yyyy");

                // DEFINIR TIPO COMO ATUALIZAÇÃO (Para você tratar a lógica dos botões no formProdutocs)
                fProduto.tipo = "Atualizacao";

                // CHAMAR O FORM DE CADASTRO
                fProduto.ShowDialog();

                // ATUALIZAR A GRID DE COSULTA
                btPesquisar_Click(this, new EventArgs());
        }   }

        private void DesabilitarTodosFiltros()
        {
            // Desliga todos os GroupBoxes de filtro
            gbNome.Enabled = false;
            gbTipoPesquisa.Enabled = false;
            gbCódigo.Enabled = false;
            gbCategoria.Enabled = false;
            gbMarca.Enabled = false;
            gbPreço.Enabled = false;
            gbEstoque.Enabled = false;
            groupBox2.Enabled = false; // Este é o GroupBox de Promoção
            gbStatus.Enabled = false;
        }

        private void cbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1.Apaga tudo para evitar que filtros antigos fiquem abertos
            DesabilitarTodosFiltros();

            // 2. Verifica a opção pelo texto (mais seguro que o índice numérico)
            string filtro = cbOpcoes.SelectedItem.ToString();

            switch (filtro)
            {
                case "Nome":
                    gbNome.Enabled = true;
                    gbTipoPesquisa.Enabled = true;
                    txtNome.Focus(); // Coloca o cursor piscando direto na caixa de texto
                    break;

                case "Código":
                    gbCódigo.Enabled = true;
                    codigoProduto.Focus();
                    break;

                case "Categoria":
                    gbCategoria.Enabled = true;
                    break;

                case "Marca":
                    gbMarca.Enabled = true;
                    break;

                case "Marca e Categoria":
                    gbMarca.Enabled = true;
                    gbCategoria.Enabled = true;
                    break;

                case "Faixa de Preço":
                    gbPreço.Enabled = true;
                    txtPrecoMin.Focus();
                    break;

                case "Estoque":
                    gbEstoque.Enabled = true;
                    break;

                case "Promoção":
                    groupBox2.Enabled = true;
                    break;

                case "Status":
                    gbStatus.Enabled = true;
                    break;
            }
        }
    }
}
