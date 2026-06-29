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
    public partial class formMarca : MaterialSkin.Controls.MaterialForm
    {
        public formMarca()
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

        private void btSairMarca_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCadastrarMarca_Click(object sender, EventArgs e)
        {
            classMarca cMarca = new classMarca();

            if (string.IsNullOrWhiteSpace(txtNomeMarca.Text))
            {
                MessageBox.Show("Favor verificar os campos obrigatórios", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeMarca.BackColor = Color.Aquamarine;
                txtNomeMarca.Focus();
            }
            else
            {
                cMarca.nome = txtNomeMarca.Text;
                cMarca.observacao = txtNomeMarca.Text;

                int resp = cMarca.CadastrarMarca();

                if (resp == 1)
                {
                    MessageBox.Show($"Marca: {cMarca.nome} Cadastrada com Sucesso!", "IOT Store!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomeMarca.Clear();
                    txtNomeMarca.Clear();
                    txtNomeMarca.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao Cadastrar Categoria!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeMarca.BackColor = Color.Aquamarine;
                    txtNomeMarca.Focus();
                }
            }
        }

        private void formMarca_Load(object sender, EventArgs e)
        {
            // Verifica se é um NOVO CADASTRO (código vazio) ou uma ATUALIZAÇÃO
            if (string.IsNullOrEmpty(txtCodigoMarca.Text))
            {
                // MODO CADASTRO
                maskedDataCadastro.Text = DateTime.Now.ToShortDateString();

                checkBoxStatus.Checked = true;
                checkBoxStatus.Enabled = false; // Não faz sentido inativar no momento de criar

                btCadastrarMarca.Enabled = true;
                btAtualizarMarca.Enabled = false;
                btExcluirMarca.Enabled = false;
            }
            else
            {
                // MODO ATUALIZAÇÃO (Veio da tela de consulta)
                checkBoxStatus.Enabled = true; // Libera para o usuário mudar o status

                btCadastrarMarca.Enabled = false;
                btAtualizarMarca.Enabled = true;
                btExcluirMarca.Enabled = true;
            }
        }

        private void btAtualizarMarca_Click(object sender, EventArgs e)
        {
            // 1. Validar campos obrigatórios
            if (string.IsNullOrWhiteSpace(txtNomeMarca.Text))
            {
                MessageBox.Show("Favor verificar os campos obrigatórios", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeMarca.BackColor = Color.Aquamarine;
                txtNomeMarca.Focus();
                return; // Para a execução aqui
            }

            // 2. Instanciar a classe e preencher as propriedades
            classMarca cMarca = new classMarca();
            cMarca.codigo_marca = Convert.ToInt32(txtCodigoMarca.Text);
            cMarca.nome = txtNomeMarca.Text;
            cMarca.observacao = txtMarcaObservacao.Text;

            // LÓGICA DO STATUS: Se estiver marcado recebe 1 (Ativo), se não recebe 0 (Inativo)
            if (checkBoxStatus.Checked)
            {
                cMarca.status = 1;
            }
            else
            {
                cMarca.status = 0;
            }

            // 3. Chamar o método de atualização
            int resp = cMarca.AtualizarMarca();

            if (resp == 1)
            {
                MessageBox.Show($"Marca: {cMarca.nome} atualizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha a tela e volta para a consulta automaticamente
            }
            else
            {
                MessageBox.Show("Erro ao atualizar Marca.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluirMarca_Click(object sender, EventArgs e)
        {
            // Pergunta de segurança
            if (MessageBox.Show("Deseja realmente excluir esta Marca? Esta ação não pode ser desfeita.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                classMarca cMarca = new classMarca();
                cMarca.codigo_marca = Convert.ToInt32(txtCodigoMarca.Text);

                int resp = cMarca.ExcluirMarca();

                if (resp == 1)
                {
                    MessageBox.Show("Marca excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha a tela
                }
                else
                {
                    // O erro mais comum na exclusão é o cargo já estar vinculado a um funcionário (Chave Estrangeira)
                    MessageBox.Show("Erro ao excluir Marca. Verifique se existem produtos vinculados a ele.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
        
    
