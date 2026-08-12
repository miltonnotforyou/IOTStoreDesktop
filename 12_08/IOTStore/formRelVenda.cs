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
    public partial class formRelVenda : MaterialSkin.Controls.MaterialForm
    {
        public formRelVenda()
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

        private void formRelVenda_Load(object sender, EventArgs e)
        {
            //CARREGAR COMBO TIPO DE RELATÓRIO
            cbTipoRel.Items.Add("Vendas por Período");
            cbTipoRel.Items.Add("Vendas por Cliente");
            cbTipoRel.Items.Add("Vendas por Funcionário");
            cbTipoRel.Items.Add("Vendas por Período e Cliente");
            cbTipoRel.Items.Add("Vendas por Período e Funcionário");
            cbTipoRel.SelectedIndex = 0;

            //CARREGAR FUNCIONÁRIO - ALIMENTADA PELA TABELA FUNCIONARIO
            classFuncionario cfuncionario = new classFuncionario();
            cbFuncionario.DataSource = cfuncionario.BuscarFuncionario();
            cbFuncionario.DisplayMember = "nome";
            cbFuncionario.ValueMember = "codigo_funcionario";
            cbFuncionario.SelectedIndex = -1;

            //CARREGAR Cliente - ALIMENTADA PELA TABELA Cliente
            classCliente cCliente = new classCliente();
            cbCliente.DataSource = cCliente.BuscarCliente();
            cbCliente.DisplayMember = "nome";
            cbCliente.ValueMember = "codigo_Cliente";
            cbCliente.SelectedIndex = -1;

           this.rptvVenda.RefreshReport();
        }

        private void btGerarRelatorio_Click(object sender, EventArgs e)
        {
            classRelVenda cRelVenda = new classRelVenda();

            int tipo_rel = Convert.ToInt32(cbTipoRel.SelectedIndex);

            switch (tipo_rel)
            {

                //Cliente
                case 1:
                    // Envia o código (SelectedValue) da Cliente selecionada
                    classRelVendaBindingSource.DataSource = cRelVenda.RelatorioVendaCliente(Convert.ToInt32(cbCliente.SelectedValue));
                    this.rptvVenda.RefreshReport();
                    break;

                //Funcionário
                case 2:
                    // Envia o código (SelectedValue) da Funcionário selecionada
                    classRelVendaBindingSource.DataSource = cRelVenda.RelatorioVendaFuncionario(Convert.ToInt32(cbFuncionario.SelectedValue));
                    this.rptvVenda.RefreshReport();
                    break;

                //Período e Cliente
                case 3:

                    // 1. Pegue o código do cliente da sua tela 
                    int codigoCliente = Convert.ToInt32(cbCliente.SelectedValue);
                    // 2. Chame o método passando os 3 parâmetros e usando a propriedade .Value dos campos de data
                    classRelVendaBindingSource.DataSource = cRelVenda.RelatorioVendaDataCliente(dtpDataInicial.Value, dtpDataFinal.Value, codigoCliente);
                    rptvVenda.RefreshReport();
                    break;

                //Período e Funcionario
                case 4:

                    // 1. Peguar o código do cliente da sua tela 
                    int codigoFuncionario = Convert.ToInt32(cbFuncionario.SelectedValue);
                    // 2. Chamar o método passando os 3 parâmetros e usando a propriedade .Value dos campos de data
                    classRelVendaBindingSource.DataSource = cRelVenda.RelatorioVendaDataFuncionario(dtpDataInicial.Value, dtpDataFinal.Value, codigoFuncionario);
                    rptvVenda.RefreshReport();
                    break;


                //PERÍODO
                default:
                    classRelVendaBindingSource.DataSource = cRelVenda.RelatorioVendaData(Convert.ToDateTime(dtpDataInicial.Text), Convert.ToDateTime(dtpDataFinal.Text));
                    rptvVenda.RefreshReport();


                    break;
            }
        }

        private void cbTipoRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoRel.SelectedIndex == 0)//Data Venda
            {
                gbDataVenda.Enabled = true;
                gbCliente.Enabled = false;
                gbFuncionario.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 1)//cliente
            {
                gbDataVenda.Enabled = false;
                gbCliente.Enabled = true;
                gbFuncionario.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 2)//Funcionario
            {
                gbDataVenda.Enabled = false;
                gbCliente.Enabled = false;
                gbFuncionario.Enabled = true;
            }

            if (cbTipoRel.SelectedIndex == 3)//Período e Cliente
            {
                gbDataVenda.Enabled = true;
                gbCliente.Enabled = true;
                gbFuncionario.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 4)//Período e funcionario
            {
                gbDataVenda.Enabled = true;
                gbCliente.Enabled = false;
                gbFuncionario.Enabled = true;
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o Relatório de Vendas?", "Sistema IOT Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
