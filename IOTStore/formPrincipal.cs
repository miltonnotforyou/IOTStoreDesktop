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
    public partial class formPrincipal : MaterialSkin.Controls.MaterialForm
    {
        public formPrincipal()
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
            // Ajustes visuais para integrar o MenuStrip ao tema Material
            menuStrip1.BackColor = Color.FromArgb(55, 71, 79); // Aproximação do BlueGrey800
            menuStrip1.ForeColor = Color.White;
            menuStrip1.RenderMode = ToolStripRenderMode.System; // Remove o relevo padrão do Windows
                                                                
            // Ele percorre todos os itens do menu (Cadastros, Consultas, etc.)
            foreach (ToolStripMenuItem itemMenu in menuStrip1.Items)
            {
                // Pinta o fundo da caixinha de opções (submenu) com a cor escura
                itemMenu.DropDown.BackColor = Color.FromArgb(55, 71, 79);

                // Garante que a letra das opções fique branca
                itemMenu.DropDown.ForeColor = Color.White;
            }

            categriasToolStripMenuItem.Click += new System.EventHandler(this.categriasToolStripMenuItem_Click);
        }

       
        private void menuCadCargo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formCargo>().Count() > 0)
            {
                MessageBox.Show("Cadastro de Cargos já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formCargo obj_formCadCargo = new formCargo();
                obj_formCadCargo.MdiParent = this;
                obj_formCadCargo.Show();
            }
        }

        private void categriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormCategoria>().Count() > 0)
            {
                MessageBox.Show("Cadastro de Categorias já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FormCategoria obj_formCategoria = new FormCategoria();
                obj_formCategoria.MdiParent = this;
                obj_formCategoria.Show();
            }
        }

        private void timerPrincipal_Tick(object sender, EventArgs e)
        {
            statusLbData.Text = DateTime.Now.ToShortDateString();
            statusLbHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void menuCadFuncionario_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formFuncionario>().Count() > 0)
            {
                MessageBox.Show("Cadastro de Funcionários já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formFuncionario obj_formCadFuncionario = new formFuncionario();
                obj_formCadFuncionario.MdiParent = this;
                obj_formCadFuncionario.Show();
            }
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o sistema?", "Sistema IOT Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formMarca>().Count() > 0)
            {
                MessageBox.Show("Cadastro de Marcas já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formMarca obj_formMarca = new formMarca();
                obj_formMarca.MdiParent = this;
                obj_formMarca.Show();
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formCliente>().Count() > 0)
            {
                MessageBox.Show("Cadastro de Clientes já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formCliente obj_formCliente = new formCliente();
                obj_formCliente.MdiParent = this;
                obj_formCliente.Show();
            }
        }

        // ABRE O CADASTRO DE PRODUTOS
        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void produtosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formProdutocs>().Count() > 0)
            {
                MessageBox.Show("Cadastro de Produtos já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formProdutocs obj_formProduto = new formProdutocs();
                obj_formProduto.MdiParent = this;
                obj_formProduto.Show();
            }
        }

        private void formConsultaFuncionario_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaFuncionario>().Count() > 0)
            {
                MessageBox.Show("Cadastro de Funcionarios já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaFuncionario obj_formConsultaFuncionario = new formConsultaFuncionario();
                obj_formConsultaFuncionario.MdiParent = this;
                obj_formConsultaFuncionario.Show();
            }
        }

      
        private void formPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaCargo>().Count() > 0)
            {
                MessageBox.Show("Consulta de Cargos já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaCargo obj_formConsultaCargo = new formConsultaCargo();
                obj_formConsultaCargo.MdiParent = this;
                obj_formConsultaCargo.Show();
            }
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaCategoria>().Count() > 0)
            {
                MessageBox.Show("Consulta de Categorias já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaCategoria obj_formConsultaCategoria = new formConsultaCategoria();
                obj_formConsultaCategoria.MdiParent = this;
                obj_formConsultaCategoria.Show();
            }
        }

        private void marcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaMarca>().Count() > 0)
            {
                MessageBox.Show("Consulta de Marcas já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaMarca obj_formConsultaMarca = new formConsultaMarca();
                obj_formConsultaMarca.MdiParent = this;
                obj_formConsultaMarca.Show();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaCliente>().Count() > 0)
            {
                MessageBox.Show("Consulta de Clientes já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaCliente obj_formConsultaCliente = new formConsultaCliente();
                obj_formConsultaCliente.MdiParent = this;
                obj_formConsultaCliente.Show();
            }
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaProduto>().Count() > 0)
            {
                MessageBox.Show("Consulta de Produtos já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaProduto obj_formConsultaProduto = new formConsultaProduto();
                obj_formConsultaProduto.MdiParent = this;
                obj_formConsultaProduto.Show();
            }
        }

       
        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelFuncionario>().Count() > 0)
            {
                MessageBox.Show("Consulta de Produtos já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelFuncionario obj_formRelFuncionario = new formRelFuncionario();
                obj_formRelFuncionario.MdiParent = this;
                obj_formRelFuncionario.Show();
            }
        }

        private void cargosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelCargo>().Count() > 0)
            {
                MessageBox.Show("Relatório de Cargos já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelCargo obj_formRelCargo = new formRelCargo();
                obj_formRelCargo.MdiParent = this;
                obj_formRelCargo.Show();
            }
        }

        private void categoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelCategoria>().Count() > 0)
            {
                MessageBox.Show("Relatório de Categorias já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelCategoria obj_formRelCategoria = new formRelCategoria();
                obj_formRelCategoria.MdiParent = this;
                obj_formRelCategoria.Show();
            }

        }

        private void marcasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelMarca>().Count() > 0)
            {
                MessageBox.Show("Relatório de Marcas já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelMarca obj_formRelMarca = new formRelMarca();
                obj_formRelMarca.MdiParent = this;
                obj_formRelMarca.Show();
            }
        }

        private void clientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelCliente>().Count() > 0)
            {
                MessageBox.Show("Relatório de Clientes já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelCliente obj_formRelCliente = new formRelCliente();
                obj_formRelCliente.MdiParent = this;
                obj_formRelCliente.Show();
            }
        }

        private void produtosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelProduto>().Count() > 0)
            {
                MessageBox.Show("Relatório de Produtos já está aberto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelProduto obj_formRelProduto = new formRelProduto();
                obj_formRelProduto.MdiParent = this;
                obj_formRelProduto.Show();
            }
        }
    }
}