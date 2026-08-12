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
    public partial class formVenda52 : MaterialSkin.Controls.MaterialForm
    {
        public formVenda52()
        {
            InitializeComponent();
            // Inicializa o tema
            var skinManager = MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK; // ou LIGHT
            skinManager.ColorScheme = new ColorScheme(
            Primary.Indigo500,     // Cor principal (exatamente a da sua imagem)
            Primary.Indigo700,     // Tom mais escuro para abas/sombras (RGB: 48; 63; 159)
            Primary.Indigo300,     // Tom mais claro
            Accent.Pink200,        // Cor de destaque (Rosa costuma combinar muito bem com Indigo)
            TextShade.WHITE        // Texto branco

            );
            EstilizarGrids(dgvCliente, dgvProduto, dgvItens);
        }

        //CRIAR A LISTA QUE SERÁ USADA NA GRID DE PRODUTOS VENDIDOS QUE TERÁ COMO BASE A CLASSE DE ITENSVENDA
        //CARRINHO
        private List<classItensVenda> ListaItensVEnda = new List<classItensVenda>();

        //VARIAVEL PARA CALCULAR VALOR TOTAL DA VENDA
        private decimal VendaTotal = 0;


        private void formVenda52_Load(object sender, EventArgs e)
        {
            //CARREGAR DATA DA VENDA
            txtDataVenda.Text = DateTime.Now.ToShortDateString();

            //COMBO FORMA DE PAGAMENTO
            cbFormaPagamento.Items.Add("Cartão de Crédito");
            cbFormaPagamento.Items.Add("Cartão de Débito");
            cbFormaPagamento.Items.Add("Dinheiro");
            cbFormaPagamento.Items.Add("Pix");
            cbFormaPagamento.SelectedIndex = 3;

            // CARREGAR COMBO funcionario

            //CRIAR OBJETO DA CLASSE CARGO PARA USAR O METODO QUE VAI CARREGAR A COMBO
            classFuncionario cFuncionario = new classFuncionario();

            //CHAMAR O METODO QUE CARREGA AS INFORMAÇÕES NA COMBO funcionario
            cbFuncionario.DataSource = cFuncionario.BuscarFuncionario();

            //O QUE SERA EXIBIDO NA COMBO - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbFuncionario.DisplayMember = "nome";

            //O QUE SERA ARMAZENADO NO BANCO DE DADOS - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbFuncionario.ValueMember = "codigo_funcionario";


            // CARREGAR cliente

            //CRIAR OBJETO DA CLASSE CARGO PARA USAR O METODO QUE VAI CARREGAR grid
            classCliente cCliente = new classCliente();
                        

        }



        private void btBuscaCliente_Click(object sender, EventArgs e)
        {
            //VERIFICAR SE O USUSARIO PREENCHEU O NOME
            if (String.IsNullOrWhiteSpace(txtPesqCliente.Text))
            {
                MessageBox.Show("Favor informar um nome!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gbClientes.BackColor = Color.AliceBlue;
            }
            else
            {
                classCliente cCliente = new classCliente();
                dgvCliente.DataSource = cCliente.CarregarGridCliente(txtPesqCliente.Text);
            }
        }

        private void btBuscaProduto_Click(object sender, EventArgs e)
        {
            //VERIFICAR SE O USUSARIO PREENCHEU O NOME
            if (String.IsNullOrWhiteSpace(txtPesqProduto.Text))
            {
                MessageBox.Show("Favor informar um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gbClientes.BackColor = Color.AliceBlue;
            }
            else
            {
                classProduto cProduto = new classProduto();
                dgvProduto.DataSource = cProduto.CarregarGridProduto(txtPesqProduto.Text);
            }
        }


        private void EstilizarGrids(params DataGridView[] grids)
        {
            foreach (DataGridView grid in grids)
            {

                grid.BackgroundColor = Color.White;
                grid.BorderStyle = BorderStyle.None;
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Estilizar o cabeçalho (Cor, Fonte e Alinhamento)
                // OBRIGATÓRIO: Desativar os estilos visuais do Windows para a cor de fundo funcionar
                grid.EnableHeadersVisualStyles = false;

                // Cor de fundo do cabeçalho (usando a mesma cor azul escuro do seu form)
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);

                // Cor da letra
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                // Deixar a letra em Negrito e mudar a fonte
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);

                // Centralizar o texto do cabeçalho
                grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // ====================================================================
                // ESTILIZAR AS LINHAS (REMOVER A LINHA BRANCA)
                // ====================================================================

                // Define a cor de fundo escuro e a fonte branca como padrão para todas as linhas
                grid.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
                grid.DefaultCellStyle.ForeColor = Color.White;

                // Define a MESMA cor de fundo para as linhas alternadas (removendo o zebrado)
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
                grid.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

                // Cor da linha ao selecionar
                grid.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                grid.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private void txtQtde_TextChanged(object sender, EventArgs e)
        {
            //VERIFICAR SE O CAMPO NÃO ESTÁ VAZIO OU NULO

            if (string.IsNullOrWhiteSpace(txtQtde.Text) || txtQtde.Text == "0")
            {
                MessageBox.Show("Favor informar uma quantidade", "Sistema IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQtde.Text = "01";
                txtQtde.SelectAll();
            }

            int qtdeVendida = Convert.ToInt32(txtQtde.Text);
            int qtdeEstoque = Convert.ToInt32(txtQtdeEstoque.Text);

            //VERIFICAR SE A QUANTIDADE VENDIDA NÃO É MAIOR QUE A QUANTIDADE EM ESTOQUE

            if (qtdeVendida > qtdeEstoque)
            {
                MessageBox.Show("A quantidade disponível no estoque é de " + qtdeEstoque + " unidades!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQtde.Text = "01";
                txtQtde.SelectAll();
            }

            else
            {
                qtdeVendida = Convert.ToInt32(txtQtde.Text);
                decimal valor = Convert.ToDecimal(txtValor.Text);
                txtTotal.Text = (qtdeVendida * valor).ToString();

            }
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            classProduto cProduto = new classProduto();

            bool resp = cProduto.DadosProduto(Convert.ToInt32(dgvProduto.SelectedRows[0].Cells[0].Value));

            if (resp == true)
            {
                txtProduto.Text = cProduto.nome;
                txtQtdeEstoque.Text = cProduto.qtde_estoque.ToString();
                txtValor.Text = cProduto.preco_venda.ToString("n2");
                txtQtde.Text = "01";
                txtQtde_TextChanged(this, new EventArgs());
                txtQtde.SelectAll();
            }
        }

        //MÉTODO QUE SERÁ USADO PELA GRID DE VENDA COM OS PRODUTOS VENDIDOS
        private void AtualizarGrid()
        {
            //INSTANCIAR CLASSE PRODUTO PARA PEGAR MÉTODO QUE TRAZ O NOME DO PRODUTO
            classProduto cProduto = new classProduto();

            //CRIAR UMA TABELA TEMPORARIA
            DataTable dt = new DataTable();

            //CRIAR AS COLUNAS DA GRID
            dt.Columns.Add(new DataColumn("Código"));
            dt.Columns.Add(new DataColumn("Produto"));
            dt.Columns.Add(new DataColumn("Quantidade"));
            dt.Columns.Add(new DataColumn("Valor Unitário"));
            dt.Columns.Add(new DataColumn("Valor Total"));

            //ADICIONAR AS LINHAS DA GRID 
            foreach (classItensVenda item in ListaItensVEnda)
            {
                dt.Rows.Add(item.codigo_produto, cProduto.BuscaNomeProd(item.codigo_produto), item.qtde_item, item.valor_item, item.valor_total_item);
                dt.AcceptChanges();
            }
            dgvItens.DataSource = dt;

        }

        //MÉTODO PARA CALCULAR O DESCONTO NA VENDA

        private void CalcularDescontoTotalVenda()
        {
            decimal valorVenda = 0;
            decimal percentualDesconto = 0;

            decimal.TryParse(txtValorTotal.Text, out valorVenda);
            decimal.TryParse(txtPercentualDesconto.Text, out percentualDesconto);

            if (percentualDesconto < 0)
            {
                percentualDesconto = 0;
            }

            decimal valorDesconto = valorVenda * percentualDesconto / 100;
            decimal totalVenda = valorVenda - valorDesconto;

            txtTotalDesconto.Text = valorDesconto.ToString("N2");
            txtTotalVenda.Text = totalVenda.ToString("N2");

        }


        private void btFechaVenda_Click(object sender, EventArgs e)
        {
            if (cbFuncionario.SelectedIndex != -1 && dgvCliente.DataSource != null && dgvItens.DataSource != null)
            {
                classVenda cVenda = new classVenda();

                //MANDAR INFORMAÇÕES PARA TABElA VENDA
                cVenda.valor_total = Convert.ToDecimal(txtTotalVenda.Text);
                cVenda.desconto = Convert.ToDecimal(txtTotalDesconto.Text);
                cVenda.forma_pagamento = cbFormaPagamento.SelectedItem.ToString();
                cVenda.codigo_cliente = Convert.ToInt32(dgvCliente.SelectedRows[0].Cells[0].Value);
                cVenda.codigo_funcionario = Convert.ToInt32(cbFuncionario.SelectedValue);
                cVenda.observacao = Convert.ToString(txtObservacao.Text);

                //CHAMAR MÉTODO CADASTRAR VENDA
                bool resp = cVenda.CadastrarVenda();

                if(resp == true)
                {
                    foreach (classItensVenda item in ListaItensVEnda)
                    {
                        item.codigo_venda = cVenda.codigo_venda;
                        resp = item.CadastrarItemVenda();

                        //BAIXA ESTOQUE
                        CalculaEstoque(item.qtde_item, item.codigo_produto);
                    }

                    if (resp == true)
                    {
                        MessageBox.Show("Venda Realizada com Sucesso!", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpar();
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao Realizar a Venda!", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }

            }
            else
            {
                MessageBox.Show("Erro ao Realizar a Venda!", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CamposObrigatorios();
            }
        }

        private void txtPercentualDesconto_TextChanged(object sender, EventArgs e)
        {
            CalcularDescontoTotalVenda();
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTotal.Text))
            {
                MessageBox.Show("Não há produto para ser inserido", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                classItensVenda cItensVenda = new classItensVenda();

                //INFORMAÇÕES DOS PRODUTOS VENDIDOS
                cItensVenda.codigo_produto = Convert.ToInt32(dgvProduto.SelectedRows[0].Cells[0].Value);
                cItensVenda.qtde_item = Convert.ToInt32(txtQtde.Text);
                cItensVenda.valor_item = Convert.ToDecimal(txtValor.Text);
                cItensVenda.valor_total_item = Convert.ToDecimal(txtTotal.Text);

                // ADICIONA O ITEM NA LISTA
                ListaItensVEnda.Add(cItensVenda);


                //SOMAR VALOR DO ITEM SELECIONADO AO TOTAL DA VENDA
                decimal ValorItem = 0;
                ValorItem = Convert.ToDecimal(txtTotal.Text);
                VendaTotal = VendaTotal + ValorItem;
                txtValorTotal.Text = VendaTotal.ToString("N2");

                //ATUALIZA A QUANTIDADE DE ITENS
                txtQtdeItens.Text = ListaItensVEnda.Count.ToString();

                //ATUALIZA A GRID
                AtualizarGrid();

                //LIMPA CAMPOS
                txtProduto.Clear();
                txtQtde.Text = "1";
                txtValor.Clear();
                txtTotal.Clear();
                txtQtdeEstoque.Clear();

                //RECALCULA O DESCONTO DA VENDA
                CalcularDescontoTotalVenda();
                txtPercentualDesconto.Focus();


            }
        }

        //METODO LIMPAR - CHAMADO QUANDO A VENDA É FINALIZADA

        private void Limpar()
        {
            //FUNCIONARIO E CLIENTE
            cbFuncionario.SelectedIndex = -1;
            txtPesqCliente.Clear();
            dgvCliente.DataSource = null;
            txtObservacao.Clear();

            //PRODUTOS
            txtPesqProduto.Clear();
            dgvProduto.DataSource = null;

            //ITENS DA VENDA
            ListaItensVEnda.Clear();
            AtualizarGrid();

            //TOTAIS
            VendaTotal = 0;
            txtValorTotal.Text = "0,00";
            txtTotalVenda.Text = "0,00";
            txtTotalDesconto.Text = "0";
            txtQtdeItens.Text = "0";
            txtPercentualDesconto.Text = "0";

            //PAGAMENTO
            cbFormaPagamento.SelectedItem = "3";

        }

        private void CamposObrigatorios()
        {
            gbFuncionario.BackColor = Color.AliceBlue;
            gbClientes.BackColor = Color.AliceBlue;
            gbProdutos.BackColor = Color.AliceBlue;
            gbItensVenda.BackColor = Color.AliceBlue;
        }

        //METODO ATUALIZAR ESTOQUE (FAZER CONTA PARA DIMINUIR DO ESTOQUE)
        private void CalculaEstoque(int qtde, int cod)        
        {
            classProduto cProduto = new classProduto();
            cProduto.DadosProduto(cod);
            int estoque = cProduto.qtde_estoque;
            cProduto.AtualizaEstoque(estoque - qtde, cod);
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgvItens.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja Remover o Produto Selecionado?", "IOT Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //RECALCULAR TOTAL DA VENDA
                    //PEGAR O VALOR DO ITEM SELECIONADO PELO USUAIRO
                    decimal valor = Convert.ToDecimal(dgvItens.SelectedRows[0].Cells[4].Value);
                    VendaTotal = VendaTotal - valor;
                    txtTotalVenda.Text = VendaTotal.ToString();
                    txtValorTotal.Text = VendaTotal.ToString();

                    //REMOVER O ITEM SELECIONADO DA LISTA E ATUALIZAR GRID
                    ListaItensVEnda.RemoveAt(dgvItens.CurrentRow.Index);
                    AtualizarGrid();

                    //RECONTAR A LISTA DE PRODUTOS VENDIDOS
                    txtQtdeItens.Text = ListaItensVEnda.Count.ToString();
                    CalcularDescontoTotalVenda();

                }
                else
                {
                    MessageBox.Show("Não há produtos para serem removidos", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

       
    }
}
