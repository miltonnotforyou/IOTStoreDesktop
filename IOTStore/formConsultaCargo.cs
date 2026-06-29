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
    public partial class formConsultaCargo : MaterialSkin.Controls.MaterialForm
    {
        public formConsultaCargo()
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

        private void formConsultaCargo_Load(object sender, EventArgs e)
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
            // Esconde os campos inúteis que vieram copiados do Funcionario
            
            gbDataCadastro.Visible = true;


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
            classCargo cCargo = new classCargo();
            string filtro = cbOpcoes.SelectedItem.ToString();

            switch (filtro)
            {
                case "Status":
                    if (rbInativo.Checked)
                    {
                        dgvCargo.DataSource = cCargo.ConsultaCargoStatus(0);
                    }
                    else
                    {
                        dgvCargo.DataSource = cCargo.ConsultaCargoStatus(1);
                    }
                    break;
                case "Data de Cadastro":
                    // Passa a propriedade .Value dos seus DateTimePickers para o método da classe
                    dgvCargo.DataSource = cCargo.ConsultaCargoDataCadastro(dtpDataInicial.Value, dtpDataFinal.Value);
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
                            dgvCargo.DataSource = cCargo.ConsultaCargoNomeInicio(txtNome.Text);
                        }
                        else
                        {
                            dgvCargo.DataSource = cCargo.ConsultaCargoNomeContem(txtNome.Text);
                        }
                    }
                    break;
            }

            FormatarGrid();
        }

       
        private void dgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Deseja alterar ou excluir o cargo selecionado?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classCargo cCargo = new classCargo();

                // Abre o formulário formCargo (ajuste se a sua tela de cadastro tiver outro nome exato)
                formCargo fCargo = new formCargo();

                // Pega o ID da linha selecionada (assumindo que o código_cargo seja a coluna 0)
                cCargo.DadosCargo(Convert.ToInt32(dgvCargo.SelectedRows[0].Cells[0].Value));

                // Preenche os dados no formulário de cadastro
                fCargo.txtCodigoCargo.Text = cCargo.codigo_cargo.ToString();
                fCargo.txtNomeCargo.Text = cCargo.nome.ToString();
                fCargo.txtCargoObservacao.Text = cCargo.observacao.ToString();
                fCargo.maskedDataCadastro.Text = cCargo.data_cadastro.ToString("dd/MM/yyyy");

                if (cCargo.status == 1)
                {
                    fCargo.checkBoxStatus.Checked = true;
                }
                else
                {
                    fCargo.checkBoxStatus.Checked = false;
                }

                // Exibe o form para edição
                fCargo.ShowDialog();

                // Atualiza a tabela após a edição ser concluída
                btPesquisar_Click(this, new EventArgs());
            }
        }

        private void FormatarGrid()
        {
            // 1. Renomear os cabeçalhos (se a coluna existir no grid)
            if (dgvCargo.Columns.Contains("codigo_cargo"))
                dgvCargo.Columns["codigo_cargo"].HeaderText = "Código";

            if (dgvCargo.Columns.Contains("nome"))
                dgvCargo.Columns["nome"].HeaderText = "Nome do Cargo";

            if (dgvCargo.Columns.Contains("observacao"))
                dgvCargo.Columns["observacao"].HeaderText = "Observação";

            if (dgvCargo.Columns.Contains("status"))
                dgvCargo.Columns["status"].HeaderText = "Status";

            if (dgvCargo.Columns.Contains("data_cadastro"))
                dgvCargo.Columns["data_cadastro"].HeaderText = "Data Cadastro";

            // 2. Estilizar o cabeçalho (Cor, Fonte e Alinhamento)
            // OBRIGATÓRIO: Desativar os estilos visuais do Windows para a cor de fundo funcionar
            dgvCargo.EnableHeadersVisualStyles = false;

            // Cor de fundo do cabeçalho (usando a mesma cor azul escuro do seu form)
            dgvCargo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);

            // Cor da letra
            dgvCargo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Deixar a letra em Negrito e mudar a fonte
            dgvCargo.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);

            // Centralizar o texto do cabeçalho
            dgvCargo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ====================================================================
            // 3. ESTILIZAR AS LINHAS (REMOVER A LINHA BRANCA)
            // ====================================================================

            // Define a cor de fundo escuro e a fonte branca como padrão para todas as linhas
            dgvCargo.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvCargo.DefaultCellStyle.ForeColor = Color.White;

            // Define a MESMA cor de fundo para as linhas alternadas (removendo o zebrado)
            dgvCargo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvCargo.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // (Opcional) Cor da linha quando você clica nela para selecionar
            dgvCargo.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvCargo.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}
