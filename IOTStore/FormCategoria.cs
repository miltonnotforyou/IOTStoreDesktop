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
    public partial class FormCategoria : MaterialSkin.Controls.MaterialForm
    {
        public FormCategoria()
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

        private void btSairCategoria_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAtualizarCadastro_Click(object sender, EventArgs e)
        {

        }

        private void btExcluirCategoria_Click(object sender, EventArgs e)
        {

        }

       

        private void btSairCategoria_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCadastrarCategoria_Click(object sender, EventArgs e)
        {
            classCategoria cCategoria = new classCategoria();

            if (string.IsNullOrWhiteSpace(txtNomeCategoria.Text))
            {
                MessageBox.Show("Favor verificar os campos obrigatórios", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeCategoria.BackColor = Color.Aquamarine;
                txtNomeCategoria.Focus();
            }
            else
            {
                cCategoria.nome = txtNomeCategoria.Text;
                cCategoria.observacao = txtCategoriaObservacao.Text;

                int resp = cCategoria.CadastraCategoria();

                if (resp == 1)
                {
                    MessageBox.Show($"Categoria: {cCategoria.nome} Cadastrada com Sucesso!", "IOT Store!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomeCategoria.Clear();
                    txtCategoriaObservacao.Clear();
                    txtNomeCategoria.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao Cadastrar Categoria!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeCategoria.BackColor = Color.Aquamarine;
                    txtNomeCategoria.Focus();
                }
            }
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            // Verifica se é um NOVO CADASTRO (código vazio) ou uma ATUALIZAÇÃO
            if (string.IsNullOrEmpty(txtCodigoCategoria.Text))
            {
                // MODO CADASTRO
                maskedDataCadastro.Text = DateTime.Now.ToShortDateString();

                checkBoxStatus.Checked = true;
                checkBoxStatus.Enabled = false; // Não faz sentido inativar no momento de criar

                btCadastrarCategoria.Enabled = true;
                btAtualizarCategoria.Enabled = false;
                btExcluirCategoria.Enabled = false;
            }
            else
            {
                // MODO ATUALIZAÇÃO (Veio da tela de consulta)
                checkBoxStatus.Enabled = true; // Libera para o usuário mudar o status

                btCadastrarCategoria.Enabled = false;
                btAtualizarCategoria.Enabled = true;
                btExcluirCategoria.Enabled = true;
            }

        }

        private void btAtualizarCategoria_Click(object sender, EventArgs e)
        {
           
                // 1. Validar campos obrigatórios
                if (string.IsNullOrWhiteSpace(txtNomeCategoria.Text))
                {
                    MessageBox.Show("Favor verificar os campos obrigatórios", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeCategoria.BackColor = Color.Aquamarine;
                    txtNomeCategoria.Focus();
                    return; // Para a execução aqui
                }

            // 2. Instanciar a classe e preencher as propriedades
                classCategoria cCategoria = new classCategoria();
                cCategoria.codigo_categoria = Convert.ToInt32(txtCodigoCategoria.Text);
                cCategoria.nome = txtNomeCategoria.Text;
                cCategoria.observacao = txtCategoriaObservacao.Text;

                // LÓGICA DO STATUS: Se estiver marcado recebe 1 (Ativo), se não recebe 0 (Inativo)
                if (checkBoxStatus.Checked)
                {
                    cCategoria.status = 1;
                }
                else
                {
                    cCategoria.status = 0;
                }

                // 3. Chamar o método de atualização
                int resp = cCategoria.AtualizarCategoria();

                if (resp == 1)
                {
                    MessageBox.Show($"Categoria: {cCategoria.nome} atualizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha a tela e volta para a consulta automaticamente
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar Categoria.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void btExcluirCategoria_Click_1(object sender, EventArgs e)
        {
           
                // Pergunta de segurança
                if (MessageBox.Show("Deseja realmente excluir esta Categoria? Esta ação não pode ser desfeita.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                classCategoria cCategoria = new classCategoria();
                cCategoria.codigo_categoria = Convert.ToInt32(txtCodigoCategoria.Text);

                    int resp = cCategoria.ExcluirCategoria();

                    if (resp == 1)
                    {
                        MessageBox.Show("Categoria excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Fecha a tela
                    }
                    else
                    {
                        // O erro mais comum na exclusão é o cargo já estar vinculado a um funcionário (Chave Estrangeira)
                        MessageBox.Show("Erro ao excluir Categoria. Verifique se existem produtos vinculados a ele.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
        }
    }
}