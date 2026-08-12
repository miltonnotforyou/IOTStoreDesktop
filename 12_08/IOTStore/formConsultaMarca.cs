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
    public partial class formConsultaMarca : MaterialSkin.Controls.MaterialForm
    {
        public formConsultaMarca()
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

        private void formConsultaMarca_Load(object sender, EventArgs e)
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
            classMarca cMarca = new classMarca();
            string filtro = cbOpcoes.SelectedItem.ToString();

            switch (filtro)
            {
                case "Status":
                    if (rbInativo.Checked)
                    {
                        dgvMarca.DataSource = cMarca.ConsultaMarcaStatus(0);
                    }
                    else
                    {
                        dgvMarca.DataSource = cMarca.ConsultaMarcaStatus(1);
                    }
                    break;
                case "Data de Cadastro":
                    // Passa a propriedade .Value dos seus DateTimePickers para o método da classe
                    dgvMarca.DataSource = cMarca.ConsultaMarcaDataCadastro(dtpDataInicial.Value, dtpDataFinal.Value);
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
                            dgvMarca.DataSource = cMarca.ConsultaMarcaNomeInicio(txtNome.Text);
                        }
                        else
                        {
                            dgvMarca.DataSource = cMarca.ConsultaMarcaNomeContem(txtNome.Text);
                        }
                    }
                    break;
            }

            FormatarGrid();
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Deseja alterar ou excluir a Marca selecionada?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classMarca cMarca = new classMarca();

                // Abre o formulário formMarca (ajuste se a sua tela de cadastro tiver outro nome exato)
                formMarca fMarca = new formMarca();

                // Pega o ID da linha selecionada (assumindo que o código_cargo seja a coluna 0)
                cMarca.DadosMarca(Convert.ToInt32(dgvMarca.SelectedRows[0].Cells[0].Value));

                // Preenche os dados no formulário de Categoria
                fMarca.txtCodigoMarca.Text = cMarca.codigo_marca.ToString();
                fMarca.txtNomeMarca.Text = cMarca.nome.ToString();
                fMarca.txtMarcaObservacao.Text = cMarca.observacao.ToString();
                fMarca.maskedDataCadastro.Text = cMarca.data_cadastro.ToString("dd/MM/yyyy");

                if (cMarca.status == 1)
                {
                    fMarca.checkBoxStatus.Checked = true;
                }
                else
                {
                    fMarca.checkBoxStatus.Checked = false;
                }

                // Exibe o form para edição
                fMarca.ShowDialog();

                // Atualiza a tabela após a edição ser concluída
                btPesquisar_Click(this, new EventArgs());
            }
        }

        private void FormatarGrid()
        {
            // 1. Renomear os cabeçalhos (se a coluna existir no grid)
            if (dgvMarca.Columns.Contains("codigo_marca"))
                dgvMarca.Columns["codigo_marca"].HeaderText = "Código";

            if (dgvMarca.Columns.Contains("nome"))
                dgvMarca.Columns["nome"].HeaderText = "Nome da Marca";

            if (dgvMarca.Columns.Contains("observacao"))
                dgvMarca.Columns["observacao"].HeaderText = "Observação";

            if (dgvMarca.Columns.Contains("data_cadastro"))
                dgvMarca.Columns["data_cadastro"].HeaderText = "Data Cadastro";

            // 2. Estilizar o cabeçalho (Cor, Fonte e Alinhamento)
            // OBRIGATÓRIO: Desativar os estilos visuais do Windows para a cor de fundo funcionar
            dgvMarca.EnableHeadersVisualStyles = false;

            // Cor de fundo do cabeçalho (usando a mesma cor azul escuro do seu form)
            dgvMarca.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);

            // Cor da letra
            dgvMarca.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Deixar a letra em Negrito e mudar a fonte
            dgvMarca.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);

            // Centralizar o texto do cabeçalho
            dgvMarca.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ====================================================================
            // ESTILIZAR AS LINHAS (REMOVER A LINHA BRANCA)
            // ====================================================================

            // Define a cor de fundo escuro e a fonte branca como padrão para todas as linhas
            dgvMarca.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvMarca.DefaultCellStyle.ForeColor = Color.White;

            // Define a MESMA cor de fundo para as linhas alternadas (removendo o zebrado)
            dgvMarca.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvMarca.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Cor da linha ao selecionar
            dgvMarca.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvMarca.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}
