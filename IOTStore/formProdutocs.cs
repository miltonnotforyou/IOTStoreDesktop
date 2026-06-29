using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace IOTStore
{
    public partial class formProdutocs : MaterialSkin.Controls.MaterialForm
    {
        public formProdutocs()
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

        //CRIAR VARIAVEIS QUE SERÃO UTILIZADAS NO FORM DE CONSULTA
        //TIPO - MANEIRA QUE O FORM SERÁ ABERTO
        // OUTRAS VARIAVEIS - EXIBIR OS DADOS QUE ESTÃO ARMAZENADOS NO BD E NÃO OS DECLARADOS NO LOAD DO FORM
        public string tipo;
        public DateTime data_cadastro;
        public int codigo_marca_selecionada = 0;       
        public int codigo_categoria_selecionada = 0;   

        // Coloque aqui o caminho real da pasta de fotos do seu servidor Web!
        // Lembre-se de colocar as duas barras \\ no final do caminho.
        public string pastaFotosWeb = @"C:\xampp\htdocs\INFO_52\IOT_Store\images\\";

        private void formProdutocs_Load(object sender, EventArgs e)
        {
            // Define o padrão da ComboBox de promoção como "Não" ao abrir a tela
            cBStatusPromocao.Text = "Não";

            // 1. PRIMEIRO CARREGA O BANCO DE DADOS NAS COMBOBOXES
            classCategoria cCategoria = new classCategoria();
            cbCategoria.DataSource = cCategoria.BuscarCategoriaProduto();
            cbCategoria.DisplayMember = "nome";
            cbCategoria.ValueMember = "codigo_categoria";

            classMarca cMarca = new classMarca();
            cBMarca.DataSource = cMarca.BuscarMarcaProduto();
            cBMarca.DisplayMember = "nome";
            cBMarca.ValueMember = "codigo_marca";

            // 2. VERIFICA SE É ATUALIZAÇÃO OU NOVO CADASTRO
            if (tipo == "Atualizacao")
            {
                // Se for atualização (veio da tela de consulta)
                btCadastrarProduto.Enabled = false;
                btAtualizarProduto.Enabled = true;
                btExcluirProduto.Enabled = true;
                // DESTRAVA A CAIXA DE STATUS PARA PERMITIR INATIVAR O PRODUTO
                checkBoxStatus.Enabled = true;

                // Puxa as opções corretas usando as variáveis que recebemos da consulta
                cbCategoria.SelectedValue = codigo_categoria_selecionada;
                cBMarca.SelectedValue = codigo_marca_selecionada;
            }
            else
            {
                // MODO CADASTRO (Produto em branco)
                btCadastrarProduto.Enabled = true;
                btAtualizarProduto.Enabled = false;
                btExcluirProduto.Enabled = false;

                // Limpa as comboboxes (deixa em branco) APENAS se for um cadastro novo
                cbCategoria.SelectedIndex = -1;
                cBMarca.SelectedIndex = -1;
            }

        }

        private void btSairProduto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // MÉTODO PARA PINTAR OS CAMPOS OBRIGATÓRIOS
        private void CamposObrigatorios()
        {
            txtNomeProduto.BackColor = Color.Aquamarine;
            txtPrecoCusto.BackColor = Color.Aquamarine;
            maskedVenda.BackColor = Color.Aquamarine;
            txtQuantidade.BackColor = Color.Aquamarine;
        }

        // MÉTODO PARA LIMPAR OS CAMPOS APÓS O CADASTRO
        private void Limpar()
        {
            txtNomeProduto.Clear();
            txtPrecoCusto.Clear();
            txtLucro.Clear();
            maskedVenda.Clear();
            txtQuantidade.Clear();
            txtDesconto.Clear();
            maskedPrecoPromocao.Clear();

            cbCategoria.SelectedIndex = -1;
            cBMarca.SelectedIndex = -1;
            cBStatusPromocao.Text = "Não";

            if (fotoProduto.Image != null)
            {
                fotoProduto.Image = null;
                fotoProduto.Tag = null;
            }

            // Devolver a cor original escura aos campos
            txtNomeProduto.BackColor = Color.FromArgb(43, 61, 79);
            txtPrecoCusto.BackColor = Color.FromArgb(43, 61, 79);
            maskedVenda.BackColor = Color.FromArgb(43, 61, 79);
            txtQuantidade.BackColor = Color.FromArgb(43, 61, 79);

            txtNomeProduto.Focus();
        }

        // BOTÃO CADASTRAR PRODUTO
        private void btCadastrarProduto_Click(object sender, EventArgs e)
        {
            classProduto cProduto = new classProduto();

            if (string.IsNullOrWhiteSpace(txtNomeProduto.Text) ||
                string.IsNullOrWhiteSpace(txtPrecoCusto.Text) ||
                string.IsNullOrWhiteSpace(txtLucro.Text) ||
                string.IsNullOrWhiteSpace(maskedVenda.Text) ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                cbCategoria.SelectedIndex == -1 ||
                cBMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Favor verificar todos os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios();
            }
            else
            {
                cProduto.nome = txtNomeProduto.Text;
                cProduto.descricao = txtDescrição.Text;
                cProduto.qtde_estoque = Convert.ToInt32(txtQuantidade.Text);
                cProduto.preco_custo = Convert.ToDecimal(txtPrecoCusto.Text);
                cProduto.lucro = txtLucro.Text;
                cProduto.preco_venda = Convert.ToDecimal(maskedVenda.Text);

                // LÓGICA DE PROMOÇÃO BASEADA NA COMBOBOX
                if (cBStatusPromocao.Text == "Sim" && !string.IsNullOrWhiteSpace(maskedPrecoPromocao.Text))
                {
                    cProduto.status_promocao = true;
                    cProduto.preco_promocao = Convert.ToDecimal(maskedPrecoPromocao.Text);

                    if (!string.IsNullOrWhiteSpace(txtDesconto.Text))
                        cProduto.desconto_promocao = Convert.ToDecimal(txtDesconto.Text);
                    else
                        cProduto.desconto_promocao = 0;
                }
                else
                {
                    cProduto.status_promocao = false;
                    cProduto.preco_promocao = 0;
                    cProduto.desconto_promocao = 0;
                }

                if (fotoProduto.Tag != null)
                {
                    cProduto.foto = fotoProduto.Tag.ToString();
                }
                else
                {
                    cProduto.foto = "";
                }

                cProduto.codigo_marca = Convert.ToInt32(cBMarca.SelectedValue);
                cProduto.codigo_categoria = Convert.ToInt32(cbCategoria.SelectedValue);

                int resp = cProduto.CadastrarProduto();

                if (resp == 1)
                {
                    MessageBox.Show($"Produto '{cProduto.nome}' cadastrado com sucesso!", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar o produto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // BOTÃO ATUALIZAR PRODUTO
        private void btAtualizarProduto_Click(object sender, EventArgs e)
        {
            classProduto cProduto = new classProduto();

            // 1. Validar se os campos obrigatórios estão preenchidos (igual ao cadastro)
            if (string.IsNullOrWhiteSpace(txtNomeProduto.Text) ||
                string.IsNullOrWhiteSpace(txtPrecoCusto.Text) ||
                string.IsNullOrWhiteSpace(txtLucro.Text) ||
                string.IsNullOrWhiteSpace(maskedVenda.Text) ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                cbCategoria.SelectedIndex == -1 ||
                cBMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Favor verificar todos os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios();
                return; // Interrompe a execução aqui se faltar algo
            }

            // 2. Passar os dados da tela para as propriedades da classe
            // ATENÇÃO: O código do produto é OBRIGATÓRIO para o UPDATE funcionar!
            cProduto.codigo_produto = Convert.ToInt32(txtCodigoProduto.Text);

            cProduto.nome = txtNomeProduto.Text;
            cProduto.descricao = txtDescrição.Text;
            cProduto.qtde_estoque = Convert.ToInt32(txtQuantidade.Text);
            cProduto.preco_custo = Convert.ToDecimal(txtPrecoCusto.Text);
            cProduto.lucro = txtLucro.Text;
            cProduto.preco_venda = Convert.ToDecimal(maskedVenda.Text);

            // Ler o status (Ativo = 1, Inativo = 0)
            cProduto.status = checkBoxStatus.Checked ? 1 : 0;

            // LÓGICA DE PROMOÇÃO
            if (cBStatusPromocao.Text == "Sim" && !string.IsNullOrWhiteSpace(maskedPrecoPromocao.Text))
            {
                cProduto.status_promocao = true;
                cProduto.preco_promocao = Convert.ToDecimal(maskedPrecoPromocao.Text);
                cProduto.desconto_promocao = string.IsNullOrWhiteSpace(txtDesconto.Text) ? 0 : Convert.ToDecimal(txtDesconto.Text);
            }
            else
            {
                cProduto.status_promocao = false;
                cProduto.preco_promocao = 0;
                cProduto.desconto_promocao = 0;
            }

            // FOTO
            if (fotoProduto.Tag != null)
            {
                cProduto.foto = fotoProduto.Tag.ToString();
            }
            else
            {
                cProduto.foto = "";
            }

            // CHAVES ESTRANGEIRAS
            cProduto.codigo_marca = Convert.ToInt32(cBMarca.SelectedValue);
            cProduto.codigo_categoria = Convert.ToInt32(cbCategoria.SelectedValue);

            // 3. Chamar o método de atualização
            int resp = cProduto.CorrigirEAtualizarProduto();

            if (resp == 1)
            {
                MessageBox.Show($"Produto '{cProduto.nome}' atualizado com sucesso!", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha o formulário e volta para a tela de consulta
            }
            else
            {
                MessageBox.Show("Erro ao atualizar o produto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÃO EXCLUIR PRODUTO
        private void btExcluirProduto_Click(object sender, EventArgs e)
        {
            // Pergunta de segurança antes de deletar do banco
            if (MessageBox.Show("Tem certeza que deseja excluir este produto permanentemente?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                classProduto cProduto = new classProduto();

                // Passa o código que está na tela para a propriedade da classe
                cProduto.codigo_produto = Convert.ToInt32(txtCodigoProduto.Text);

                // Chama o método que executa o DELETE no banco de dados
                int resp = cProduto.ExcluirProduto();

                if (resp == 1)
                {
                    MessageBox.Show("Produto excluído com sucesso!", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha o formulário para a grade na tela de trás atualizar sozinha
                }
                else
                {
                    MessageBox.Show("Erro ao excluir o produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ====================================================================
        // MÉTODOS DE CÁLCULO AUTOMÁTICO E TRAVAS
        // ====================================================================

        // 1. MÉTODO: CALCULAR O PREÇO DE VENDA AUTOMATICAMENTE
        private void CalcularPrecoVenda(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrecoCusto.Text, out decimal custo) && decimal.TryParse(txtLucro.Text, out decimal lucro))
            {
                decimal venda = custo + (custo * (lucro / 100));
                maskedVenda.Text = venda.ToString("N2");

                CalcularPrecoPromocao(null, null);
            }
            else
            {
                maskedVenda.Text = "";
            }
        }

        // 2. MÉTODO: CALCULAR O PREÇO PROMOCIONAL AUTOMATICAMENTE
        private void CalcularPrecoPromocao(object sender, EventArgs e)
        {
            
            if (cBStatusPromocao.Text == "Sim" && decimal.TryParse(maskedVenda.Text, out decimal venda) && decimal.TryParse(txtDesconto.Text, out decimal desconto))
            {
                decimal promo = venda - (venda * (desconto / 100));
                maskedPrecoPromocao.Text = promo.ToString("N2");
            }
            else
            {
                maskedPrecoPromocao.Text = "";
            }
        }

        // 3. MÉTODO: HABILITAR OU DESABILITAR CAMPOS PELA COMBOBOX
        private void cBStatusPromocao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBStatusPromocao.Text == "Sim")
            {
                txtDesconto.Enabled = true;
                maskedPrecoPromocao.Enabled = true;
                txtDesconto.Focus();
            }
            else
            {
                txtDesconto.Enabled = false;
                maskedPrecoPromocao.Enabled = false;
                txtDesconto.Clear();
                maskedPrecoPromocao.Clear();
            }
        }

        private void btFotoProduto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecionar Foto do Produto";
            ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivo = System.IO.Path.GetFileName(ofd.FileName);
                string caminhoDestino = pastaFotosWeb + nomeArquivo;

                try
                {
                    // 1. Cria a pasta do XAMPP caso ela não exista
                    if (!System.IO.Directory.Exists(pastaFotosWeb))
                    {
                        System.IO.Directory.CreateDirectory(pastaFotosWeb);
                    }

                    // 2. SOLTA A FOTO ANTIGA: Se tiver alguma foto na tela, apaga ela da memória primeiro
                    if (fotoProduto.Image != null)
                    {
                        fotoProduto.Image.Dispose();
                        fotoProduto.Image = null;
                    }

                    // 3. Agora sim copia o arquivo sem que o Windows bloqueie!
                    System.IO.File.Copy(ofd.FileName, caminhoDestino, true);

                    // 4. Carrega a foto nova usando o truque do Clone de Memória
                    using (Image imgNova = Image.FromFile(caminhoDestino))
                    {
                        fotoProduto.Image = new Bitmap(imgNova);
                    }

                    fotoProduto.SizeMode = PictureBoxSizeMode.Zoom;
                    fotoProduto.Tag = nomeArquivo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao processar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}