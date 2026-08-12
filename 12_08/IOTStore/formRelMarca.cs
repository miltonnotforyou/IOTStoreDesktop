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
    public partial class formRelMarca : MaterialSkin.Controls.MaterialForm
    {
        public formRelMarca()
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

        private void formRelMarca_Load(object sender, EventArgs e)
        {
            //CARREGAR COMBO TIPO DE RELATÓRIO
            cbTipoRel.Items.Add("Data de Cadastro");
            cbTipoRel.Items.Add("Status");
            cbTipoRel.SelectedIndex = 1;

            this.rptvMarca.RefreshReport();
            
        }

        private void cbTipoRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoRel.SelectedIndex == 0)//Data cadastro
            {
                dtpDataInicial.Enabled = true;
                dtpDataFinal.Enabled = true;
                rbAtivo.Enabled = false;
                rbInativo.Enabled = false;
            }
            else if (cbTipoRel.SelectedIndex == 1)//Status
            {
                dtpDataInicial.Enabled = false;
                dtpDataFinal.Enabled = false;
                rbAtivo.Enabled = true;
                rbInativo.Enabled = true;
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            classMarca cMarca = new classMarca();
            //VARIAVEL PARA ALIMENTAR O SWTCH
            string relatorio = cbTipoRel.SelectedItem.ToString();

            switch (relatorio)
            {

                //DATA DE CADASTRO
                case "Data de Cadastro":
                    //VOLTAR PARA VALIDAR DATA INCIAL MENOR QUE DATA FINAL

                    classMarcaBindingSource.DataSource = cMarca.RelatorioMarcaDataCadastro(Convert.ToDateTime(dtpDataInicial.Text), Convert.ToDateTime(dtpDataFinal.Text));
                    //REFRESH NO FORMS
                    this.rptvMarca.RefreshReport();

                    break;

                //STATUS
                default:
                case "Status":
                    //INATIVO
                    if (rbInativo.Checked)
                    {
                        classMarcaBindingSource.DataSource = cMarca.RelatorioMarcaStatus(0);
                    }
                    else
                    {
                        classMarcaBindingSource.DataSource = cMarca.RelatorioMarcaStatus(1);
                    }
                    //REFRESH NO FORMS
                    this.rptvMarca.RefreshReport();

                    break;

            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o relatório de Marcas???", "IOT Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
