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
    public partial class formConsultaFuncionario : MaterialForm
    {
        public formConsultaFuncionario()
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

      
        private void formConsFuncionario52_Load(object sender, EventArgs e)
        {
            //CARREGAR COMBO DE OPÇÕES DE CONSULTA
            cbOpcoes.Items.Add("Nome");
            cbOpcoes.Items.Add("Cargo");
            cbOpcoes.Items.Add("Cidade");
            cbOpcoes.Items.Add("CPF");
            cbOpcoes.Items.Add("Sexo");
            cbOpcoes.Items.Add("Data de Admissão");
            cbOpcoes.Items.Add("Sexo e Cidade");
            cbOpcoes.Items.Add("Status");

            cbOpcoes.SelectedIndex = 0;

            //CARREGAR COMBO SEXO
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Não Informado");

            cbSexo.SelectedIndex = 0;

            //CARREGAR COMBO CARGO
            // COMBO CARGO - ALIMENTADA PELO BANCO DE DADOS ATRAVÉS DO METODO QUE CRIAMOS NA CLASSE CARGO
            //CRIAR OBJETO DA CLASSE CARGO PARA USAR O METODO QUE VAI CARREGAR A COMBO
            classCargo cCargo = new classCargo();

            //CHAMAR O METODO QUE CARREGA AS INFORMAÇÕES NA COMBO CARGO
            cbCargo.DataSource = cCargo.BuscarCargo();

            //O QUE SERA EXIBIDO NA COMBO - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbCargo.DisplayMember = "nome";

            //O QUE SERA ARMAZENADO NO BANCO DE DADOS - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbCargo.ValueMember = "codigo_cargo";

           

            //CARREGAR COMBO CIDADE

            //CRIAR OBJETO DA CLASSE CARGO PARA USAR O METODO QUE VAI CARREGAR A COMBO
            classFuncionario cFuncionario = new classFuncionario();

            //CHAMAR O METODO QUE CARREGA AS INFORMAÇÕES NA COMBO CARGO
            cbCidade.DataSource = cFuncionario.BuscarCidade();

            //O QUE SERA EXIBIDO NA COMBO - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbCidade.DisplayMember = "cidade";

            //O QUE SERA ARMAZENADO NO BANCO DE DADOS - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cbCidade.ValueMember = "cidade";
                       
        }

        private void cbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //HABILITAR/DESABILITAR COMPONENTES DO FORM DE ACORDO COM A ESCOLHA DO USUARIO
            // 0 - NOME
            if(cbOpcoes.SelectedIndex ==0) 
            {
                gbTipoPesquisa.Enabled = true;
                gbNome.Enabled = true;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCargo.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;
                txtNome.Focus();
            }

            // 1 - CARGO
            if (cbOpcoes.SelectedIndex == 1)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCargo.Enabled = true;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;
                
            }

            // 2 - CIDADE
            if (cbOpcoes.SelectedIndex == 2)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = true;
                gbDataAdmissao.Enabled = false;
                gbCargo.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;

            }

            // 3 - CPF
            if (cbOpcoes.SelectedIndex == 3)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCargo.Enabled = false;
                gbCPF.Enabled = true;
                gbStatus.Enabled = false;
                mskCpf.Focus();

            }

            // 4 - SEXO
            if (cbOpcoes.SelectedIndex == 4)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = true;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCargo.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;

            }

            // 5 - DATA ADMISSÃO
            if (cbOpcoes.SelectedIndex == 5)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = true;
                gbCargo.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;

            }

            // 6 - SEXO E CIDADE
            if (cbOpcoes.SelectedIndex == 6)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = true;
                gbCidade.Enabled = true;
                gbDataAdmissao.Enabled = false;
                gbCargo.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = false;

            }


            // 7- Status
            if (cbOpcoes.SelectedIndex == 7)
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbSexo.Enabled = false;
                gbCidade.Enabled = false;
                gbDataAdmissao.Enabled = false;
                gbCargo.Enabled = false;
                gbCPF.Enabled = false;
                gbStatus.Enabled = true;

            }


        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            classFuncionario cFuncionario = new classFuncionario();

            //CRIAR VARIAVEL PARA ALIMENTAR O SWITCH

            string filtro = cbOpcoes.SelectedItem.ToString();

            switch (filtro)
            {
                //CARGO
                case "Cargo":

                    dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioCargo(Convert.ToInt32(cbCargo.SelectedValue));
                    break;

                //CIDADE
                case "Cidade":

                    dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioCidade(Convert.ToString(cbCidade.SelectedValue));
                    break;

                //CPF
                case "CPF":
                    //VERIFICAR SE O USUARIO DIGITOU CPF
                    if (mskCpf.Text != "   .   .   -")
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioCpf(mskCpf.Text);
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
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexo("F");
                    }
                    //FEMININO
                    else if (cbSexo.SelectedItem.ToString() == "Masculino")
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexo("M");
                    }
                    //NÃO INFORMADO
                    else 
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexo("O");
                    }
                    

                    break;
                //DATA DE ADMISSÃO
                case "Data de Admissão":
                    //VOLTAR PARA VALIDAR DATA INCIAL MENOR QUE DATA FINAL

                    dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioCadastro(Convert.ToDateTime(dtpDataInicial.Text), Convert.ToDateTime(dtpDataFinal.Text));
                    
                    
                    break;

                //STATUS
                case "Status":
                    //INATIVO
                    if (rbInativo.Checked)
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioStatus(0);
                    }
                    else
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioStatus(1);
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
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexoCidade("F", cidadeSelecionada);
                    }
                    //MASCULINO
                    else if (cbSexo.SelectedItem.ToString() == "Masculino")
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexoCidade("M", cidadeSelecionada);
                    }
                    //NÃO INFORMADO
                    else
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexoCidade("O", cidadeSelecionada);
                    }

                    break;


                //NOME

                default:
                    //VERIFICAR SE O USUSARIO PREENCHEU O NOME
                    if(String.IsNullOrWhiteSpace(txtNome.Text))
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
                            dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioNomeInicio(txtNome.Text);
                        }
                        else
                        {
                            dgvFuncionario.DataSource = cFuncionario.ConsultaFuncionarioNomeContem(txtNome.Text);
                        }
                    }


                break;





            }//FECHAMENTO DO SWITCH NÃO APAGAR

            FormatarGrid();



        }

        private void dgvFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //CLICAR NO GRID DO FUNCIONARIO E EDITAR OU EXCLUIR UM FUNCIONARIO
            //USAR O EVENTO CELLCLICK (PODE CLICAR EM QUALQUER LUGAR DA CÉLULA, NÃO SOMENTE NO TEXTO)
            //USANDO O EVENTO CELLCONTENTCLICK (TEM QUE CLICAR NO CONTEÚDO (TEXTO))

            //PERGUNTAR PARA USUARIO SE REALMENTE DESEJA ALTERAR O FUNCIONARIO SELECIONADO
            if (MessageBox.Show("Deseja alterar ou excluir o funcionário selecionado?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //INTANCIAR A CLASSE FUNCIONARIO
                classFuncionario cFuncionario = new classFuncionario();

                //INTANCIAR O FORMULARIO DE CADASTRO DE FUNCIONARIO - PARA MANDAR AS INFORMAÇÕES DO BD PARA O FORM
                formFuncionario fFuncionario = new formFuncionario();

                //PEGAR O FUNCIONARIO ESCOLHIDO PELO USUARIO ATRAVES DA SELEÇÃO NA GRID
                cFuncionario.DadosFuncionario(Convert.ToInt32(dgvFuncionario.SelectedRows[0].Cells[0].Value));

                //PASSAR OS DADOS DO BANCO PARA OS ELEMENTOS DO FORM DE CADASTRO
                fFuncionario.txtCodigoFuncionario.Text = cFuncionario.codigo_funcionario.ToString();
                fFuncionario.txtNomeFuncionario.Text = cFuncionario.nome.ToString();
                fFuncionario.txtNomeSocial.Text  = cFuncionario.nome_social.ToString();
                fFuncionario.txtNascimento.Text = cFuncionario.data_nascimento.ToString();
                //SEXO IF PARA LER O QUE ESTÁ ARMAZENADO NO BD E DEIXAR O RADIO BUTON SELECIONADO
                if (cFuncionario.sexo == "F")
                {
                    fFuncionario.rbFeminino.Checked = true;
                }
                else if (cFuncionario.sexo == "M")
                {
                    fFuncionario.rbMasculino.Checked = true;
                }
                else
                {
                    fFuncionario.rbNaoInformado.Checked = true;
                }
                //ESTADO CIVIL - COMBOBOX PASSAR VARIAVEL DECLARADA NO FORM
                fFuncionario.estado_civil = cFuncionario.estado_civil;
                fFuncionario.maskedTextCPF.Text = cFuncionario.cpf.ToString();
                fFuncionario.txtRgFuncionario.Text = cFuncionario.rg.ToString();
                fFuncionario.txtFuncionarioSalario.Text = cFuncionario.salario.ToString();
                fFuncionario.txtEnderecoFuncionario.Text = cFuncionario.endereco.ToString();
                fFuncionario.txtNumeroFuncionario.Text = cFuncionario.numero.ToString();
                fFuncionario.txtComplementoFuncionario.Text = cFuncionario.complemento.ToString();
                fFuncionario.txtBairroFuncionario.Text = cFuncionario.bairro.ToString();
                fFuncionario.txtCidadeFuncionario.Text = cFuncionario.cidade.ToString();
                //ESTADO COMBOBOX PASSAR VARIAVEL DECLARADA NO FORM
                fFuncionario.estado = cFuncionario.estado;
                fFuncionario.txtCepFuncionario.Text = cFuncionario.cep.ToString();
                fFuncionario.maskedResidencial.Text = cFuncionario.telefone_residencial.ToString();
                fFuncionario.maskedCelular.Text = cFuncionario.telefone_celular.ToString();
                fFuncionario.txtEmailFuncionario.Text = cFuncionario.email.ToString();
                //STATUS IF PARA LER DO BD 0 OU 1 E EXIBIR NO CHECKED BOX
                if (cFuncionario.status == 1)
                {
                    fFuncionario.checkBoxStatus.Checked = true;
                }
                else
                {
                    fFuncionario.checkBoxStatus.Checked = false;
                }
                //DATA CADASTRO PASSAR VARIAVEL DECLARADA NO FORM
                fFuncionario.data_cadastro = cFuncionario.data_cadastro;
                fFuncionario.txtUsuarioFuncionario.Text = cFuncionario.usuario.ToString();
                fFuncionario.txtSenhaFuncionario.Text = cFuncionario.senha.ToString();
                //TIPO ACESSO IF PARA LER DO BD 0 COMUM OU 1 ADMINISTRADOR E EXIBIR NA COMBOBOX
                if (cFuncionario.tipo_acesso == 0)
                {
                    fFuncionario.tipo_acesso = 0;
                }
                else
                {
                    fFuncionario.tipo_acesso = 1;
                }
                
                //CARREGAR A FOTO DO BD E EXIBIR NO PICTUREBOX
                if (!string.IsNullOrEmpty(cFuncionario.foto))
                {
                    try
                    {
                        string pastaFotosWeb = @"C:\xampp\htdocs\INFO_52\IOT_Store\images\\";
                        string caminhoCompleto = pastaFotosWeb + cFuncionario.foto;

                        // O TRUQUE DO CLONE DE MEMÓRIA:
                        // Abre a foto original, faz uma cópia na memória e fecha a original (using)
                        using (Image imgOriginal = Image.FromFile(caminhoCompleto))
                        {
                            fFuncionario.fotoFuncionario.Image = new Bitmap(imgOriginal);
                        }

                        fFuncionario.fotoFuncionario.SizeMode = PictureBoxSizeMode.Zoom;
                        fFuncionario.fotoFuncionario.Tag = cFuncionario.foto;
                    }
                    catch (Exception)
                    {
                        fFuncionario.fotoFuncionario.Image = null;
                        fFuncionario.fotoFuncionario.Tag = cFuncionario.foto;
                    }
                }
                else
                {
                    fFuncionario.fotoFuncionario.Image = null;
                    fFuncionario.fotoFuncionario.Tag = null;
                }

                // CARGO COMBOBOX PASSAR VARIAVEL DECLARADA NO FORM
                fFuncionario.cargo = cFuncionario.codigo_cargo;

                //PASSAR PARA A VARIAVEL TIPO DECLARADA NO FORM DE CADASTRO COMO ELE SERÁ ABERTO - ATUALIZAÇÃO
                fFuncionario.tipo = "Atualização";

                //setar tamanho do form
                //fFuncionario.AutoScaleMode = font();

                //CHAMAR O FORM DE CADASTRO COM OS DADOS CARREGADOS DO BD - MODO EXCLUSIVO: ShowDialog
                fFuncionario.ShowDialog();

                //ATUALIZAR A GRID DE COSULTA
                btPesquisar_Click(this, new EventArgs());


            }
        }

       
        private void btSair_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o formulário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void FormatarGrid()
        {
            // 1. Renomear os cabeçalhos (se a coluna existir no grid)
            if (dgvFuncionario.Columns.Contains("codigo_funcionario"))
                dgvFuncionario.Columns["codigo_funcionario"].HeaderText = "Código";

            if (dgvFuncionario.Columns.Contains("nome"))
                dgvFuncionario.Columns["nome"].HeaderText = "Nome da Funcionario";

            if (dgvFuncionario.Columns.Contains("observacao"))
                dgvFuncionario.Columns["observacao"].HeaderText = "Observação";

            if (dgvFuncionario.Columns.Contains("status"))
                dgvFuncionario.Columns["status"].HeaderText = "Status";

            if (dgvFuncionario.Columns.Contains("data_cadastro"))
                dgvFuncionario.Columns["data_cadastro"].HeaderText = "Data Cadastro";

            // 2. Estilizar o cabeçalho (Cor, Fonte e Alinhamento)
            // OBRIGATÓRIO: Desativar os estilos visuais do Windows para a cor de fundo funcionar
            dgvFuncionario.EnableHeadersVisualStyles = false;

            // Cor de fundo do cabeçalho (usando a mesma cor azul escuro do seu form)
            dgvFuncionario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);

            // Cor da letra
            dgvFuncionario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Deixar a letra em Negrito e mudar a fonte
            dgvFuncionario.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);

            // Centralizar o texto do cabeçalho
            dgvFuncionario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ====================================================================
            // ESTILIZAR AS LINHAS (REMOVER A LINHA BRANCA)
            // ====================================================================

            // Define a cor de fundo escuro e a fonte branca como padrão para todas as linhas
            dgvFuncionario.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvFuncionario.DefaultCellStyle.ForeColor = Color.White;

            // Define a MESMA cor de fundo para as linhas alternadas (removendo o zebrado)
            dgvFuncionario.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvFuncionario.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Cor da linha ao selecionar
            dgvFuncionario.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvFuncionario.DefaultCellStyle.SelectionForeColor = Color.White;
        }

       
    }

 }
