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
    public partial class formRelCliente : MaterialSkin.Controls.MaterialForm
    {
        public formRelCliente()
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

        private void formRelCliente_Load(object sender, EventArgs e)
        {
            //CARREGAR COMBO TIPO DE RELATÓRIO
            cbTipoRel.Items.Add("Aniversariantes do Mês");
            cbTipoRel.Items.Add("Cidade");
            cbTipoRel.Items.Add("Data de cadastro");
            cbTipoRel.Items.Add("Idade");
            cbTipoRel.Items.Add("Sexo");
            cbTipoRel.Items.Add("Status");
            cbTipoRel.SelectedIndex = 0;

            //CARREGAR COMBO MÊS
            cbMes.Items.Add("Escolha um Mês");
            cbMes.Items.Add("Janeiro");
            cbMes.Items.Add("Fevereiro");
            cbMes.Items.Add("Março");
            cbMes.Items.Add("Abril");
            cbMes.Items.Add("Maio");
            cbMes.Items.Add("Junho");
            cbMes.Items.Add("Julho");
            cbMes.Items.Add("Agosto");
            cbMes.Items.Add("Setembro");
            cbMes.Items.Add("Outubro");
            cbMes.Items.Add("Novembro");
            cbMes.Items.Add("Dezembro");
            cbMes.SelectedIndex = 0;

            //CARREGAR COMBO SEXO
            cbSexo.Items.Add("Escolha um Sexo");
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Não Informado");
            cbSexo.SelectedIndex = 0;

            //CARREGAR COMBO CIDADE

            //CRIAR OBJETO DA CLASSE CARGO PARA USAR O METODO QUE VAI CARREGAR A COMBO
            classCliente cCliente = new classCliente();

            //CHAMAR O METODO QUE CARREGA AS INFORMAÇÕES NA COMBO CARGO
            cbCidade.DataSource = cCliente.BuscarCidadeCliente();

            //O QUE SERA EXIBIDO NA COMBO - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbCidade.DisplayMember = "cidade";

            //O QUE SERA ARMAZENADO NO BANCO DE DADOS - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbCidade.ValueMember = "cidade";

            this.rptvCliente.RefreshReport();
        }

        private void cbTipoRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoRel.SelectedIndex == 0)//Aniversariantes do Mês
            {
                gbAniversariantes.Enabled = true;
                gbIdade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbStatus.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
            }



            if (cbTipoRel.SelectedIndex == 1)//Cidade
            {
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbStatus.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = true;
            }

            if (cbTipoRel.SelectedIndex == 2)//Data de cadastro
            {
                gbAniversariantes.Enabled = false;
                gbDataAdmissao.Enabled = true;
                gbStatus.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
            }
            if (cbTipoRel.SelectedIndex == 3)//Idade
            {
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = true;
                gbDataAdmissao.Enabled = false;
                gbStatus.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 4)//Sexo
            {
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbStatus.Enabled = false;
                gbSexo.Enabled = true;
                gbCidade.Enabled = false;
            }
            if (cbTipoRel.SelectedIndex == 5)//Status
            {
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbStatus.Enabled = true;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
            }

            this.rptvCliente.RefreshReport();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o relatório de Clientes???", "IOT Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btGerarRelatorio_Click(object sender, EventArgs e)
        {
            classCliente cCliente = new classCliente();
            //VARIAVEL PARA ALIMENTAR O SWTCH
            string relatorio = cbTipoRel.SelectedItem.ToString();

            switch (relatorio)
            {
                case "Idade":

                    if (string.IsNullOrWhiteSpace(txtIdadeInicial.Text) && string.IsNullOrWhiteSpace(txtIdadeFinal.Text))
                    {
                        MessageBox.Show("FAvor informar idade incial e idade final Válidas!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gbIdade.BackColor = Color.AliceBlue;
                        txtIdadeInicial.Focus();
                    }
                    else
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteIdada(Convert.ToInt32(txtIdadeInicial.Text), Convert.ToInt32(txtIdadeFinal.Text));

                        //REFRESH NO FORMS
                        this.rptvCliente.RefreshReport();

                    }
                    break;



                case "Cidade":

                    classClienteBindingSource.DataSource = cCliente.RelatorioClienteCidade(Convert.ToString(cbCidade.SelectedValue));

                    //REFRESH NO FORMS
                    this.rptvCliente.RefreshReport();

                    break;

                //SEXO
                case "Sexo":
                    //FEMININO
                    if (cbSexo.SelectedItem.ToString() == "Feminino")
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteSexo("F");
                    }
                    //FEMININO
                    else if (cbSexo.SelectedItem.ToString() == "Masculino")
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteSexo("M");
                    }
                    //NÃO INFORMADO
                    else
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteSexo("O");
                    }

                    //REFRESH NO FORMS
                    this.rptvCliente.RefreshReport();

                    break;

                //DATA DE CADASTRO
                case "Data de cadastro":
                    //VOLTAR PARA VALIDAR DATA INCIAL MENOR QUE DATA FINAL

                    classClienteBindingSource.DataSource = cCliente.RelatorioClienteDataCadastro(Convert.ToDateTime(dtpDataInicial.Text), Convert.ToDateTime(dtpDataFinal.Text));
                    //REFRESH NO FORMS
                    this.rptvCliente.RefreshReport();

                    break;

                //STATUS
                case "Status":
                    //INATIVO
                    if (rbInativo.Checked)
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteStatus(0);
                    }
                    else
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteStatus(1);
                    }
                    //REFRESH NO FORMS
                    this.rptvCliente.RefreshReport();

                    break;



                //ANIVERSARIANTES DO MÊS (default)
                default:
                    //VERIFICAR SE O USUARIO ESCOLHEU UM MÊS VALIDO
                    if (cbMes.SelectedIndex == 0)
                    {
                        MessageBox.Show("FAvor escolher um mês Válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gbAniversariantes.BackColor = Color.AliceBlue;

                    }
                    else
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteNiverMes(cbMes.SelectedIndex);
                        //REFRESH NO FORMS
                        this.rptvCliente.RefreshReport();
                    }


                    break;


            }
        }
    }
}
