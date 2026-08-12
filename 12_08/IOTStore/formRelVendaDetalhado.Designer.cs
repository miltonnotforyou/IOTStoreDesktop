
namespace IOTStore
{
    partial class formRelVendaDetalhado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formRelVendaDetalhado));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.classRelVendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btGerarRelatorio = new System.Windows.Forms.Button();
            this.gbTipoRel = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoRel = new System.Windows.Forms.ComboBox();
            this.gbDataVenda = new System.Windows.Forms.GroupBox();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.gbFuncionario = new System.Windows.Forms.GroupBox();
            this.cbFuncionario = new System.Windows.Forms.ComboBox();
            this.rptvVendaDetalhado = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.classRelVendaBindingSource)).BeginInit();
            this.gbTipoRel.SuspendLayout();
            this.gbDataVenda.SuspendLayout();
            this.gbCliente.SuspendLayout();
            this.gbFuncionario.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // classRelVendaBindingSource
            // 
            this.classRelVendaBindingSource.DataSource = typeof(IOTStore.classRelVenda);
            // 
            // btGerarRelatorio
            // 
            this.btGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btGerarRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGerarRelatorio.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGerarRelatorio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btGerarRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btGerarRelatorio.Image")));
            this.btGerarRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGerarRelatorio.Location = new System.Drawing.Point(48, 387);
            this.btGerarRelatorio.Name = "btGerarRelatorio";
            this.btGerarRelatorio.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btGerarRelatorio.Size = new System.Drawing.Size(172, 49);
            this.btGerarRelatorio.TabIndex = 136;
            this.btGerarRelatorio.Text = "     Gerar Relatório";
            this.btGerarRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGerarRelatorio.UseVisualStyleBackColor = false;
            this.btGerarRelatorio.Click += new System.EventHandler(this.btGerarRelatorio_Click);
            // 
            // gbTipoRel
            // 
            this.gbTipoRel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.gbTipoRel.Controls.Add(this.label2);
            this.gbTipoRel.Controls.Add(this.cbTipoRel);
            this.gbTipoRel.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipoRel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbTipoRel.Location = new System.Drawing.Point(13, 5);
            this.gbTipoRel.Name = "gbTipoRel";
            this.gbTipoRel.Size = new System.Drawing.Size(239, 90);
            this.gbTipoRel.TabIndex = 137;
            this.gbTipoRel.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 19);
            this.label2.TabIndex = 131;
            this.label2.Text = "Selecione o Tipo de Relatório";
            // 
            // cbTipoRel
            // 
            this.cbTipoRel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoRel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoRel.FormattingEnabled = true;
            this.cbTipoRel.Location = new System.Drawing.Point(7, 49);
            this.cbTipoRel.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoRel.Name = "cbTipoRel";
            this.cbTipoRel.Size = new System.Drawing.Size(215, 27);
            this.cbTipoRel.TabIndex = 130;
            this.cbTipoRel.SelectedIndexChanged += new System.EventHandler(this.cbTipoRel_SelectedIndexChanged);
            // 
            // gbDataVenda
            // 
            this.gbDataVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.gbDataVenda.Controls.Add(this.dtpDataFinal);
            this.gbDataVenda.Controls.Add(this.dtpDataInicial);
            this.gbDataVenda.Controls.Add(this.label6);
            this.gbDataVenda.Controls.Add(this.label8);
            this.gbDataVenda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.gbDataVenda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbDataVenda.Location = new System.Drawing.Point(14, 105);
            this.gbDataVenda.Name = "gbDataVenda";
            this.gbDataVenda.Size = new System.Drawing.Size(238, 115);
            this.gbDataVenda.TabIndex = 135;
            this.gbDataVenda.TabStop = false;
            this.gbDataVenda.Text = "Período de Vendas";
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(68, 71);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(116, 26);
            this.dtpDataFinal.TabIndex = 1;
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(67, 28);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(115, 26);
            this.dtpDataInicial.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(31, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 21);
            this.label6.TabIndex = 46;
            this.label6.Text = "Até:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.label8.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(34, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 21);
            this.label8.TabIndex = 46;
            this.label8.Text = "De:";
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.cbCliente);
            this.gbCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbCliente.Location = new System.Drawing.Point(14, 226);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(238, 64);
            this.gbCliente.TabIndex = 140;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Cliente:";
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(4, 22);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(228, 27);
            this.cbCliente.TabIndex = 50;
            // 
            // gbFuncionario
            // 
            this.gbFuncionario.Controls.Add(this.cbFuncionario);
            this.gbFuncionario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFuncionario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbFuncionario.Location = new System.Drawing.Point(13, 296);
            this.gbFuncionario.Name = "gbFuncionario";
            this.gbFuncionario.Size = new System.Drawing.Size(238, 64);
            this.gbFuncionario.TabIndex = 139;
            this.gbFuncionario.TabStop = false;
            this.gbFuncionario.Text = "Funcionário";
            // 
            // cbFuncionario
            // 
            this.cbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuncionario.FormattingEnabled = true;
            this.cbFuncionario.Location = new System.Drawing.Point(4, 22);
            this.cbFuncionario.Name = "cbFuncionario";
            this.cbFuncionario.Size = new System.Drawing.Size(228, 27);
            this.cbFuncionario.TabIndex = 50;
            // 
            // rptvVendaDetalhado
            // 
            this.rptvVendaDetalhado.DocumentMapWidth = 56;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.classRelVendaBindingSource;
            this.rptvVendaDetalhado.LocalReport.DataSources.Add(reportDataSource1);
            this.rptvVendaDetalhado.LocalReport.ReportEmbeddedResource = "IOTStore.reportRelVenda.rdlc";
            this.rptvVendaDetalhado.Location = new System.Drawing.Point(267, 3);
            this.rptvVendaDetalhado.Name = "rptvVendaDetalhado";
            this.rptvVendaDetalhado.ServerReport.BearerToken = null;
            this.rptvVendaDetalhado.Size = new System.Drawing.Size(775, 462);
            this.rptvVendaDetalhado.TabIndex = 141;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.rptvVendaDetalhado);
            this.panel1.Controls.Add(this.gbFuncionario);
            this.panel1.Controls.Add(this.gbCliente);
            this.panel1.Controls.Add(this.gbDataVenda);
            this.panel1.Controls.Add(this.gbTipoRel);
            this.panel1.Controls.Add(this.btGerarRelatorio);
            this.panel1.Location = new System.Drawing.Point(-7, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 635);
            this.panel1.TabIndex = 0;
            // 
            // formRelVendaDetalhado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1041, 543);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formRelVendaDetalhado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Vendas Detalhado";
            this.Load += new System.EventHandler(this.formRelVendaDetalhado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classRelVendaBindingSource)).EndInit();
            this.gbTipoRel.ResumeLayout(false);
            this.gbTipoRel.PerformLayout();
            this.gbDataVenda.ResumeLayout(false);
            this.gbDataVenda.PerformLayout();
            this.gbCliente.ResumeLayout(false);
            this.gbFuncionario.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource classRelVendaBindingSource;
        private System.Windows.Forms.Button btGerarRelatorio;
        private System.Windows.Forms.GroupBox gbTipoRel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbTipoRel;
        private System.Windows.Forms.GroupBox gbDataVenda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.GroupBox gbFuncionario;
        private System.Windows.Forms.ComboBox cbFuncionario;
        private Microsoft.Reporting.WinForms.ReportViewer rptvVendaDetalhado;
        private System.Windows.Forms.Panel panel1;
    }
}