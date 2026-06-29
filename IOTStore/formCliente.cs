using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;//Dark materials para o visual
using MaterialSkin.Controls; //Dark materials para o visual
using System.Net.Http;//Json para usar o via CEP
using Newtonsoft.Json;//Json para usar o via CEP


namespace IOTStore
{
    public partial class formCliente : MaterialSkin.Controls.MaterialForm
    {
        public formCliente()
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

        //METODO PARA PINTAR OS CAMPOS OBRIGATORIOS NO FORM

        private void CamposObrigatorios()
        {
            txtNomeCliente.BackColor = Color.AliceBlue;
            txtNascimento.BackColor = Color.AliceBlue;
            panelSexo.BackColor = Color.AliceBlue;
            panelCPF.BackColor = Color.AliceBlue;
            panelEndereco.BackColor = Color.AliceBlue;
            panelEndereco2.BackColor = Color.AliceBlue;
            panelTelCelular.BackColor = Color.AliceBlue;
            panelTelResidencial.BackColor = Color.AliceBlue;
            panelEmail.BackColor = Color.AliceBlue;         
            txtNomeCliente.Focus();


        }

        //METODO PARA LIMPAR TODOS OS CAMPOS APÓS REALIZAR O CADASTRO

        private void Limpar()
        {
            txtNomeCliente.Clear();
            txtNomeSocial.Clear();
            txtNascimento.Clear();
            rbFeminino.Checked = true;
            maskedTextCPF.Clear();
            txtRgCliente.Clear();
            txtCepCliente.Clear();
            txtEnderecoCliente.Clear();
            txtNumeroCliente.Clear();
            txtComplementoCliente.Clear();
            txtBairroCliente.Clear();
            txtCidadeCliente.Clear();
            cBEstadoCliente.SelectedItem = "SP";
            maskedCelular.Clear();
            maskedResidencial.Clear();
            txtEmailCliente.Clear();
        }

        private void btSairCliente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formCliente_Load(object sender, EventArgs e)
        {
            // CARREGAR DATA AUTOMATICAMENTE APENAS SE FOR UM NOVO CADASTRO
            // Se o código do cargo estiver vazio, significa que é um cadastro novo
            if (string.IsNullOrEmpty(txtCodigoCliente.Text))
            {
                txtDataCadastroCliente.Text = DateTime.Now.ToShortDateString();
            }

            //CARREGAR COMBOS
            //COMBO ESTADO


            cBEstadoCliente.Items.Add("AC");
            cBEstadoCliente.Items.Add("AL");
            cBEstadoCliente.Items.Add("AM");
            cBEstadoCliente.Items.Add("AP");
            cBEstadoCliente.Items.Add("BA");
            cBEstadoCliente.Items.Add("CE");
            cBEstadoCliente.Items.Add("DF");
            cBEstadoCliente.Items.Add("ES");
            cBEstadoCliente.Items.Add("GO");
            cBEstadoCliente.Items.Add("MA");
            cBEstadoCliente.Items.Add("MG");
            cBEstadoCliente.Items.Add("MS");
            cBEstadoCliente.Items.Add("MT");
            cBEstadoCliente.Items.Add("PA");
            cBEstadoCliente.Items.Add("PB");
            cBEstadoCliente.Items.Add("PE");
            cBEstadoCliente.Items.Add("PI");
            cBEstadoCliente.Items.Add("PR");
            cBEstadoCliente.Items.Add("RJ");
            cBEstadoCliente.Items.Add("RN");
            cBEstadoCliente.Items.Add("RO");
            cBEstadoCliente.Items.Add("RR");
            cBEstadoCliente.Items.Add("RS");
            cBEstadoCliente.Items.Add("SC");
            cBEstadoCliente.Items.Add("SE");
            cBEstadoCliente.Items.Add("SP");
            cBEstadoCliente.Items.Add("TO");


            //DEIXAR UM ESTADO DEFAUT

            cBEstadoCliente.SelectedItem = "SP";

            // Verifica se é um NOVO CADASTRO (código vazio) ou uma ATUALIZAÇÃO
            if (string.IsNullOrEmpty(txtCodigoCliente.Text))
            {
                // ==========================================
                // MODO CADASTRO (Código Vazio)
                // ==========================================
                //lbCliente.Text = "Cadastro de Cliente"; // Opcional: Mudar o título
                checkBoxStatus.Enabled = false; // Não faz sentido inativar na hora de criar
                checkBoxStatus.Checked = true;  // Já nasce ativo

                btCadastrarCliente.Enabled = true;
                btAtualizazCliente.Enabled = false; // Atenção: verifique se o nome do seu botão está escrito assim mesmo
                btExcluirCliente.Enabled = false;

                // Preenche a data de hoje automaticamente para novos cadastros
                txtDataCadastroCliente.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                // ==========================================
                // MODO ATUALIZAÇÃO (Código Preenchido)
                // ==========================================
                //lbCliente.Text = "Atualização de Cliente";
                checkBoxStatus.Enabled = true; // Libera para o usuário poder inativar o cliente

                btCadastrarCliente.Enabled = false;
                btAtualizazCliente.Enabled = true;
                btExcluirCliente.Enabled = true;

            }
        }

        private void btCadastrarCliente_Click(object sender, EventArgs e)
        {
            classCliente cCliente = new classCliente();

            //VERIFCAR CAMPOS OBRIGATORIOS

            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text) || txtNascimento.Text == "  /  /" || maskedTextCPF.Text == "___.___.___-__" || string.IsNullOrWhiteSpace(txtEnderecoCliente.Text) || string.IsNullOrWhiteSpace(txtNumeroCliente.Text) || string.IsNullOrWhiteSpace(txtBairroCliente.Text) || string.IsNullOrWhiteSpace(txtCidadeCliente.Text) || (maskedCelular.Text == "___.___.___-__" || maskedResidencial.Text == "___.___.___-__"))
            {

                MessageBox.Show("Favor Verificar Todos os Campos Obrigatorios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios(); //PINTA OS CAMPOS OBRIGATORIOS
            }
            else // USUARIO PREENCHEU OS CAMPOS
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE O QUE FOI DIGITADO PELO USUARIO
                cCliente.nome = txtNomeCliente.Text;
                cCliente.nome_social = txtNomeSocial.Text;
                cCliente.data_nascimento = Convert.ToDateTime(txtNascimento.Text);
                //SEXO - RADIOBUTON - IF PARA LER ESCOLHA DO USUARIO
                if (rbFeminino.Checked)
                {
                    cCliente.sexo = "F";
                }
                else if (rbMasculino.Checked)
                {
                    cCliente.sexo = "M";
                }
                else
                {
                    cCliente.sexo = "O";
                }
                cCliente.cpf = maskedTextCPF.Text;

                //RG TEM MASCARA CAMPO NÃO OBRIGATÓRIO NO BANCO - PRECISA FAZER UM IF PRA MANDAR VAZIO CASO NÃO SEJA PREENCHIDO
                if (txtRgCliente.Text == "__.___.___ - _")
                {
                    cCliente.rg = "";
                }
                else
                {
                    cCliente.rg = txtRgCliente.Text;
                }

                cCliente.endereco = txtEnderecoCliente.Text;
                cCliente.numero = Convert.ToInt32(txtNumeroCliente.Text);
                cCliente.complemento = txtComplementoCliente.Text;
                cCliente.bairro = txtBairroCliente.Text;
                cCliente.cidade = txtCidadeCliente.Text;
                cCliente.estado = cBEstadoCliente.SelectedItem.ToString();
                //CEP - MASCARA
                if (txtCepCliente.Text == "_____-___")
                {
                    cCliente.cep = "";
                }
                else
                {
                    cCliente.cep = txtCepCliente.Text;
                }
                //RESIDENCIAL
                if (maskedResidencial.Text == "(  )    -    ")
                {
                    cCliente.telefone_residencial = "";
                }
                else
                {
                    cCliente.telefone_residencial = maskedResidencial.Text;
                }
                //CELULAR
                if (maskedCelular.Text == "(  )     -    ")
                {
                    cCliente.telefone_celular = "";
                }
                else
                {
                    cCliente.telefone_celular = maskedCelular.Text;
                }
                cCliente.email = txtEmailCliente.Text;
                


                //CHAMAR O MÉTODO DE CADASTRAR FUNCIONARIO DA CLASSE FUCIONARIO
                int resp = cCliente.CadastrarCliente();

                //MOSTRAR O RESULTADO DO CADASTRO PARA O USUARIO
                // SE CADASTRO REALIZADO COM SUCESSO = 1
                if (resp == 1)
                {
                    MessageBox.Show($"Cliente {cCliente.nome} cadastrado com sucesso", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      Limpar();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar Funcionario!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
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

        private void txtNumeroCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btExcluirCliente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Deseja realmente excluir o Cliente: {txtNomeCliente.Text}?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                classCliente cCliente = new classCliente();
                cCliente.codigo_cliente = Convert.ToInt32(txtCodigoCliente.Text);

                int resp = cCliente.ExcluirCliente();

                if (resp == 1)
                {
                    MessageBox.Show($"Cliente: {txtNomeCliente.Text} excluido com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Erro a excluir Cliente: {txtNomeCliente.Text} !", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btAtualizazCliente_Click(object sender, EventArgs e)
        {
            classCliente cCliente = new classCliente();

            //VERIFCAR CAMPOS OBRIGATORIOS
            // Adaptado para os campos obrigatórios do banco de dados do Cliente
            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text) || txtNascimento.Text == "  /  /" || maskedTextCPF.Text == "___.___.___-__" || string.IsNullOrWhiteSpace(txtEnderecoCliente.Text) || string.IsNullOrWhiteSpace(txtNumeroCliente.Text) || string.IsNullOrWhiteSpace(txtBairroCliente.Text) || string.IsNullOrWhiteSpace(txtCidadeCliente.Text) || string.IsNullOrWhiteSpace(txtEmailCliente.Text) || cBEstadoCliente.Text == "")
            {
                MessageBox.Show("Favor Verificar Todos os Campos Obrigatorios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios(); //PINTA OS CAMPOS OBRIGATORIOS
            }
            else // USUARIO PREENCHEU OS CAMPOS
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE O QUE FOI DIGITADO PELO USUARIO
                cCliente.nome = txtNomeCliente.Text;
                cCliente.nome_social = txtNomeSocial.Text;
                cCliente.data_nascimento = Convert.ToDateTime(txtNascimento.Text);

                //SEXO - RADIOBUTON - IF PARA LER ESCOLHA DO USUARIO
                if (rbFeminino.Checked)
                {
                    cCliente.sexo = "F";
                }
                else if (rbMasculino.Checked)
                {
                    cCliente.sexo = "M";
                }
                else
                {
                    cCliente.sexo = "O";
                }

                //ESTADO CIVIL - REMOVIDO (Não existe na tabela cliente)

                cCliente.cpf = maskedTextCPF.Text;

                //RG TEM MASCARA CAMPO NÃO OBRIGATÓRIO NO BANCO - PRECISA FAZER UM IF PRA MANDAR VAZIO CASO NÃO SEJA PREENCHIDO
                if (txtRgCliente.Text == "__.___.___ - _")
                {
                    cCliente.rg = "";
                }
                else
                {
                    cCliente.rg = txtRgCliente.Text;
                }

                //SALARIO - REMOVIDO (Não existe na tabela cliente)

                cCliente.endereco = txtEnderecoCliente.Text;
                cCliente.numero = Convert.ToInt32(txtNumeroCliente.Text);
                cCliente.complemento = txtComplementoCliente.Text;
                cCliente.bairro = txtBairroCliente.Text;
                cCliente.cidade = txtCidadeCliente.Text;
                cCliente.estado = cBEstadoCliente.Text; // COMBOBOX SEMPRE PRECISA CONVERTER (Aqui usando .Text conforme correção anterior)

                //CEP - MASCARA
                if (txtCepCliente.Text == "_____-___")
                {
                    cCliente.cep = "";
                }
                else
                {
                    cCliente.cep = txtCepCliente.Text;
                }

                //RESIDENCIAL
                if (maskedResidencial.Text == "(  )    -    ")
                {
                    cCliente.telefone_residencial = "";
                }
                else
                {
                    cCliente.telefone_residencial = maskedResidencial.Text;
                }

                //CELULAR
                if (maskedCelular.Text == "(  )     -    ")
                {
                    cCliente.telefone_celular = "";
                }
                else
                {
                    cCliente.telefone_celular = maskedCelular.Text;
                }

                cCliente.email = txtEmailCliente.Text;

                //USUARIO, SENHA, TIPO DE ACESSO, FOTO E CARGO - REMOVIDOS (Não existem na tabela cliente)

                //ALTERAÇÕES DO BOTÃO ATUALIZAR/////////////////////////////

                //CARREGAR CÓDIGO DO CLIENTE CADASTRADO
                cCliente.codigo_cliente = Convert.ToInt32(txtCodigoCliente.Text);

                //STATUS 
                if (checkBoxStatus.Checked)
                {
                    cCliente.status = 1;
                }
                else
                {
                    cCliente.status = 0;
                }

                //CHAMAR O MÉTODO DE ATUALIZAR CLIENTE DA CLASSE CLIENTE
                int resp = cCliente.AtualizarCliente();

                //MOSTRAR O RESULTADO DO CADASTRO PARA O USUARIO
                // SE ATUALIZAÇÃO REALIZADA COM SUCESSO = 1
                if (resp == 1)
                {
                    MessageBox.Show($"Cliente {cCliente.nome} atualizado com sucesso!", "IOT Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar Cliente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void txtCepCliente_Leave(object sender, EventArgs e)
        {
            // Limpa a máscara para pegar apenas os números
            string cep = txtCepCliente.Text.Replace("-", "").Replace(" ", "").Trim();

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
                        txtEnderecoCliente.Text = resultado.logradouro;
                        txtBairroCliente.Text = resultado.bairro;
                        txtCidadeCliente.Text = resultado.localidade;
                        cBEstadoCliente.Text = resultado.uf;

                        // Joga o cursor piscando direto para o campo de número da casa
                        txtNumeroCliente.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar o CEP: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

