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
    public partial class formConsultaCliente : MaterialSkin.Controls.MaterialForm
    {
        public formConsultaCliente()
        {
            InitializeComponent();
            // Inicializa e aplica o tema ao formCargo
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

        private void formConsultaCliente_Load(object sender, EventArgs e)
        {
            //CARREGAR COMBO DE OPÇÕES DE CONSULTA
            cbOpcoes.Items.Add("Nome");
            cbOpcoes.Items.Add("Cidade");
            cbOpcoes.Items.Add("CPF");
            cbOpcoes.Items.Add("Sexo");
            cbOpcoes.Items.Add("Data de Cadastro");
            cbOpcoes.Items.Add("Sexo e Cidade");
            cbOpcoes.Items.Add("Status");

            cbOpcoes.SelectedIndex = 0;

            //CARREGAR COMBO SEXO
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Não Informado");

            cbSexo.SelectedIndex = 0;

            
           //CRIAR OBJETO DA CLASSE CARGO PARA USAR O METODO QUE VAI CARREGAR A COMBO
            classCliente cCliente = new classCliente();

            //CHAMAR O METODO QUE CARREGA AS INFORMAÇÕES NA COMBO CARGO
            cbCidade.DataSource = cCliente.BuscarCidadeCliente();
            
            //O QUE SERA EXIBIDO NA COMBO - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbCidade.DisplayMember = "cidade";

            //O QUE SERA ARMAZENADO NO BANCO DE DADOS - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbCidade.ValueMember = "cidade";

        }

        private void cbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HABILITAR/DESABILITAR COMPONENTES DO FORM DE ACORDO COM A ESCOLHA DO USUARIO
            // 0 - NOME
            if (cbOpcoes.SelectedIndex == 0)
            {
                gbTipoPesquisa.Enabled = true;
                gbNome.Enabled = true;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;
                txtNome.Focus();
            }

            // 1 - CIDADE
            if (cbOpcoes.SelectedIndex == 1)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = true;
                gbDataAdmissao.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;

            }

            // 2 - CPF
            if (cbOpcoes.SelectedIndex == 2)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCPF.Enabled = true;
                gbStatus.Enabled = false;
                mskCpf.Focus();

            }

            // 3 - SEXO
            if (cbOpcoes.SelectedIndex == 3)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = true;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;

            }

            // 4 - DATA CADASTRO
            if (cbOpcoes.SelectedIndex == 4)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = true;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;

            }

            // 5 - SEXO E CIDADE
            if (cbOpcoes.SelectedIndex == 5)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = true;
                gbCidade.Enabled = true;
                gbDataAdmissao.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;

            }


            // 6- Status
            if (cbOpcoes.SelectedIndex == 6)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = true;

            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            classFuncionario cFuncionario = new classFuncionario();
            classCliente cCliente = new classCliente();

            //CRIAR VARIAVEL PARA ALIMENTAR O SWITCH

            string filtro = cbOpcoes.SelectedItem.ToString();

            switch (filtro)
            {
               
                //CIDADE
                case "Cidade":

                    dgvCliente.DataSource = cCliente.ConsultaClienteCidade(Convert.ToString(cbCidade.SelectedValue));
                    break;

                //CPF
                case "CPF":
                    //VERIFICAR SE O USUARIO DIGITOU CPF
                    if (mskCpf.Text != "   .   .   -")
                    {
                        dgvCliente.DataSource = cCliente.ConsultaClienteCpf(mskCpf.Text);
                    }
                    else
                    {
                        MessageBox.Show("Favor informar um CPF válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gbCPF.BackColor = Color.AliceBlue;
                        mskCpf.Text = "   .   .   -";
                        mskCpf.Focus();
                    }

                    break;

                //SEXO
                case "Sexo":
                    //FEMININO
                    if (cbSexo.SelectedItem.ToString() == "Feminino")
                    {
                        dgvCliente.DataSource = cCliente.ConsultaClienteSexo("F");
                    }
                    //FEMININO
                    else if (cbSexo.SelectedItem.ToString() == "Masculino")
                    {
                        dgvCliente.DataSource = cCliente.ConsultaClienteSexo("M");
                    }
                    //NÃO INFORMADO
                    else
                    {
                        dgvCliente.DataSource = cCliente.ConsultaClienteSexo("O");
                    }


                    break;
                //DATA DE ADMISSÃO
                case "Data de Cadastro":
                    //VOLTAR PARA VALIDAR DATA INCIAL MENOR QUE DATA FINAL

                    dgvCliente.DataSource = cCliente.ConsultaClienteCadastro(Convert.ToDateTime(dtpDataInicial.Text), Convert.ToDateTime(dtpDataFinal.Text));


                    break;

                //STATUS
                case "Status":
                    //INATIVO
                    if (rbInativo.Checked)
                    {
                        dgvCliente.DataSource = cCliente.ConsultaClienteStatus(0);
                    }
                    else
                    {
                        dgvCliente.DataSource = cCliente.ConsultaClienteStatus(1);
                    }


                    break;

                //SEXO E CIDADE
                case "Sexo e Cidade":

                    // Pegando a cidade selecionada no ComboBox
                    string cidadeSelecionada = cbCidade.SelectedValue.ToString();

                    //FEMININO
                    if (cbSexo.SelectedItem.ToString() == "Feminino")
                    {
                        // Passando os dois parâmetros: Sexo e Cidade
                        dgvCliente.DataSource = cCliente.ConsultaClienteSexoCidade("F", cidadeSelecionada);
                    }
                    //MASCULINO
                    else if (cbSexo.SelectedItem.ToString() == "Masculino")
                    {
                        dgvCliente.DataSource = cCliente.ConsultaClienteSexoCidade("M", cidadeSelecionada);
                    }
                    //NÃO INFORMADO
                    else
                    {
                        dgvCliente.DataSource = cCliente.ConsultaClienteSexoCidade("O", cidadeSelecionada);
                    }

                    break;


                //NOME

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
                            dgvCliente.DataSource = cCliente.ConsultaClienteNomeInicio(txtNome.Text);
                        }
                        else
                        {
                            dgvCliente.DataSource = cCliente.ConsultaClienteNomeContem(txtNome.Text);
                        }
                    }

                    break;

            }//FECHAMENTO DO SWITCH NÃO APAGAR

            FormatarGrid();



        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //CLICAR NO GRID DO CLIENTE E EDITAR OU EXCLUIR UM CLIENTE
            //USAR O EVENTO CELLCLICK (PODE CLICAR EM QUALQUER LUGAR DA CÉLULA, NÃO SOMENTE NO TEXTO)
            //USANDO O EVENTO CELLCONTENTCLICK (TEM QUE CLICAR NO CONTEÚDO (TEXTO))

            //PERGUNTAR PARA USUARIO SE REALMENTE DESEJA ALTERAR O CLIENTE SELECIONADO
            if (MessageBox.Show("Deseja alterar ou excluir o cliente selecionado?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //INTANCIAR A CLASSE CLIENTE
                classCliente cCliente = new classCliente();

                //INTANCIAR O FORMULARIO DE CADASTRO DE CLIENTE - PARA MANDAR AS INFORMAÇÕES DO BD PARA O FORM
                formCliente fCliente = new formCliente();

                //PEGAR O CLIENTE ESCOLHIDO PELO USUARIO ATRAVES DA SELEÇÃO NA GRID
                cCliente.DadosCliente(Convert.ToInt32(dgvCliente.SelectedRows[0].Cells[0].Value));

                //PASSAR OS DADOS DO BANCO PARA OS ELEMENTOS DO FORM DE CADASTRO
                fCliente.txtCodigoCliente.Text = cCliente.codigo_cliente.ToString();
                fCliente.txtNomeCliente.Text = cCliente.nome.ToString();
                fCliente.txtNomeSocial.Text = cCliente.nome_social.ToString();
                fCliente.txtNascimento.Text = cCliente.data_nascimento.ToString("dd/MM/yyyy");

                //SEXO IF PARA LER O QUE ESTÁ ARMAZENADO NO BD E DEIXAR O RADIO BUTON SELECIONADO
                if (cCliente.sexo == "F")
                {
                    fCliente.rbFeminino.Checked = true;
                }
                else if (cCliente.sexo == "M")
                {
                    fCliente.rbMasculino.Checked = true;
                }
                else
                {
                    fCliente.rbNaoInformado.Checked = true;
                }

                fCliente.maskedTextCPF.Text = cCliente.cpf.ToString();
                fCliente.txtRgCliente.Text = cCliente.rg.ToString();
                fCliente.txtEnderecoCliente.Text = cCliente.endereco.ToString();
                fCliente.txtNumeroCliente.Text = cCliente.numero.ToString();
                fCliente.txtComplementoCliente.Text = cCliente.complemento.ToString();
                fCliente.txtBairroCliente.Text = cCliente.bairro.ToString();
                fCliente.txtCidadeCliente.Text = cCliente.cidade.ToString();
                fCliente.cBEstadoCliente.Text = cCliente.estado.ToString();
                fCliente.txtCepCliente.Text = cCliente.cep.ToString();
                fCliente.maskedResidencial.Text = cCliente.telefone_residencial.ToString();
                fCliente.maskedCelular.Text = cCliente.telefone_celular.ToString();
                fCliente.txtEmailCliente.Text = cCliente.email.ToString();

                //STATUS IF PARA LER DO BD 0 OU 1 E EXIBIR NO CHECKED BOX
                if (cCliente.status == 1)
                {
                    fCliente.checkBoxStatus.Checked = true;
                }
                else
                {
                    fCliente.checkBoxStatus.Checked = false;
                }

               fCliente.txtDataCadastroCliente.Text = cCliente.data_cadastro.ToString("dd/MM/yyyy");
                               
                //CHAMAR O FORM DE CADASTRO COM OS DADOS CARREGADOS DO BD - MODO EXCLUSIVO: ShowDialog
                fCliente.ShowDialog();

                //ATUALIZAR A GRID DE COSULTA
                btPesquisar_Click(this, new EventArgs());
            }
        }

        private void FormatarGrid()
        {
            // 1. Renomear os cabeçalhos (se a coluna existir no grid)
            if (dgvCliente.Columns.Contains("codigo_cliente"))
                dgvCliente.Columns["codigo_cliente"].HeaderText = "Código";

            if (dgvCliente.Columns.Contains("nome"))
                dgvCliente.Columns["nome"].HeaderText = "Nome do cliente";

            if (dgvCliente.Columns.Contains("observacao"))
                dgvCliente.Columns["observacao"].HeaderText = "Observação";

            if (dgvCliente.Columns.Contains("status"))
                dgvCliente.Columns["status"].HeaderText = "Status";

            if (dgvCliente.Columns.Contains("data_cadastro"))
                dgvCliente.Columns["data_cadastro"].HeaderText = "Data Cadastro";

            // 2. Estilizar o cabeçalho (Cor, Fonte e Alinhamento)
            // OBRIGATÓRIO: Desativar os estilos visuais do Windows para a cor de fundo funcionar
            dgvCliente.EnableHeadersVisualStyles = false;

            // Cor de fundo do cabeçalho (usando a mesma cor azul escuro do seu form)
            dgvCliente.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);

            // Cor da letra
            dgvCliente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Deixar a letra em Negrito e mudar a fonte
            dgvCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);

            // Centralizar o texto do cabeçalho
            dgvCliente.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ====================================================================
            // ESTILIZAR AS LINHAS (REMOVER A LINHA BRANCA)
            // ====================================================================

            // Define a cor de fundo escuro e a fonte branca como padrão para todas as linhas
            dgvCliente.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvCliente.DefaultCellStyle.ForeColor = Color.White;

            // Define a MESMA cor de fundo para as linhas alternadas (removendo o zebrado)
            dgvCliente.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvCliente.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Cor da linha ao selecionar
            dgvCliente.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvCliente.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
    
    
}
