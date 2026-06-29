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
    public partial class formConsultaCategoria : MaterialSkin.Controls.MaterialForm
    {
        public formConsultaCategoria()
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

        private void formConsultaCategoria_Load(object sender, EventArgs e)
        {
            // Carregar as opções corretas para Cargo
            cbOpcoes.Items.Clear();
            cbOpcoes.Items.Add("Nome");
            cbOpcoes.Items.Add("Status");
            cbOpcoes.Items.Add("Data de Cadastro");
            cbOpcoes.SelectedIndex = 0;
        }

        private void cbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // HABILITAR/DESABILITAR COMPONENTES CORRETAMENTE
            if (cbOpcoes.SelectedIndex == 0) // Nome
            {
                gbTipoPesquisa.Enabled = true;
                gbNome.Enabled = true;
                gbStatus.Enabled = false;
                gbDataCadastro.Enabled = false; // Desliga a data
                txtNome.Focus();
            }
            else if (cbOpcoes.SelectedIndex == 1) // Status
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbStatus.Enabled = true;
                gbDataCadastro.Enabled = false; // Desliga a data
            }
            else if (cbOpcoes.SelectedIndex == 2) // Data de Cadastro
            {
                gbTipoPesquisa.Enabled = false;
                gbNome.Enabled = false;
                gbStatus.Enabled = false; // Desliga o status
                gbDataCadastro.Enabled = true; // Liga a data
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            classCategoria cCategoria = new classCategoria();
            string filtro = cbOpcoes.SelectedItem.ToString();

            switch (filtro)
            {
                case "Status":
                    if (rbInativo.Checked)
                    {
                        dgvCategoria.DataSource = cCategoria.ConsultaCategoriaStatus(0);
                    }
                    else
                    {
                        dgvCategoria.DataSource = cCategoria.ConsultaCategoriaStatus(1);
                    }
                    break;
                case "Data de Cadastro":
                    // Passa a propriedade .Value dos seus DateTimePickers para o método da classe
                    dgvCategoria.DataSource = cCategoria.ConsultaCategoriaDataCadastro(dtpDataInicial.Value, dtpDataFinal.Value);
                    break;

                default: // Nome
                    if (string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        MessageBox.Show("Favor informar um nome!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gbNome.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        if (rbInicio.Checked)
                        {
                            dgvCategoria.DataSource = cCategoria.ConsultaCategoriaNomeInicio(txtNome.Text);
                        }
                        else
                        {
                            dgvCategoria.DataSource = cCategoria.ConsultaCategoriaNomeContem(txtNome.Text);
                        }
                    }
                    break;
            }

            FormatarGrid();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Deseja alterar ou excluir a categoria selecionada?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classCategoria cCategoria = new classCategoria();

                // Abre o formulário formCategoria (ajuste se a sua tela de cadastro tiver outro nome exato)
                FormCategoria fCategoria = new FormCategoria();

                // Pega o ID da linha selecionada (assumindo que o código_cargo seja a coluna 0)
                cCategoria.DadosCategoria(Convert.ToInt32(dgvCategoria.SelectedRows[0].Cells[0].Value));

                // Preenche os dados no formulário de Categoria
                fCategoria.txtCodigoCategoria.Text = cCategoria.codigo_categoria.ToString();
                fCategoria.txtNomeCategoria.Text = cCategoria.nome.ToString();
                fCategoria.txtCategoriaObservacao.Text = cCategoria.observacao.ToString();
                fCategoria.maskedDataCadastro.Text = cCategoria.data_cadastro.ToString("dd/MM/yyyy");

                if (cCategoria.status == 1)
                {
                    fCategoria.checkBoxStatus.Checked = true;
                }
                else
                {
                    fCategoria.checkBoxStatus.Checked = false;
                }

                // Exibe o form para edição
                fCategoria.ShowDialog();

                // Atualiza a tabela após a edição ser concluída
                btPesquisar_Click(this, new EventArgs());
            }
        }

        private void FormatarGrid()
        {
            // 1. Renomear os cabeçalhos (se a coluna existir no grid)
            if (dgvCategoria.Columns.Contains("codigo_categoria"))
                dgvCategoria.Columns["codigo_categoria"].HeaderText = "Código";

            if (dgvCategoria.Columns.Contains("nome"))
                dgvCategoria.Columns["nome"].HeaderText = "Nome da Categoria";

            if (dgvCategoria.Columns.Contains("observacao"))
                dgvCategoria.Columns["observacao"].HeaderText = "Observação";

            if (dgvCategoria.Columns.Contains("status"))
                dgvCategoria.Columns["status"].HeaderText = "Status";

            if (dgvCategoria.Columns.Contains("data_cadastro"))
                dgvCategoria.Columns["data_cadastro"].HeaderText = "Data Cadastro";

            // 2. Estilizar o cabeçalho (Cor, Fonte e Alinhamento)
            // OBRIGATÓRIO: Desativar os estilos visuais do Windows para a cor de fundo funcionar
            dgvCategoria.EnableHeadersVisualStyles = false;

            // Cor de fundo do cabeçalho (usando a mesma cor azul escuro do seu form)
            dgvCategoria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);

            // Cor da letra
            dgvCategoria.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Deixar a letra em Negrito e mudar a fonte
            dgvCategoria.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);

            // Centralizar o texto do cabeçalho
            dgvCategoria.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ====================================================================
            // ESTILIZAR AS LINHAS (REMOVER A LINHA BRANCA)
            // ====================================================================

            // Define a cor de fundo escuro e a fonte branca como padrão para todas as linhas
            dgvCategoria.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvCategoria.DefaultCellStyle.ForeColor = Color.White;

            // Define a MESMA cor de fundo para as linhas alternadas (removendo o zebrado)
            dgvCategoria.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvCategoria.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Cor da linha ao selecionar
            dgvCategoria.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvCategoria.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbInicio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gbDataCadastro_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtpDataFinal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDataInicial_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbInativo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbAtivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbContem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gbStatus_Enter(object sender, EventArgs e)
        {

        }

        private void gbOpcao_Enter(object sender, EventArgs e)
        {

        }

        private void gbConsCargo_Enter(object sender, EventArgs e)
        {

        }

        private void gbNome_Enter(object sender, EventArgs e)
        {

        }

        private void gbTipoPesquisa_Enter(object sender, EventArgs e)
        {

        }
    }
}
