// ============================================================
//  DEPENDÊNCIA: MaterialSkin.2 (NuGet)
//  Install-Package MaterialSkin.2
//
//  ATENÇÃO: em formPrincipal.cs altere apenas a herança:
//    public partial class formPrincipal : MaterialSkin.Controls.MaterialForm
// ============================================================

using MaterialSkin;
using MaterialSkin.Controls;

namespace IOTStore
{
    partial class formPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.categriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.formConsultaFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.cargosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.statusPrincipal = new System.Windows.Forms.StatusStrip();
            this.statusLbData = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLbHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLbMensagem = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerPrincipal = new System.Windows.Forms.Timer(this.components);
            this.clientesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastros,
            this.menuConsultas,
            this.menuRelatorios,
            this.menuVendas,
            this.menuSair});
            this.menuStrip1.Location = new System.Drawing.Point(3, 64);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 7, 0, 7);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(866, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuPrincipal";
            // 
            // menuCadastros
            // 
            this.menuCadastros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.menuCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadCargo,
            this.menuCadFuncionario,
            this.categriasToolStripMenuItem,
            this.marcasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem});
            this.menuCadastros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCadastros.ForeColor = System.Drawing.Color.White;
            this.menuCadastros.Image = ((System.Drawing.Image)(resources.GetObject("menuCadastros.Image")));
            this.menuCadastros.Name = "menuCadastros";
            this.menuCadastros.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.menuCadastros.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuCadastros.Size = new System.Drawing.Size(150, 32);
            this.menuCadastros.Text = "Cadastros";
            // 
            // menuCadCargo
            // 
            this.menuCadCargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.menuCadCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCadCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.menuCadCargo.Name = "menuCadCargo";
            this.menuCadCargo.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuCadCargo.Size = new System.Drawing.Size(183, 22);
            this.menuCadCargo.Text = "Cargo";
            this.menuCadCargo.Click += new System.EventHandler(this.menuCadCargo_Click);
            // 
            // menuCadFuncionario
            // 
            this.menuCadFuncionario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.menuCadFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCadFuncionario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.menuCadFuncionario.Name = "menuCadFuncionario";
            this.menuCadFuncionario.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuCadFuncionario.Size = new System.Drawing.Size(183, 22);
            this.menuCadFuncionario.Text = "Funcionários";
            this.menuCadFuncionario.Click += new System.EventHandler(this.menuCadFuncionario_Click);
            // 
            // categriasToolStripMenuItem
            // 
            this.categriasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.categriasToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categriasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.categriasToolStripMenuItem.Name = "categriasToolStripMenuItem";
            this.categriasToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.categriasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.categriasToolStripMenuItem.Text = "Categorias";
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.marcasToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marcasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.marcasToolStripMenuItem.Text = "Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.clientesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.produtosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click_1);
            // 
            // menuConsultas
            // 
            this.menuConsultas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.menuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formConsultaFuncionario,
            this.cargosToolStripMenuItem,
            this.categoriasToolStripMenuItem,
            this.marcasToolStripMenuItem1,
            this.clientesToolStripMenuItem1,
            this.produtosToolStripMenuItem1});
            this.menuConsultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuConsultas.ForeColor = System.Drawing.Color.White;
            this.menuConsultas.Image = ((System.Drawing.Image)(resources.GetObject("menuConsultas.Image")));
            this.menuConsultas.Name = "menuConsultas";
            this.menuConsultas.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.menuConsultas.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.menuConsultas.Size = new System.Drawing.Size(149, 32);
            this.menuConsultas.Text = "Consultas";
            // 
            // formConsultaFuncionario
            // 
            this.formConsultaFuncionario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.formConsultaFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formConsultaFuncionario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.formConsultaFuncionario.Name = "formConsultaFuncionario";
            this.formConsultaFuncionario.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.formConsultaFuncionario.Size = new System.Drawing.Size(183, 22);
            this.formConsultaFuncionario.Text = "Funcionários";
            this.formConsultaFuncionario.Click += new System.EventHandler(this.formConsultaFuncionario_Click);
            // 
            // cargosToolStripMenuItem
            // 
            this.cargosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.cargosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cargosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.cargosToolStripMenuItem.Name = "cargosToolStripMenuItem";
            this.cargosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.cargosToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cargosToolStripMenuItem.Text = "Cargos ";
            this.cargosToolStripMenuItem.Click += new System.EventHandler(this.cargosToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.categoriasToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.categoriasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem1
            // 
            this.marcasToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.marcasToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.marcasToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.marcasToolStripMenuItem1.Name = "marcasToolStripMenuItem1";
            this.marcasToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.marcasToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.marcasToolStripMenuItem1.Text = "Marcas";
            this.marcasToolStripMenuItem1.Click += new System.EventHandler(this.marcasToolStripMenuItem1_Click);
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.clientesToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.clientesToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // produtosToolStripMenuItem1
            // 
            this.produtosToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.produtosToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.produtosToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.produtosToolStripMenuItem1.Name = "produtosToolStripMenuItem1";
            this.produtosToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.produtosToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.produtosToolStripMenuItem1.Text = "Produtos";
            this.produtosToolStripMenuItem1.Click += new System.EventHandler(this.produtosToolStripMenuItem1_Click);
            // 
            // menuRelatorios
            // 
            this.menuRelatorios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.menuRelatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionáriosToolStripMenuItem,
            this.cargosToolStripMenuItem1,
            this.categoriasToolStripMenuItem1,
            this.marcasToolStripMenuItem2,
            this.clientesToolStripMenuItem2,
            this.produtosToolStripMenuItem2});
            this.menuRelatorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuRelatorios.ForeColor = System.Drawing.Color.White;
            this.menuRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("menuRelatorios.Image")));
            this.menuRelatorios.Name = "menuRelatorios";
            this.menuRelatorios.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.menuRelatorios.Size = new System.Drawing.Size(151, 32);
            this.menuRelatorios.Text = "Relatórios";
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.funcionáriosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.funcionáriosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.funcionáriosToolStripMenuItem_Click);
            // 
            // cargosToolStripMenuItem1
            // 
            this.cargosToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.cargosToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cargosToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cargosToolStripMenuItem1.Name = "cargosToolStripMenuItem1";
            this.cargosToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.cargosToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.cargosToolStripMenuItem1.Text = "Cargos";
            this.cargosToolStripMenuItem1.Click += new System.EventHandler(this.cargosToolStripMenuItem1_Click);
            // 
            // categoriasToolStripMenuItem1
            // 
            this.categoriasToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.categoriasToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.categoriasToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.categoriasToolStripMenuItem1.Name = "categoriasToolStripMenuItem1";
            this.categoriasToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.categoriasToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.categoriasToolStripMenuItem1.Text = "Categorias";
            this.categoriasToolStripMenuItem1.Click += new System.EventHandler(this.categoriasToolStripMenuItem1_Click);
            // 
            // marcasToolStripMenuItem2
            // 
            this.marcasToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.marcasToolStripMenuItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.marcasToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.marcasToolStripMenuItem2.Name = "marcasToolStripMenuItem2";
            this.marcasToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.marcasToolStripMenuItem2.Size = new System.Drawing.Size(212, 22);
            this.marcasToolStripMenuItem2.Text = "Marcas";
            this.marcasToolStripMenuItem2.Click += new System.EventHandler(this.marcasToolStripMenuItem2_Click);
            // 
            // menuVendas
            // 
            this.menuVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.menuVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuVendas.ForeColor = System.Drawing.Color.White;
            this.menuVendas.Image = ((System.Drawing.Image)(resources.GetObject("menuVendas.Image")));
            this.menuVendas.Name = "menuVendas";
            this.menuVendas.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.menuVendas.Size = new System.Drawing.Size(129, 32);
            this.menuVendas.Text = "Vendas";
            // 
            // menuSair
            // 
            this.menuSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.menuSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(128)))));
            this.menuSair.Image = ((System.Drawing.Image)(resources.GetObject("menuSair.Image")));
            this.menuSair.Name = "menuSair";
            this.menuSair.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.menuSair.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuSair.Size = new System.Drawing.Size(94, 32);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // statusPrincipal
            // 
            this.statusPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.statusPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbData,
            this.statusLbHora,
            this.statusLbMensagem});
            this.statusPrincipal.Location = new System.Drawing.Point(3, 451);
            this.statusPrincipal.Name = "statusPrincipal";
            this.statusPrincipal.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusPrincipal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusPrincipal.Size = new System.Drawing.Size(866, 27);
            this.statusPrincipal.SizingGrip = false;
            this.statusPrincipal.TabIndex = 2;
            this.statusPrincipal.Text = "statusStrip1";
            // 
            // statusLbData
            // 
            this.statusLbData.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statusLbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.statusLbData.Name = "statusLbData";
            this.statusLbData.Padding = new System.Windows.Forms.Padding(10, 0, 6, 0);
            this.statusLbData.Size = new System.Drawing.Size(63, 22);
            this.statusLbData.Text = "Data";
            // 
            // statusLbHora
            // 
            this.statusLbHora.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statusLbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.statusLbHora.Name = "statusLbHora";
            this.statusLbHora.Padding = new System.Windows.Forms.Padding(10, 0, 6, 0);
            this.statusLbHora.Size = new System.Drawing.Size(65, 22);
            this.statusLbHora.Text = "Hora";
            // 
            // statusLbMensagem
            // 
            this.statusLbMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbMensagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(230)))));
            this.statusLbMensagem.Name = "statusLbMensagem";
            this.statusLbMensagem.Size = new System.Drawing.Size(734, 22);
            this.statusLbMensagem.Spring = true;
            this.statusLbMensagem.Text = "Bem Vindo ao Sistema IOT Store";
            this.statusLbMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerPrincipal
            // 
            this.timerPrincipal.Enabled = true;
            this.timerPrincipal.Tick += new System.EventHandler(this.timerPrincipal_Tick);
            // 
            // clientesToolStripMenuItem2
            // 
            this.clientesToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.clientesToolStripMenuItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.clientesToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientesToolStripMenuItem2.Name = "clientesToolStripMenuItem2";
            this.clientesToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.clientesToolStripMenuItem2.Size = new System.Drawing.Size(212, 22);
            this.clientesToolStripMenuItem2.Text = "Clientes";
            this.clientesToolStripMenuItem2.Click += new System.EventHandler(this.clientesToolStripMenuItem2_Click);
            // 
            // produtosToolStripMenuItem2
            // 
            this.produtosToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.produtosToolStripMenuItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.produtosToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.produtosToolStripMenuItem2.Name = "produtosToolStripMenuItem2";
            this.produtosToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
            this.produtosToolStripMenuItem2.Size = new System.Drawing.Size(212, 22);
            this.produtosToolStripMenuItem2.Text = "Produtos";
            this.produtosToolStripMenuItem2.Click += new System.EventHandler(this.produtosToolStripMenuItem2_Click);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(872, 481);
            this.Controls.Add(this.statusPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formPrincipal";
            this.Text = "IOT Store";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusPrincipal.ResumeLayout(false);
            this.statusPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCadastros;
        private System.Windows.Forms.ToolStripMenuItem menuCadCargo;
        private System.Windows.Forms.ToolStripMenuItem menuCadFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuConsultas;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorios;
        private System.Windows.Forms.ToolStripMenuItem menuVendas;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.StatusStrip statusPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel statusLbMensagem;
        private System.Windows.Forms.ToolStripStatusLabel statusLbData;
        private System.Windows.Forms.ToolStripStatusLabel statusLbHora;
        private System.Windows.Forms.Timer timerPrincipal;
        private System.Windows.Forms.ToolStripMenuItem categriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formConsultaFuncionario;
        private System.Windows.Forms.ToolStripMenuItem cargosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem2;
    }
}