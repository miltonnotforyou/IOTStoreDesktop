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
    public partial class formCargo : MaterialSkin.Controls.MaterialForm
    {
        public formCargo()
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

        private void btSairCargo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAtualizarCadastro_Click(object sender, EventArgs e)
        {
            // 1. Validar campos obrigatórios
            if (string.IsNullOrWhiteSpace(txtNomeCargo.Text))
            {
                MessageBox.Show("Favor verificar os campos obrigatórios", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeCargo.BackColor = Color.Aquamarine;
                txtNomeCargo.Focus();
                return; // Para a execução aqui
            }

            // 2. Instanciar a classe e preencher as propriedades
            classCargo cCargo = new classCargo();
            cCargo.codigo_cargo = Convert.ToInt32(txtCodigoCargo.Text);
            cCargo.nome = txtNomeCargo.Text;
            cCargo.observacao = txtCargoObservacao.Text;

            // LÓGICA DO STATUS: Se estiver marcado recebe 1 (Ativo), se não recebe 0 (Inativo)
            if (checkBoxStatus.Checked)
            {
                cCargo.status = 1;
            }
            else
            {
                cCargo.status = 0;
            }

            // 3. Chamar o método de atualização
            int resp = cCargo.AtualizarCargo();

            if (resp == 1)
            {
                MessageBox.Show($"Cargo: {cCargo.nome} atualizado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha a tela e volta para a consulta automaticamente
            }
            else
            {
                MessageBox.Show("Erro ao atualizar cargo.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluirCargo_Click(object sender, EventArgs e)
        {
            // Pergunta de segurança
            if (MessageBox.Show("Deseja realmente excluir este cargo? Esta ação não pode ser desfeita.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                classCargo cCargo = new classCargo();
                cCargo.codigo_cargo = Convert.ToInt32(txtCodigoCargo.Text);

                int resp = cCargo.ExcluirCargo();

                if (resp == 1)
                {
                    MessageBox.Show("Cargo excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha a tela
                }
                else
                {
                    // O erro mais comum na exclusão é o cargo já estar vinculado a um funcionário (Chave Estrangeira)
                    MessageBox.Show("Erro ao excluir cargo. Verifique se existem funcionários vinculados a ele.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btCadastrarCargo_Click(object sender, EventArgs e)
        {
            //CRIAR OBJETO DA CLASSE CARGO PRAR USAR PROPRIEDADES E MÉTODOS DA CLASSE
            classCargo cCargo = new classCargo();

            //VERIFCIAR SE TODOS OS CAMPOS OBRIGATÓRIOS FORAM PREENCHIDOS

            if (string.IsNullOrWhiteSpace(txtNomeCargo.Text))
            {
                MessageBox.Show("Favor verificar os campos obrigtórios", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                txtNomeCargo.BackColor = Color.Aquamarine;
                txtNomeCargo.Focus();
            }
            else
            {
                // PASSAR PARA AS PROPRIEDADES DA CLASSE O CONTEUDO DE TODOS OS ELEMENTOS QUE O USUARIO PODE PREENCHER

                cCargo.nome = txtNomeCargo.Text;
                cCargo.observacao = txtCargoObservacao.Text;

                //CHAMAR MÉTODO CADASTRAR DA CLASSE CARGO

                int resp = cCargo.CadastrarCargo();

                //EXIBIR MENSAGEM PARA O USUARIO
                //SE DEU CERTO

                if (resp == 1) 
                {
                    MessageBox.Show($"Cargo: {cCargo.nome} Cadastrado com Sucesso!", "IOT Store!", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    txtNomeCargo.Clear();
                    txtCargoObservacao.Clear();
                    txtNomeCargo.Focus();

                }
                else 
                {
                    MessageBox.Show("Erro ao Cadastrar Cargo", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeCargo.BackColor = Color.Aquamarine;
                    txtNomeCargo.Focus();
                }
            }


        }

        private void formCargo_Load(object sender, EventArgs e)
        {
            // Verifica se é um NOVO CADASTRO (código vazio) ou uma ATUALIZAÇÃO
            if (string.IsNullOrEmpty(txtCodigoCargo.Text))
            {
                // MODO CADASTRO
                maskedDataCadastro.Text = DateTime.Now.ToShortDateString();

                checkBoxStatus.Checked = true;
                checkBoxStatus.Enabled = false; // Não faz sentido inativar no momento de criar

                btCadastrarCargo.Enabled = true;
                btAtualizarCadastro.Enabled = false;
                btExcluirCargo.Enabled = false;
            }
            else
            {
                // MODO ATUALIZAÇÃO (Veio da tela de consulta)
                checkBoxStatus.Enabled = true; // Libera para o usuário mudar o status

                btCadastrarCargo.Enabled = false;
                btAtualizarCadastro.Enabled = true;
                btExcluirCargo.Enabled = true;
            }
        }

       
    }
}
