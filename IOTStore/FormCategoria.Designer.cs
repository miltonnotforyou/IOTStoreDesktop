
namespace IOTStore
{
    partial class FormCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCategoria));
            this.btSairCategoria = new System.Windows.Forms.Button();
            this.btExcluirCategoria = new System.Windows.Forms.Button();
            this.lbCadastroCargo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.maskedDataCadastro = new System.Windows.Forms.MaskedTextBox();
            this.txtCodigoCategoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomeCategoria = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCategoriaObservacao = new System.Windows.Forms.TextBox();
            this.btCadastrarCategoria = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btAtualizarCategoria = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSairCategoria
            // 
            this.btSairCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btSairCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSairCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSairCategoria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btSairCategoria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btSairCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btSairCategoria.Image")));
            this.btSairCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSairCategoria.Location = new System.Drawing.Point(345, 340);
            this.btSairCategoria.Name = "btSairCategoria";
            this.btSairCategoria.Size = new System.Drawing.Size(108, 47);
            this.btSairCategoria.TabIndex = 1;
            this.btSairCategoria.Text = "     Sair";
            this.btSairCategoria.UseVisualStyleBackColor = false;
            this.btSairCategoria.Click += new System.EventHandler(this.btSairCategoria_Click_1);
            // 
            // btExcluirCategoria
            // 
            this.btExcluirCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btExcluirCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluirCategoria.Enabled = false;
            this.btExcluirCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcluirCategoria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btExcluirCategoria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btExcluirCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btExcluirCategoria.Image")));
            this.btExcluirCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExcluirCategoria.Location = new System.Drawing.Point(231, 340);
            this.btExcluirCategoria.Name = "btExcluirCategoria";
            this.btExcluirCategoria.Size = new System.Drawing.Size(108, 46);
            this.btExcluirCategoria.TabIndex = 11;
            this.btExcluirCategoria.Text = "      Excluir";
            this.btExcluirCategoria.UseVisualStyleBackColor = false;
            this.btExcluirCategoria.Click += new System.EventHandler(this.btExcluirCategoria_Click_1);
            // 
            // lbCadastroCargo
            // 
            this.lbCadastroCargo.AutoSize = true;
            this.lbCadastroCargo.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCadastroCargo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbCadastroCargo.Location = new System.Drawing.Point(291, -69);
            this.lbCadastroCargo.Name = "lbCadastroCargo";
            this.lbCadastroCargo.Size = new System.Drawing.Size(233, 34);
            this.lbCadastroCargo.TabIndex = 8;
            this.lbCadastroCargo.Text = "Cadastro Cargo";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(25, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(407, 62);
            this.panel3.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.maskedDataCadastro);
            this.panel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(25, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 49);
            this.panel2.TabIndex = 6;
            // 
            // maskedDataCadastro
            // 
            this.maskedDataCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.maskedDataCadastro.Enabled = false;
            this.maskedDataCadastro.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.maskedDataCadastro.Location = new System.Drawing.Point(187, 9);
            this.maskedDataCadastro.Mask = "00/00/0000";
            this.maskedDataCadastro.Name = "maskedDataCadastro";
            this.maskedDataCadastro.Size = new System.Drawing.Size(120, 26);
            this.maskedDataCadastro.TabIndex = 8;
            this.maskedDataCadastro.ValidatingType = typeof(System.DateTime);
            // 
            // txtCodigoCategoria
            // 
            this.txtCodigoCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.txtCodigoCategoria.Enabled = false;
            this.txtCodigoCategoria.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoCategoria.Location = new System.Drawing.Point(43, 33);
            this.txtCodigoCategoria.Name = "txtCodigoCategoria";
            this.txtCodigoCategoria.Size = new System.Drawing.Size(128, 26);
            this.txtCodigoCategoria.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(44, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "*Código Categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(209, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "*Data Cadastro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(360, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "*Status";
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Checked = true;
            this.checkBoxStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStatus.Enabled = false;
            this.checkBoxStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxStatus.Location = new System.Drawing.Point(359, 36);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(67, 23);
            this.checkBoxStatus.TabIndex = 5;
            this.checkBoxStatus.Text = "Ativo";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(35, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "*Nome da Categoria";
            // 
            // txtNomeCategoria
            // 
            this.txtNomeCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.txtNomeCategoria.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCategoria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNomeCategoria.Location = new System.Drawing.Point(39, 131);
            this.txtNomeCategoria.Name = "txtNomeCategoria";
            this.txtNomeCategoria.Size = new System.Drawing.Size(381, 26);
            this.txtNomeCategoria.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtCategoriaObservacao);
            this.panel4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(25, 193);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(407, 96);
            this.panel4.TabIndex = 12;
            // 
            // txtCategoriaObservacao
            // 
            this.txtCategoriaObservacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.txtCategoriaObservacao.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoriaObservacao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCategoriaObservacao.Location = new System.Drawing.Point(14, 11);
            this.txtCategoriaObservacao.Multiline = true;
            this.txtCategoriaObservacao.Name = "txtCategoriaObservacao";
            this.txtCategoriaObservacao.Size = new System.Drawing.Size(381, 76);
            this.txtCategoriaObservacao.TabIndex = 0;
            // 
            // btCadastrarCategoria
            // 
            this.btCadastrarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btCadastrarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCadastrarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCadastrarCategoria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btCadastrarCategoria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btCadastrarCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btCadastrarCategoria.Image")));
            this.btCadastrarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCadastrarCategoria.Location = new System.Drawing.Point(6, 339);
            this.btCadastrarCategoria.Name = "btCadastrarCategoria";
            this.btCadastrarCategoria.Size = new System.Drawing.Size(105, 47);
            this.btCadastrarCategoria.TabIndex = 0;
            this.btCadastrarCategoria.Text = "    Cadastrar";
            this.btCadastrarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCadastrarCategoria.UseVisualStyleBackColor = false;
            this.btCadastrarCategoria.Click += new System.EventHandler(this.btCadastrarCategoria_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(35, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Observação";
            // 
            // btAtualizarCategoria
            // 
            this.btAtualizarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btAtualizarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAtualizarCategoria.Enabled = false;
            this.btAtualizarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAtualizarCategoria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btAtualizarCategoria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btAtualizarCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btAtualizarCategoria.Image")));
            this.btAtualizarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAtualizarCategoria.Location = new System.Drawing.Point(117, 340);
            this.btAtualizarCategoria.Name = "btAtualizarCategoria";
            this.btAtualizarCategoria.Size = new System.Drawing.Size(108, 46);
            this.btAtualizarCategoria.TabIndex = 10;
            this.btAtualizarCategoria.Text = "Atualizar";
            this.btAtualizarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAtualizarCategoria.UseVisualStyleBackColor = false;
            this.btAtualizarCategoria.Click += new System.EventHandler(this.btAtualizarCategoria_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(93, 292);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(320, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Todos os campos com * são obrigatórios!";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.btExcluirCategoria);
            this.panel1.Controls.Add(this.btSairCategoria);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btAtualizarCategoria);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btCadastrarCategoria);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.txtNomeCategoria);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.checkBoxStatus);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigoCategoria);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(-1, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 432);
            this.panel1.TabIndex = 13;
            // 
            // FormCategoria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(462, 471);
            this.Controls.Add(this.lbCadastroCargo);
            this.Controls.Add(this.panel1);
            this.Name = "FormCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Categoria";
            this.Load += new System.EventHandler(this.FormCategoria_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btSairCategoria;
        private System.Windows.Forms.Button btExcluirCategoria;
        private System.Windows.Forms.Label lbCadastroCargo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.MaskedTextBox maskedDataCadastro;
        public System.Windows.Forms.TextBox txtCodigoCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNomeCategoria;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.TextBox txtCategoriaObservacao;
        private System.Windows.Forms.Button btCadastrarCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btAtualizarCategoria;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
    }
}