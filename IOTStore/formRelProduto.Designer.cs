
namespace IOTStore
{
    partial class formRelProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formRelProduto));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.cbTipoRel = new System.Windows.Forms.ComboBox();
            this.gbOpcao = new System.Windows.Forms.GroupBox();
            this.rbInativo = new System.Windows.Forms.RadioButton();
            this.rbAtivo = new System.Windows.Forms.RadioButton();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.gbCategoria = new System.Windows.Forms.GroupBox();
            this.rbZero = new System.Windows.Forms.RadioButton();
            this.rbBaixo = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.gbEstoque = new System.Windows.Forms.GroupBox();
            this.rbPromoInativo = new System.Windows.Forms.RadioButton();
            this.rbPromoAtivo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPrecoMax = new System.Windows.Forms.TextBox();
            this.txtPrecoMin = new System.Windows.Forms.TextBox();
            this.gbPreço = new System.Windows.Forms.GroupBox();
            this.gbMarca = new System.Windows.Forms.GroupBox();
            this.gbConsFuncionario = new System.Windows.Forms.GroupBox();
            this.gbDataAdmissao = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.btSair = new System.Windows.Forms.Button();
            this.btGerarRelatorio = new System.Windows.Forms.Button();
            this.rptvProduto = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.classProdutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            this.gbOpcao.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.gbCategoria.SuspendLayout();
            this.gbEstoque.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbPreço.SuspendLayout();
            this.gbMarca.SuspendLayout();
            this.gbConsFuncionario.SuspendLayout();
            this.gbDataAdmissao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classProdutoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProduto
            // 
            this.dgvProduto.AllowUserToAddRows = false;
            this.dgvProduto.AllowUserToDeleteRows = false;
            this.dgvProduto.AllowUserToResizeColumns = false;
            this.dgvProduto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.dgvProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProduto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.dgvProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduto.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgvProduto.Location = new System.Drawing.Point(345, 53);
            this.dgvProduto.MultiSelect = false;
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.ReadOnly = true;
            this.dgvProduto.RowHeadersVisible = false;
            this.dgvProduto.RowHeadersWidth = 51;
            this.dgvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduto.Size = new System.Drawing.Size(695, 506);
            this.dgvProduto.TabIndex = 57;
            // 
            // cbTipoRel
            // 
            this.cbTipoRel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoRel.FormattingEnabled = true;
            this.cbTipoRel.Location = new System.Drawing.Point(4, 25);
            this.cbTipoRel.Name = "cbTipoRel";
            this.cbTipoRel.Size = new System.Drawing.Size(320, 27);
            this.cbTipoRel.TabIndex = 8;
            this.cbTipoRel.SelectedIndexChanged += new System.EventHandler(this.cbOpcoes_SelectedIndexChanged);
            // 
            // gbOpcao
            // 
            this.gbOpcao.Controls.Add(this.cbTipoRel);
            this.gbOpcao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOpcao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbOpcao.Location = new System.Drawing.Point(5, 14);
            this.gbOpcao.Name = "gbOpcao";
            this.gbOpcao.Size = new System.Drawing.Size(337, 65);
            this.gbOpcao.TabIndex = 4;
            this.gbOpcao.TabStop = false;
            this.gbOpcao.Text = "Escolha uma Opção de Relatório";
            // 
            // rbInativo
            // 
            this.rbInativo.AutoSize = true;
            this.rbInativo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInativo.Location = new System.Drawing.Point(72, 27);
            this.rbInativo.Name = "rbInativo";
            this.rbInativo.Size = new System.Drawing.Size(78, 23);
            this.rbInativo.TabIndex = 2;
            this.rbInativo.Text = "Inativo";
            this.rbInativo.UseVisualStyleBackColor = true;
            // 
            // rbAtivo
            // 
            this.rbAtivo.AutoSize = true;
            this.rbAtivo.Checked = true;
            this.rbAtivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAtivo.Location = new System.Drawing.Point(10, 27);
            this.rbAtivo.Name = "rbAtivo";
            this.rbAtivo.Size = new System.Drawing.Size(66, 23);
            this.rbAtivo.TabIndex = 1;
            this.rbAtivo.TabStop = true;
            this.rbAtivo.Text = "Ativo";
            this.rbAtivo.UseVisualStyleBackColor = true;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.rbInativo);
            this.gbStatus.Controls.Add(this.rbAtivo);
            this.gbStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbStatus.Location = new System.Drawing.Point(6, 144);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(162, 65);
            this.gbStatus.TabIndex = 102;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status:";
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(4, 22);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(142, 27);
            this.cbMarca.TabIndex = 50;
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(4, 22);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(152, 27);
            this.cbCategoria.TabIndex = 50;
            // 
            // gbCategoria
            // 
            this.gbCategoria.Controls.Add(this.cbCategoria);
            this.gbCategoria.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCategoria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbCategoria.Location = new System.Drawing.Point(173, 81);
            this.gbCategoria.Name = "gbCategoria";
            this.gbCategoria.Size = new System.Drawing.Size(169, 60);
            this.gbCategoria.TabIndex = 105;
            this.gbCategoria.TabStop = false;
            this.gbCategoria.Text = "Categoria";
            // 
            // rbZero
            // 
            this.rbZero.AutoSize = true;
            this.rbZero.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbZero.Location = new System.Drawing.Point(236, 26);
            this.rbZero.Name = "rbZero";
            this.rbZero.Size = new System.Drawing.Size(61, 23);
            this.rbZero.TabIndex = 3;
            this.rbZero.Text = "Zero";
            this.rbZero.UseVisualStyleBackColor = true;
            // 
            // rbBaixo
            // 
            this.rbBaixo.AutoSize = true;
            this.rbBaixo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBaixo.Location = new System.Drawing.Point(127, 26);
            this.rbBaixo.Name = "rbBaixo";
            this.rbBaixo.Size = new System.Drawing.Size(71, 23);
            this.rbBaixo.TabIndex = 2;
            this.rbBaixo.Text = "Baixo";
            this.rbBaixo.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNormal.Location = new System.Drawing.Point(11, 26);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(82, 23);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // gbEstoque
            // 
            this.gbEstoque.Controls.Add(this.rbZero);
            this.gbEstoque.Controls.Add(this.rbBaixo);
            this.gbEstoque.Controls.Add(this.rbNormal);
            this.gbEstoque.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEstoque.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbEstoque.Location = new System.Drawing.Point(6, 215);
            this.gbEstoque.Name = "gbEstoque";
            this.gbEstoque.Size = new System.Drawing.Size(336, 65);
            this.gbEstoque.TabIndex = 103;
            this.gbEstoque.TabStop = false;
            this.gbEstoque.Text = "Estoque:";
            // 
            // rbPromoInativo
            // 
            this.rbPromoInativo.AutoSize = true;
            this.rbPromoInativo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPromoInativo.Location = new System.Drawing.Point(67, 26);
            this.rbPromoInativo.Name = "rbPromoInativo";
            this.rbPromoInativo.Size = new System.Drawing.Size(78, 23);
            this.rbPromoInativo.TabIndex = 2;
            this.rbPromoInativo.Text = "Inativo";
            this.rbPromoInativo.UseVisualStyleBackColor = true;
            // 
            // rbPromoAtivo
            // 
            this.rbPromoAtivo.AutoSize = true;
            this.rbPromoAtivo.Checked = true;
            this.rbPromoAtivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPromoAtivo.Location = new System.Drawing.Point(3, 26);
            this.rbPromoAtivo.Name = "rbPromoAtivo";
            this.rbPromoAtivo.Size = new System.Drawing.Size(66, 23);
            this.rbPromoAtivo.TabIndex = 1;
            this.rbPromoAtivo.TabStop = true;
            this.rbPromoAtivo.Text = "Ativo";
            this.rbPromoAtivo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPromoInativo);
            this.groupBox2.Controls.Add(this.rbPromoAtivo);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(193, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 65);
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Promoção:";
            // 
            // txtPrecoMax
            // 
            this.txtPrecoMax.Location = new System.Drawing.Point(198, 25);
            this.txtPrecoMax.Name = "txtPrecoMax";
            this.txtPrecoMax.Size = new System.Drawing.Size(116, 26);
            this.txtPrecoMax.TabIndex = 1;
            // 
            // txtPrecoMin
            // 
            this.txtPrecoMin.Location = new System.Drawing.Point(44, 25);
            this.txtPrecoMin.Name = "txtPrecoMin";
            this.txtPrecoMin.Size = new System.Drawing.Size(116, 26);
            this.txtPrecoMin.TabIndex = 0;
            // 
            // gbPreço
            // 
            this.gbPreço.Controls.Add(this.label2);
            this.gbPreço.Controls.Add(this.label1);
            this.gbPreço.Controls.Add(this.txtPrecoMax);
            this.gbPreço.Controls.Add(this.txtPrecoMin);
            this.gbPreço.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPreço.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbPreço.Location = new System.Drawing.Point(8, 286);
            this.gbPreço.Name = "gbPreço";
            this.gbPreço.Size = new System.Drawing.Size(336, 65);
            this.gbPreço.TabIndex = 9;
            this.gbPreço.TabStop = false;
            this.gbPreço.Text = "Faixa de Preço";
            // 
            // gbMarca
            // 
            this.gbMarca.Controls.Add(this.cbMarca);
            this.gbMarca.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMarca.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbMarca.Location = new System.Drawing.Point(5, 81);
            this.gbMarca.Name = "gbMarca";
            this.gbMarca.Size = new System.Drawing.Size(158, 60);
            this.gbMarca.TabIndex = 112;
            this.gbMarca.TabStop = false;
            this.gbMarca.Text = "Marca:";
            // 
            // gbConsFuncionario
            // 
            this.gbConsFuncionario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.gbConsFuncionario.Controls.Add(this.gbDataAdmissao);
            this.gbConsFuncionario.Controls.Add(this.btSair);
            this.gbConsFuncionario.Controls.Add(this.btGerarRelatorio);
            this.gbConsFuncionario.Controls.Add(this.gbPreço);
            this.gbConsFuncionario.Controls.Add(this.groupBox2);
            this.gbConsFuncionario.Controls.Add(this.gbEstoque);
            this.gbConsFuncionario.Controls.Add(this.gbCategoria);
            this.gbConsFuncionario.Controls.Add(this.gbMarca);
            this.gbConsFuncionario.Controls.Add(this.gbStatus);
            this.gbConsFuncionario.Controls.Add(this.gbOpcao);
            this.gbConsFuncionario.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConsFuncionario.Location = new System.Drawing.Point(1, 53);
            this.gbConsFuncionario.Name = "gbConsFuncionario";
            this.gbConsFuncionario.Size = new System.Drawing.Size(356, 506);
            this.gbConsFuncionario.TabIndex = 56;
            this.gbConsFuncionario.TabStop = false;
            // 
            // gbDataAdmissao
            // 
            this.gbDataAdmissao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.gbDataAdmissao.Controls.Add(this.label6);
            this.gbDataAdmissao.Controls.Add(this.label8);
            this.gbDataAdmissao.Controls.Add(this.dtpDataFinal);
            this.gbDataAdmissao.Controls.Add(this.dtpDataInicial);
            this.gbDataAdmissao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.gbDataAdmissao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbDataAdmissao.Location = new System.Drawing.Point(7, 357);
            this.gbDataAdmissao.Name = "gbDataAdmissao";
            this.gbDataAdmissao.Size = new System.Drawing.Size(337, 73);
            this.gbDataAdmissao.TabIndex = 142;
            this.gbDataAdmissao.TabStop = false;
            this.gbDataAdmissao.Text = "Data de Cadastro:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 19);
            this.label6.TabIndex = 46;
            this.label6.Text = "Até:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 19);
            this.label8.TabIndex = 46;
            this.label8.Text = "De:";
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(199, 28);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(116, 26);
            this.dtpDataFinal.TabIndex = 1;
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(45, 28);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(116, 26);
            this.dtpDataInicial.TabIndex = 0;
            // 
            // btSair
            // 
            this.btSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSair.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSair.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btSair.Image = ((System.Drawing.Image)(resources.GetObject("btSair.Image")));
            this.btSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSair.Location = new System.Drawing.Point(219, 435);
            this.btSair.Name = "btSair";
            this.btSair.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btSair.Size = new System.Drawing.Size(125, 43);
            this.btSair.TabIndex = 136;
            this.btSair.Text = "Sair";
            this.btSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSair.UseVisualStyleBackColor = false;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btGerarRelatorio
            // 
            this.btGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btGerarRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGerarRelatorio.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGerarRelatorio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btGerarRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btGerarRelatorio.Image")));
            this.btGerarRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGerarRelatorio.Location = new System.Drawing.Point(7, 435);
            this.btGerarRelatorio.Name = "btGerarRelatorio";
            this.btGerarRelatorio.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btGerarRelatorio.Size = new System.Drawing.Size(169, 43);
            this.btGerarRelatorio.TabIndex = 135;
            this.btGerarRelatorio.Text = "     Gerar Relatório";
            this.btGerarRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGerarRelatorio.UseVisualStyleBackColor = false;
            this.btGerarRelatorio.Click += new System.EventHandler(this.btGerarRelatorio_Click);
            // 
            // rptvProduto
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.classProdutoBindingSource;
            this.rptvProduto.LocalReport.DataSources.Add(reportDataSource1);
            this.rptvProduto.LocalReport.ReportEmbeddedResource = "IOTStore.reportProduto.rdlc";
            this.rptvProduto.Location = new System.Drawing.Point(362, 62);
            this.rptvProduto.Name = "rptvProduto";
            this.rptvProduto.ServerReport.BearerToken = null;
            this.rptvProduto.Size = new System.Drawing.Size(605, 464);
            this.rptvProduto.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 19);
            this.label1.TabIndex = 47;
            this.label1.Text = "De:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 48;
            this.label2.Text = "Até:";
            // 
            // classProdutoBindingSource
            // 
            this.classProdutoBindingSource.DataSource = typeof(IOTStore.classProduto);
            // 
            // formRelProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 550);
            this.Controls.Add(this.gbConsFuncionario);
            this.Controls.Add(this.rptvProduto);
            this.Controls.Add(this.dgvProduto);
            this.Name = "formRelProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Produtos";
            this.Load += new System.EventHandler(this.formRelProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            this.gbOpcao.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.gbCategoria.ResumeLayout(false);
            this.gbEstoque.ResumeLayout(false);
            this.gbEstoque.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbPreço.ResumeLayout(false);
            this.gbPreço.PerformLayout();
            this.gbMarca.ResumeLayout(false);
            this.gbConsFuncionario.ResumeLayout(false);
            this.gbDataAdmissao.ResumeLayout(false);
            this.gbDataAdmissao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classProdutoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.ComboBox cbTipoRel;
        private System.Windows.Forms.GroupBox gbOpcao;
        private System.Windows.Forms.RadioButton rbInativo;
        private System.Windows.Forms.RadioButton rbAtivo;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.GroupBox gbCategoria;
        private System.Windows.Forms.RadioButton rbZero;
        private System.Windows.Forms.RadioButton rbBaixo;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.GroupBox gbEstoque;
        private System.Windows.Forms.RadioButton rbPromoInativo;
        private System.Windows.Forms.RadioButton rbPromoAtivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPrecoMax;
        private System.Windows.Forms.TextBox txtPrecoMin;
        private System.Windows.Forms.GroupBox gbPreço;
        private System.Windows.Forms.GroupBox gbMarca;
        private System.Windows.Forms.GroupBox gbConsFuncionario;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Button btGerarRelatorio;
        private Microsoft.Reporting.WinForms.ReportViewer rptvProduto;
        private System.Windows.Forms.BindingSource classProdutoBindingSource;
        private System.Windows.Forms.GroupBox gbDataAdmissao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}