using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;//Dark materials visual
using MaterialSkin.Controls;//Dark materials visual
using System.Net.Http;//Json para usar o via CEP
using Newtonsoft.Json;//Json para usar o via CEP


namespace IOTStore
{
    public partial class formFuncionario : MaterialSkin.Controls.MaterialForm
    {
        public formFuncionario()
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

        //CRIAR VARIAVEIS QUE SERÃO UTILIZADAS NO FORM DE CONSULTA
        //TIPO - MANEIRA QUE O FORM SERÁ ABERTO
        // OUTRAS VARIAVEIS - EXIBIR OS DADOS QUE ESTÃO ARMAZENADOS NO BD E NÃO OS DECLARADOS NO LOAD DO FORM
        public string tipo, estado_civil, estado;
        public int cargo, tipo_acesso;
        public DateTime data_cadastro;

        // Coloque aqui o caminho real da pasta de fotos do seu servidor Web!
        // Lembre-se de colocar as duas barras \\ no final do caminho.
        public string pastaFotosWeb = @"C:\xampp\htdocs\INFO_52\IOT_Store\images\\";



        private void formFuncionario_Load(object sender, EventArgs e)
        {
            //CARREGAR DATA CADASTRO AUTOMATICAMENTE

            txtDataCadastroFuncionario.Text = DateTime.Now.ToShortDateString();

            //CARREGAR COMBOS
            //COMBO ESTADO


            cBEstadoFuncionario.Items.Add("AC");
            cBEstadoFuncionario.Items.Add("AL");
            cBEstadoFuncionario.Items.Add("AM");
            cBEstadoFuncionario.Items.Add("AP");
            cBEstadoFuncionario.Items.Add("BA");
            cBEstadoFuncionario.Items.Add("CE");
            cBEstadoFuncionario.Items.Add("DF");
            cBEstadoFuncionario.Items.Add("ES");
            cBEstadoFuncionario.Items.Add("GO");
            cBEstadoFuncionario.Items.Add("MA");
            cBEstadoFuncionario.Items.Add("MG");
            cBEstadoFuncionario.Items.Add("MS");
            cBEstadoFuncionario.Items.Add("MT");
            cBEstadoFuncionario.Items.Add("PA");
            cBEstadoFuncionario.Items.Add("PB");
            cBEstadoFuncionario.Items.Add("PE");
            cBEstadoFuncionario.Items.Add("PI");
            cBEstadoFuncionario.Items.Add("PR");
            cBEstadoFuncionario.Items.Add("RJ");
            cBEstadoFuncionario.Items.Add("RN");
            cBEstadoFuncionario.Items.Add("RO");
            cBEstadoFuncionario.Items.Add("RR");
            cBEstadoFuncionario.Items.Add("RS");
            cBEstadoFuncionario.Items.Add("SC");
            cBEstadoFuncionario.Items.Add("SE");
            cBEstadoFuncionario.Items.Add("SP");
            cBEstadoFuncionario.Items.Add("TO");


            //DEIXAR UM ESTADO DEFAUT

            cBEstadoFuncionario.SelectedItem ="SP";

            //COMBO ESTADO CIVIL

            cBEstadoCivilFuncionario.Items.Add("Solteiro(a)");
            cBEstadoCivilFuncionario.Items.Add("Casado(a)");
            cBEstadoCivilFuncionario.Items.Add("Separado(a)");
            cBEstadoCivilFuncionario.Items.Add("Divorciado(a)");
            cBEstadoCivilFuncionario.Items.Add("Viúvo(a)");
            cBEstadoCivilFuncionario.SelectedIndex = 0;

            //COMBO TIPO DE ACESSO
            cbAcessoFuncionario.Items.Add("Comum"); //0
            cbAcessoFuncionario.Items.Add("Administrador"); //1
            cbAcessoFuncionario.SelectedIndex = 0;

            // COMBO CARGO - ALIMENTADA PELO BANCO DE DADOS ATRAVÉS DO METODO QUE CRIAMOS NA CLASSE CARGO
            //CRIAR OBJETO DA CLASSE CARGO PARA USAR O METODO QUE VAI CARREGAR A COMBO
            classCargo cCargo = new classCargo();

            //CHAMAR O METODO QUE CARREGA AS INFORMAÇÕES NA COMBO CARGO
            cBCargoFuncionario.DataSource = cCargo.BuscarCargo();

            //O QUE SERA EXIBIDO NA COMBO - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cBCargoFuncionario.DisplayMember = "nome";

            //O QUE SERA ARMAZENADO NO BANCO DE DADOS - NOME DA COLUNA IGUAL O BANCO DE DADOS
            cBCargoFuncionario.ValueMember = "codigo_cargo";

            //NÃO DEIXAR NENHUM CARGO SELECIONAR
            cBCargoFuncionario.SelectedIndex = -1;


            //VERIFICAR O MODO DE ABERTURA DO FORM - SE FOR ATUALIZAÇÃO
            if (tipo == "Atualização")
            {
                lbTitulo.Text = "Atualização de Funcionário";
                checkBoxStatus.Enabled = true;
                btCadastrarFuncionario.Enabled = false;
                //COMBO BOX (VARIAVEIS CRIADAS PARA ATUALIZAÇÃO)
                //RECEBER O QUE ESTÁ ARMAZENADA NO BD E NÃO O PADRAO QUE FOI DEFINIDO NA HORA DE CADASTRAR
                txtDataCadastroFuncionario.Text = data_cadastro.ToString();
                cBEstadoFuncionario.SelectedItem = estado;
                cBEstadoCivilFuncionario.SelectedItem = estado_civil;
                cBCargoFuncionario.SelectedValue = cargo;

                //TIPO DE ACESSO
                if (tipo_acesso == 0)
                {
                    cbAcessoFuncionario.SelectedItem = "Comum";
                }
                else
                {
                    cbAcessoFuncionario.SelectedItem = "Administrador";
                }

            }
            else
            {
                btAtualizarFuncionario.Enabled = false;
                btExcluirFuncionario.Enabled = false;
            }
        }

        private void btSairFuncionario_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //METODO PARA PINTAR OS CAMPOS OBRIGATORIOS NO FORM

        private void CamposObrigatorios()
        {
            txtNomeFuncionario.BackColor = Color.AliceBlue;
            txtNascimento.BackColor = Color.AliceBlue;
            panelSexo.BackColor = Color.AliceBlue;
            panelCPF.BackColor = Color.AliceBlue;
            panelEndereco.BackColor = Color.AliceBlue;
            panelEndereco2.BackColor = Color.AliceBlue;
            panelTelCelular.BackColor = Color.AliceBlue;
            panelTelResidencial.BackColor = Color.AliceBlue;
            panelEmail.BackColor = Color.AliceBlue;
            panelUsuario.BackColor = Color.AliceBlue;
            panelSenha.BackColor = Color.AliceBlue;
            panelAcesso.BackColor = Color.AliceBlue;
            panelCargo.BackColor = Color.AliceBlue;
            txtNomeFuncionario.Focus();


        }

        //METODO PARA LIMPAR TODOS OS CAMPOS APÓS REALIZAR O CADASTRO

        private void Limpar()
        {
            txtNomeFuncionario.Clear();
            txtNomeSocial.Clear();
            txtNascimento.Clear();
            rbFeminino.Checked = true;
            cBEstadoCivilFuncionario.SelectedIndex = 0;
            maskedTextCPF.Clear();
            txtRgFuncionario.Clear();
            txtFuncionarioSalario.Clear();
            txtCepFuncionario.Clear();
            txtEnderecoFuncionario.Clear();
            txtNumeroFuncionario.Clear();
            txtComplementoFuncionario.Clear();
            txtBairroFuncionario.Clear();
            txtCidadeFuncionario.Clear();
            cBEstadoFuncionario.SelectedItem = "SP";
            maskedCelular.Clear();
            maskedResidencial.Clear();
            txtEmailFuncionario.Clear();
            txtUsuarioFuncionario.Clear();
            txtSenhaFuncionario.Clear();
            cbAcessoFuncionario.SelectedIndex = 0;
            cBCargoFuncionario.SelectedIndex = -1;
            fotoFuncionario.Image = null;
            fotoFuncionario.Tag = null;

        }

        private void btCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            classFuncionario cFuncionario = new classFuncionario();

            //VERIFCAR CAMPOS OBRIGATORIOS

            if (string.IsNullOrWhiteSpace(txtNomeFuncionario.Text) || txtNascimento.Text == "  /  /" || txtCPFFuncionario.Text == "___.___.___-__" || string.IsNullOrWhiteSpace(txtEnderecoFuncionario.Text) || string.IsNullOrWhiteSpace(txtNumeroFuncionario.Text) || string.IsNullOrWhiteSpace(txtBairroFuncionario.Text) || string.IsNullOrWhiteSpace(txtCidadeFuncionario.Text) || (maskedCelular.Text == "___.___.___-__" || maskedResidencial.Text == "___.___.___-__") || string.IsNullOrWhiteSpace(txtUsuarioFuncionario.Text) || string.IsNullOrWhiteSpace(txtSenhaFuncionario.Text) || cBCargoFuncionario.SelectedIndex == -1) 
            {

                MessageBox.Show("Favor Verificar Todos os Campos Obrigatorios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios(); //PINTA OS CAMPOS OBRIGATORIOS
            }
            else // USUARIO PREENCHEU OS CAMPOS
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE O QUE FOI DIGITADO PELO USUARIO
                cFuncionario.nome = txtNomeFuncionario.Text;
                cFuncionario.nome_social = txtNomeSocial.Text;
                cFuncionario.data_nascimento = Convert.ToDateTime(txtNascimento.Text);
                //SEXO - RADIOBUTON - IF PARA LER ESCOLHA DO USUARIO
                if (rbFeminino.Checked)
                {
                    cFuncionario.sexo = "F";
                }
                else if (rbMasculino.Checked)
                {
                    cFuncionario.sexo = "M";
                }
                else
                {
                    cFuncionario.sexo = "O";
                }
                //ESTADO CIVIL - COMBO BOX - PEGAR OPÇÃO ESCOLHIDA PELO USUARIO
                cFuncionario.estado_civil = cBEstadoCivilFuncionario.SelectedItem.ToString(); // COMBOBOX SEMPRE PRECISA CONVERTER
                cFuncionario.cpf = maskedTextCPF.Text;
                //RG TEM MASCARA CAMPO NÃO OBRIGATÓRIO NO BANCO - PRECISA FAZER UM IF PRA MANDAR VAZIO CASO NÃO SEJA PREENCHIDO
                if (txtRgFuncionario.Text == "__.___.___ - _")
                {
                    cFuncionario.rg = "";
                }
                else
                {
                    cFuncionario.rg = txtRgFuncionario.Text;
                }
                //SALARIO - CAMPO NUMERICO NÃO OBRIGATORIO NO BANCO - NÃO PODE IR VAZIO - FAZE IF PARA ENVIAR 0 CASO NÃO SEJA PREENCHIDO PELO USUARIO
                if (txtFuncionarioSalario.Text =="")
                {
                    cFuncionario.salario = 0;

                }
                else
                {
                    cFuncionario.salario = Convert.ToDecimal(txtFuncionarioSalario.Text);
                }
                cFuncionario.endereco = txtEnderecoFuncionario.Text;
                cFuncionario.numero = Convert.ToInt32(txtNumeroFuncionario.Text);
                cFuncionario.complemento = txtComplementoFuncionario.Text;
                cFuncionario.bairro = txtBairroFuncionario.Text;
                cFuncionario.cidade = txtCidadeFuncionario.Text;
                cFuncionario.estado = cBEstadoFuncionario.SelectedItem.ToString();
                //CEP - MASCARA
                if (txtCepFuncionario.Text == "_____-___")
                {
                    cFuncionario.cep = "";
                }
                else
                {
                    cFuncionario.cep = txtCepFuncionario.Text;
                }
                //RESIDENCIAL
               if (maskedResidencial.Text == "(  )    -    ")
                {
                    cFuncionario.telefone_residencial = "";
                }
                else
                {
                    cFuncionario.telefone_residencial = maskedResidencial.Text;
                }
                //CELULAR
                if (maskedCelular.Text == "(  )     -    ")
                {
                    cFuncionario.telefone_celular = "";
                }
                else
                {
                    cFuncionario.telefone_celular = maskedCelular.Text;
                }
                cFuncionario.email = txtEmailFuncionario.Text;
                cFuncionario.usuario = txtUsuarioFuncionario.Text;
                cFuncionario.senha = txtSenhaFuncionario.Text;
                //TIPO DE ACESSO 0 -> Comum 1 -> Adm
                if (cbAcessoFuncionario.SelectedItem.ToString() == "Comum")
                {
                    cFuncionario.tipo_acesso = 0;
                }
                else
                {
                    cFuncionario.tipo_acesso = 1;
                }
                //FOTO NÃO É OBRIGATORIO C#
                if (fotoFuncionario.Tag != null)
                {
                    cFuncionario.foto = fotoFuncionario.Tag.ToString(); // SALVA O CAMINHO DA FOTO
                }
                else
                {
                    cFuncionario.foto = ""; // SEM FOTO
                }
                //CÓDIGO CARGO - CHAVE ESTRANGEIRA - USAR A PROPRIEDADE SELECTEDVALUE DA COMBOBOX
                cFuncionario.codigo_cargo = Convert.ToInt32(cBCargoFuncionario.SelectedValue);


                //CHAMAR O MÉTODO DE CADASTRAR FUNCIONARIO DA CLASSE FUCIONARIO
                int resp = cFuncionario.CadastrarFuncionario();

                //MOSTRAR O RESULTADO DO CADASTRO PARA O USUARIO
                // SE CADASTRO REALIZADO COM SUCESSO = 1
                if (resp == 1)
                {
                    MessageBox.Show($"Funcionário {cFuncionario.nome} cadastrado com sucesso", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar Funcionario!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btAtualizarFuncionario_Click(object sender, EventArgs e)
        {
            classFuncionario cFuncionario = new classFuncionario();

            //VERIFCAR CAMPOS OBRIGATORIOS

            if (string.IsNullOrWhiteSpace(txtNomeFuncionario.Text) || txtNascimento.Text == "  /  /" || txtCPFFuncionario.Text == "___.___.___-__" || string.IsNullOrWhiteSpace(txtEnderecoFuncionario.Text) || string.IsNullOrWhiteSpace(txtNumeroFuncionario.Text) || string.IsNullOrWhiteSpace(txtBairroFuncionario.Text) || string.IsNullOrWhiteSpace(txtCidadeFuncionario.Text) || (maskedCelular.Text == "___.___.___-__" || maskedResidencial.Text == "___.___.___-__") || string.IsNullOrWhiteSpace(txtUsuarioFuncionario.Text) || string.IsNullOrWhiteSpace(txtSenhaFuncionario.Text) || cBCargoFuncionario.SelectedIndex == -1)
            {

                MessageBox.Show("Favor Verificar Todos os Campos Obrigatorios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios(); //PINTA OS CAMPOS OBRIGATORIOS
            }
            else // USUARIO PREENCHEU OS CAMPOS
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE O QUE FOI DIGITADO PELO USUARIO
                cFuncionario.nome = txtNomeFuncionario.Text;
                cFuncionario.nome_social = txtNomeSocial.Text;
                cFuncionario.data_nascimento = Convert.ToDateTime(txtDataCadastroFuncionario.Text);
                //SEXO - RADIOBUTON - IF PARA LER ESCOLHA DO USUARIO
                if (rbFeminino.Checked)
                {
                    cFuncionario.sexo = "F";
                }
                else if (rbMasculino.Checked)
                {
                    cFuncionario.sexo = "M";
                }
                else
                {
                    cFuncionario.sexo = "O";
                }
                //ESTADO CIVIL - COMBO BOX - PEGAR OPÇÃO ESCOLHIDA PELO USUARIO
                cFuncionario.estado_civil = cBEstadoCivilFuncionario.SelectedItem.ToString(); // COMBOBOX SEMPRE PRECISA CONVERTER
                cFuncionario.cpf = maskedTextCPF.Text;
                //RG TEM MASCARA CAMPO NÃO OBRIGATÓRIO NO BANCO - PRECISA FAZER UM IF PRA MANDAR VAZIO CASO NÃO SEJA PREENCHIDO
                if (txtRgFuncionario.Text == "__.___.___ - _")
                {
                    cFuncionario.rg = "";
                }
                else
                {
                    cFuncionario.rg = txtRgFuncionario.Text;
                }
                //SALARIO - CAMPO NUMERICO NÃO OBRIGATORIO NO BANCO - NÃO PODE IR VAZIO - FAZE IF PARA ENVIAR 0 CASO NÃO SEJA PREENCHIDO PELO USUARIO
                if (txtFuncionarioSalario.Text == "    ,")
                {
                    cFuncionario.salario = 0;

                }
                else
                {
                    cFuncionario.salario = Convert.ToDecimal(txtFuncionarioSalario.Text);
                }
                cFuncionario.endereco = txtEnderecoFuncionario.Text;
                cFuncionario.numero = Convert.ToInt32(txtNumeroFuncionario.Text);
                cFuncionario.complemento = txtComplementoFuncionario.Text;
                cFuncionario.bairro = txtBairroFuncionario.Text;
                cFuncionario.cidade = txtCidadeFuncionario.Text;
                cFuncionario.estado = cBEstadoFuncionario.SelectedItem.ToString();
                //CEP - MASCARA
                if (txtCepFuncionario.Text == "_____-___")
                {
                    cFuncionario.cep = "";
                }
                else
                {
                    cFuncionario.cep = txtCepFuncionario.Text;
                }
                //RESIDENCIAL
                if (maskedResidencial.Text == "(  )    -    ")
                {
                    cFuncionario.telefone_residencial = "";
                }
                else
                {
                    cFuncionario.telefone_residencial = maskedResidencial.Text;
                }
                //CELULAR
                if (maskedCelular.Text == "(  )     -    ")
                {
                    cFuncionario.telefone_celular = "";
                }
                else
                {
                    cFuncionario.telefone_celular = maskedCelular.Text;
                }
                cFuncionario.email = txtEmailFuncionario.Text;
                cFuncionario.usuario = txtUsuarioFuncionario.Text;
                cFuncionario.senha = txtSenhaFuncionario.Text;
                //TIPO DE ACESSO 0 -> Comum 1 -> Adm
                if (cbAcessoFuncionario.SelectedItem.ToString() == "Comum")
                {
                    cFuncionario.tipo_acesso = 0;
                }
                else
                {
                    cFuncionario.tipo_acesso = 1;
                }
                //FOTO NÃO É OBRIGATORIO C#
                if (fotoFuncionario.Tag != null)
                {
                    cFuncionario.foto = fotoFuncionario.Tag.ToString(); // SALVA O CAMINHO DA FOTO
                }
                else
                {
                    cFuncionario.foto = ""; // SEM FOTO
                }
                //CÓDIGO CARGO - CHAVE ESTRANGEIRA - USAR A PROPRIEDADE SELECTEDVALUE DA COMBOBOX
                cFuncionario.codigo_cargo = Convert.ToInt32(cBCargoFuncionario.SelectedValue);

                //ALTERAÇÕES DO BOTÃO ATUALIZAR/////////////////////////////

                //CARREGAR CÓDIGO DO FUNCIONARIO CADASTRADO
                cFuncionario.codigo_funcionario = Convert.ToInt32(txtCodigoFuncionario.Text);

                //STATUS 
                if (checkBoxStatus.Checked)
                {
                    cFuncionario.status = 1;
                }
                else
                {
                    cFuncionario.status = 0;
                }
                                
                //CHAMAR O MÉTODO DE CADASTRAR FUNCIONARIO DA CLASSE FUCIONARIO
                int resp = cFuncionario.AtualizarFuncionario();

                //MOSTRAR O RESULTADO DO CADASTRO PARA O USUARIO
                // SE CADASTRO REALIZADO COM SUCESSO = 1
                if (resp == 1)
                {
                    MessageBox.Show($"Funcionário {cFuncionario.nome} atualizado com sucesso!", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar Funcionario!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btExcluirFuncionario_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Deseja realmente excluir o funcionário: {txtNomeFuncionario.Text}?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                
            {
                classFuncionario cFuncionario = new classFuncionario();
                cFuncionario.codigo_funcionario = Convert.ToInt32(txtCodigoFuncionario.Text);

                int resp = cFuncionario.ExcluirFuncionario();

                if (resp == 1)
                {
                    MessageBox.Show($"Funcionário: {txtNomeFuncionario.Text} excluido com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Erro a excluir funcionário: {txtNomeFuncionario.Text} !", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private async void txtCepFuncionario_Leave(object sender, EventArgs e)
        {
            // Limpa a máscara para pegar apenas os números
            string cep = txtCepFuncionario.Text.Replace("-", "").Replace(" ", "").Trim();

            // Verifica se o usuário digitou os 8 números do CEP
            if (cep.Length == 8)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        // Faz a chamada na API do ViaCEP
                        string url = $"https://viacep.com.br/ws/{cep}/json/";
                        string resposta = await client.GetStringAsync(url);

                        // O ViaCEP retorna um JSON com "erro": true se o CEP não existir
                        if (resposta.Contains("{\n  \"erro\": \"true\"\n}"))
                        {
                            MessageBox.Show("CEP não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Converte a resposta JSON em um objeto que o C# entende
                        dynamic resultado = JsonConvert.DeserializeObject(resposta);

                        // Preenche os campos do seu formulário automaticamente
                        txtEnderecoFuncionario.Text = resultado.logradouro;
                        txtBairroFuncionario.Text = resultado.bairro;
                        txtCidadeFuncionario.Text = resultado.localidade;
                        cBEstadoFuncionario.Text = resultado.uf;

                        // Joga o cursor piscando direto para o campo de número da casa
                        txtNumeroFuncionario.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar o CEP: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        //FINAL ALTERAÇÕES DO BOTÃO ATUALIZAR/////////////////////////////


        //VALIDAR DATA VALIDA NO CAMPO NASCIMENTO
        private void txtNascimento_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                // Se a entrada não converter para DateTime, mostramos um erro
                MessageBox.Show("A data digitada é inválida ou está em formato incorreto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Opcional: Cancelar a saída do foco se o dado estiver errado
                // e.Cancel = true; 
            }
            else
            {
                // Se for válido, você pode acessar o valor já convertido
                DateTime dataInformada = (DateTime)e.ReturnValue;
                Console.WriteLine($"Data válida: {dataInformada.ToShortDateString()}");
            }
        }


        private void txtNumeroFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // SE A TECLA DIGITADA NÃO FOR NÚMERO, BACKSPACE(08), ENTER(13), ESPAÇO(32), VÍRGULA(44) E PONTO(46)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                // SE O USUÁRIO PRESSIONAR UMA TECLA NÃO NUMÉRICA NO TEXTBOX, CANCELA O EVENTO KEY PRESS
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Números!", "IOT Store",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btFotoFuncionario_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecionar Foto do Funcionário";
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
                    if (fotoFuncionario.Image != null)
                    {
                        fotoFuncionario.Image.Dispose();
                        fotoFuncionario.Image = null;
                    }

                    // 3. Agora sim copia o arquivo sem que o Windows bloqueie!
                    System.IO.File.Copy(ofd.FileName, caminhoDestino, true);

                    // 4. Carrega a foto nova usando o truque do Clone de Memória
                    using (Image imgNova = Image.FromFile(caminhoDestino))
                    {
                        fotoFuncionario.Image = new Bitmap(imgNova);
                    }

                    fotoFuncionario.SizeMode = PictureBoxSizeMode.Zoom;
                    fotoFuncionario.Tag = nomeArquivo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao processar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
