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
    public partial class formRelProduto : MaterialSkin.Controls.MaterialForm
        {
        public formRelProduto()
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
            }

        private void formRelProduto_Load(object sender, EventArgs e)
        {
            // 1. CARREGAR COMBO DE OPÇÕES DE CONSULTA DE PRODUTOS
            cbTipoRel.Items.Add("Marca");
            cbTipoRel.Items.Add("Categoria");
            cbTipoRel.Items.Add("Marca e Categoria");
            cbTipoRel.Items.Add("Faixa de Preço");
            cbTipoRel.Items.Add("Estoque");
            cbTipoRel.Items.Add("Promoção");
            cbTipoRel.Items.Add("Status");

            // Define ""Status"" como o filtro padrão inicial
            cbTipoRel.SelectedValue = "Status";

            // ==============================================================
            // CARREGAR AS COMBO BOXES DE FILTROS COM DADOS DO BANCO
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
            this.rptvProduto.LocalReport.EnableExternalImages = true;//liberar imagens externas
            this.rptvProduto.RefreshReport();
        }

        private void DesabilitarTodosFiltros()
        {
            // Desliga todos os GroupBoxes de filtro
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
            string filtro = cbTipoRel.SelectedItem.ToString();

            switch (filtro)
            {
                
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

        private void btSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o relatório de Produtos???", "IOT Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btGerarRelatorio_Click(object sender, EventArgs e)
        {
            classProduto cProduto = new classProduto();
            //VARIAVEL PARA ALIMENTAR O SWITCH
            string relatorio = cbTipoRel.SelectedItem.ToString();

            switch (relatorio)
            {
                //DATA DE CADASTRO
                case "Data de Cadastro":
                    //VOLTAR PARA VALIDAR DATA INCIAL MENOR QUE DATA FINAL
                    classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoDataCadastro(Convert.ToDateTime(dtpDataInicial.Text), Convert.ToDateTime(dtpDataFinal.Text));
                    //REFRESH NO FORMS
                    this.rptvProduto.RefreshReport();
                    break;

                //STATUS
                case "Status":
                    //INATIVO
                    if (rbInativo.Checked)
                    {
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoStatus(0);
                    }
                    else
                    {
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoStatus(1);
                    }
                    //REFRESH NO FORMS
                    this.rptvProduto.RefreshReport();
                    break;

                //CATEGORIA
                case "Categoria":
                    // Envia o código (SelectedValue) da categoria selecionada
                    classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoCategoria(Convert.ToInt32(cbCategoria.SelectedValue));
                    this.rptvProduto.RefreshReport();
                    break;

                //MARCA
                case "Marca":
                    // Envia o código (SelectedValue) da marca selecionada
                    classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoMarca(Convert.ToInt32(cbMarca.SelectedValue));
                    this.rptvProduto.RefreshReport();
                    break;

                //MARCA E CATEGORIA
                case "Marca e Categoria":
                    // Envia os dois códigos para o filtro duplo
                    classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoMarcaCategoria(Convert.ToInt32(cbMarca.SelectedValue), Convert.ToInt32(cbCategoria.SelectedValue));
                    this.rptvProduto.RefreshReport();
                    break;

                //FAIXA DE PREÇO
                case "Faixa de Preço":
                    // Segue a lógica do seu txtPrecoMin e busca o valor até o limite estipulado
                    classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoFaixaPreco(Convert.ToDecimal(txtPrecoMin.Text), Convert.ToDecimal(txtPrecoMax.Text));
                    this.rptvProduto.RefreshReport();
                    break;

                //ESTOQUE
                case "Estoque":
                    string statusEstoque = "";

                    // Verifica qual RadioButton foi selecionado
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

                    // Envia a palavra definida pelo RadioButton para o seu método RelatorioProdutoEstoqueStatus
                    classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoEstoqueStatus(statusEstoque);
                    this.rptvProduto.RefreshReport();
                    break;

                //PROMOÇÃO
                case "Promoção":
                    // Segue a mesma lógica do status (0 ou 1) utilizando os radio buttons do groupBox2
                    if (rbPromoAtivo.Checked)
                    {
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoPromocao(1);
                    }
                    else
                    {
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoPromocao(0);
                    }
                    this.rptvProduto.RefreshReport();
                    break;
            }


        
        }

       
    }
}
