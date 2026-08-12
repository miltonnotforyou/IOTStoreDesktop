using System;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySqlConnector;
using MaterialSkin;
using MaterialSkin.Controls;

namespace IOTStore
{
    public partial class formDashboard : MaterialForm
    {
        // Classe de conexão (classConexao.cs)
        private readonly classConexao conexao = new classConexao();

        // Controles dos cartões de KPI
        private MaterialCard cardFaturamento, cardEstoque, cardClientes, cardPedidos;
        private Label lblFaturamentoValor, lblEstoqueValor, lblClientesValor, lblPedidosValor;

        // Gráficos
        private Chart chartVendas;
        private Chart chartCategorias;

        // Tabela de pedidos recentes
        private DataGridView dgvPedidosRecentes;
        private DataGridView dgvTopVendedores;
        private DataGridView dgvTopClientes;

        public formDashboard() 
        {
            InitializeComponent();

            // Aplicação da mesma paleta de cores utilizada na tela de consulta
            var skinManager = MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500,     // Cor principal 
                Primary.Indigo700,     // Tom mais escuro
                Primary.Indigo300,     // Tom mais claro
                Accent.Pink200,        // Cor de destaque
                TextShade.WHITE        // Texto branco
            );

            MontarLayout();
            CarregarDashboard();
            CarregarTopVendedores();
            CarregarTopClientes();
        }

        private void MontarLayout()
        {
            this.Text = "Painel Administrativo";
            this.WindowState = FormWindowState.Maximized;

            var painelRaiz = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(20)
            };
            painelRaiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 130)); // cartões
            painelRaiz.RowStyles.Add(new RowStyle(SizeType.Percent, 40));  // gráficos
            painelRaiz.RowStyles.Add(new RowStyle(SizeType.Percent, 30));  // pedidos recentes
            painelRaiz.RowStyles.Add(new RowStyle(SizeType.Percent, 30));  // top vendedores / top clientes
            this.Controls.Add(painelRaiz);

            // ---------- LINHA 1: CARTÕES DE METAS ----------
            var painelCartoes = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1
            };
            for (int i = 0; i < 4; i++)
                painelCartoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

            cardFaturamento = CriarCartaoKPI("Faturamento", out lblFaturamentoValor, Color.LightYellow);
            cardEstoque = CriarCartaoKPI("Itens em Estoque", out lblEstoqueValor, Color.LightCoral);
            cardClientes = CriarCartaoKPI("Clientes Ativos", out lblClientesValor, Color.LightCyan);
            cardPedidos = CriarCartaoKPI("Total de Pedidos", out lblPedidosValor, Color.LightGreen);

            painelCartoes.Controls.Add(cardFaturamento, 0, 0);
            painelCartoes.Controls.Add(cardEstoque, 1, 0);
            painelCartoes.Controls.Add(cardClientes, 2, 0);
            painelCartoes.Controls.Add(cardPedidos, 3, 0);
            painelRaiz.Controls.Add(painelCartoes, 0, 0);

            // ---------- LINHA 2: GRÁFICOS ----------
            var painelGraficos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            painelGraficos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65)); // vendas maior, igual ao flex:2
            painelGraficos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35)); // categorias flex:1

            chartVendas = CriarGraficoBarra("Desempenho de Vendas");
            chartCategorias = CriarGraficoRosca("Estoque por Categoria");

            painelGraficos.Controls.Add(EnvolverEmCard(chartVendas), 0, 0);
            painelGraficos.Controls.Add(EnvolverEmCard(chartCategorias), 1, 0);
            painelRaiz.Controls.Add(painelGraficos, 0, 1);

            // ---------- LINHA 3: PEDIDOS RECENTES ----------
            dgvPedidosRecentes = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.FromArgb(50, 50, 50), // Fundo adaptado para casar com o Material Dark
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Desabilitar estilos visuais padrão para injetar a cor Índigo
            dgvPedidosRecentes.EnableHeadersVisualStyles = false;
            dgvPedidosRecentes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181); // RGB correspondente ao Primary.Indigo500
            dgvPedidosRecentes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPedidosRecentes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            painelRaiz.Controls.Add(EnvolverEmCard(dgvPedidosRecentes, "Pedidos Recentes"), 0, 2);

            var painelRankings = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            painelRankings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            painelRankings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            dgvTopVendedores = CriarGridRanking();
            dgvTopClientes = CriarGridRanking();

            painelRankings.Controls.Add(EnvolverEmCard(dgvTopVendedores, "Top Vendedores"), 0, 0);
            painelRankings.Controls.Add(EnvolverEmCard(dgvTopClientes, "Clientes que Mais Compraram"), 1, 0);
            painelRaiz.Controls.Add(painelRankings, 0, 3);
        }
               

        // Cria um "cartao-metas" no estilo do PHP: título + valor
        private MaterialCard CriarCartaoKPI(string titulo, out Label lblValor, Color corDestaque)
        {
            var card = new MaterialCard
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                Padding = new Padding(16),
                Depth = 0
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(16, 16)
            };

            lblValor = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = corDestaque,
                AutoSize = true,
                Location = new Point(16, 40)
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblValor);
            return card;
        }

        private Chart CriarGraficoBarra(string titulo)
        {
            var chart = new Chart { Dock = DockStyle.Fill };
            var area = new ChartArea("area1");
            area.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            chart.ChartAreas.Add(area);

            var serie = new Series("serieVendas")
            {
                ChartType = SeriesChartType.Column
            };
            chart.Series.Add(serie);
            chart.Titles.Add(new Title(titulo, Docking.Top, new Font("Segoe UI", 11, FontStyle.Bold), Color.Black));
            return chart;
        }

        private Chart CriarGraficoRosca(string titulo)
        {
            var chart = new Chart { Dock = DockStyle.Fill };
            chart.ChartAreas.Add(new ChartArea("area2"));

            var serie = new Series("serieCategorias")
            {
                ChartType = SeriesChartType.Doughnut
            };
            chart.Series.Add(serie);
            chart.Legends.Add(new Legend("legenda1") { Docking = Docking.Bottom });
            chart.Titles.Add(new Title(titulo, Docking.Top, new Font("Segoe UI", 11, FontStyle.Bold), Color.Black));
            return chart;
        }

        // Envolve qualquer controle num MaterialCard com título, igual "cartao-grafico"
        private MaterialCard EnvolverEmCard(Control conteudo, string titulo = null)
        {
            var card = new MaterialCard
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                Padding = new Padding(12),
                Depth = 0
            };

            if (!string.IsNullOrEmpty(titulo))
            {
                var lbl = new Label
                {
                    Text = titulo,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Height = 30
                };
                card.Controls.Add(lbl);
            }

            conteudo.Dock = DockStyle.Fill;
            card.Controls.Add(conteudo);
            if (!string.IsNullOrEmpty(titulo)) conteudo.BringToFront();
            return card;
        }

        // ===================== CARGA DE DADOS (equivalente às queries do Admin.php) =====================
       

        private void CarregarDashboard()
        {
            try
            {
                CarregarKPIs();
                CarregarGraficoVendas();
                CarregarGraficoCategorias();
                CarregarPedidosRecentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o dashboard: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarKPIs()
        {
            // Faturamento total
            DataTable dtFaturamento = conexao.RetornaDados("SELECT SUM(valor_total) AS total FROM venda");
            decimal totalVendas = 0;
            if (dtFaturamento != null && dtFaturamento.Rows.Count > 0 && dtFaturamento.Rows[0]["total"] != DBNull.Value)
                totalVendas = Convert.ToDecimal(dtFaturamento.Rows[0]["total"]);
            lblFaturamentoValor.Text = totalVendas.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));

            // Itens em estoque (produtos ativos)
            DataTable dtEstoque = conexao.RetornaDados("SELECT SUM(qtde_estoque) AS total FROM produto WHERE status = 1");
            int totalEstoque = 0;
            if (dtEstoque != null && dtEstoque.Rows.Count > 0 && dtEstoque.Rows[0]["total"] != DBNull.Value)
                totalEstoque = Convert.ToInt32(dtEstoque.Rows[0]["total"]);
            lblEstoqueValor.Text = totalEstoque.ToString("N0");

            // Clientes ativos
            DataTable dtClientes = conexao.RetornaDados("SELECT COUNT(*) AS total FROM cliente WHERE status = 1");
            int totalClientes = 0;
            if (dtClientes != null && dtClientes.Rows.Count > 0 && dtClientes.Rows[0]["total"] != DBNull.Value)
                totalClientes = Convert.ToInt32(dtClientes.Rows[0]["total"]);
            lblClientesValor.Text = totalClientes.ToString("N0");

            // Total de pedidos
            DataTable dtPedidos = conexao.RetornaDados("SELECT COUNT(*) AS total FROM venda");
            int totalPedidos = 0;
            if (dtPedidos != null && dtPedidos.Rows.Count > 0 && dtPedidos.Rows[0]["total"] != DBNull.Value)
                totalPedidos = Convert.ToInt32(dtPedidos.Rows[0]["total"]);
            lblPedidosValor.Text = totalPedidos.ToString();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {

        }

        private void CarregarGraficoVendas()
        {
            string sql = @"SELECT MONTHNAME(data_venda) as mes, SUM(valor_total) as total
                        FROM venda
                        GROUP BY MONTH(data_venda)
                        ORDER BY MONTH(data_venda) ASC
                        LIMIT 6";

            var serie = chartVendas.Series["serieVendas"];
            serie.Points.Clear();

            DataTable dt = conexao.RetornaDados(sql);
            if (dt == null) return;

            foreach (DataRow linha in dt.Rows)
            {
                string mes = linha["mes"].ToString();
                double total = linha["total"] != DBNull.Value ? Convert.ToDouble(linha["total"]) : 0;
                serie.Points.AddXY(mes, total);
            }
        }

        private void CarregarGraficoCategorias()
        {
            string sql = @"SELECT c.nome as categoria, SUM(p.qtde_estoque) as qtd_estoque
                        FROM produto p
                        INNER JOIN categoria c ON p.codigo_categoria = c.codigo_categoria
                        WHERE p.status = 1
                        GROUP BY c.codigo_categoria
                        ORDER BY qtd_estoque DESC
                        LIMIT 5";

            var serie = chartCategorias.Series["serieCategorias"];
            serie.Points.Clear();

            DataTable dt = conexao.RetornaDados(sql);
            if (dt == null) return;

            foreach (DataRow linha in dt.Rows)
            {
                string categoria = linha["categoria"].ToString();
                double qtd = linha["qtd_estoque"] != DBNull.Value ? Convert.ToDouble(linha["qtd_estoque"]) : 0;
                serie.Points.AddXY(categoria, qtd);
            }
        }

        private void CarregarPedidosRecentes()
        {
            string sql = @"SELECT v.codigo_venda, c.nome as cliente_nome, v.forma_pagamento, v.valor_total
                        FROM venda v
                        INNER JOIN cliente c ON v.codigo_cliente = c.codigo_cliente
                        ORDER BY v.codigo_venda DESC
                        LIMIT 5";

            DataTable tabela = conexao.RetornaDados(sql);
            if (tabela == null) return;

            // Formata igual o PHP faz (VD-0001, R$ 1.234,56)
            tabela.Columns.Add("Código", typeof(string));
            tabela.Columns.Add("Valor", typeof(string));
            foreach (DataRow linha in tabela.Rows)
            {
                linha["Código"] = "VD-" + linha["codigo_venda"].ToString().PadLeft(4, '0');
                linha["Valor"] = Convert.ToDecimal(linha["valor_total"])
                    .ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
            }

            dgvPedidosRecentes.DataSource = tabela;
            dgvPedidosRecentes.Columns["codigo_venda"].Visible = false;
            dgvPedidosRecentes.Columns["valor_total"].Visible = false;
            dgvPedidosRecentes.Columns["cliente_nome"].HeaderText = "Cliente";
            dgvPedidosRecentes.Columns["forma_pagamento"].HeaderText = "Pagamento";
            // Define a cor de fundo escuro e a fonte branca como padrão para todas as linhas
            dgvPedidosRecentes.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvPedidosRecentes.DefaultCellStyle.ForeColor = Color.White;
            // Define a MESMA cor de fundo para as linhas alternadas (removendo o zebrado)
            dgvPedidosRecentes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgvPedidosRecentes.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            // Cor da linha ao selecionar
            dgvPedidosRecentes.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvPedidosRecentes.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private DataGridView CriarGridRanking()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.FromArgb(50, 50, 50),
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Cabeçalho unificado com o formCliente
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181); // Indigo500
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Estilo das Linhas (Padrão Escuro)
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgv.DefaultCellStyle.ForeColor = Color.White;

            // Remove qualquer efeito "zebrado" com cores claras
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(43, 61, 79);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Estilo da Seleção
            dgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            return dgv;
        }
        private void CarregarTopVendedores()
        {
            string sql = @"SELECT f.nome AS Vendedor, COUNT(v.codigo_venda) AS Vendas,
                    SUM(v.valor_total) AS Total
                FROM venda v
                INNER JOIN funcionario f ON v.codigo_funcionario = f.codigo_funcionario
                GROUP BY v.codigo_funcionario
                ORDER BY Total DESC
                LIMIT 5";

            DataTable dt = conexao.RetornaDados(sql);
            if (dt == null) return;

            dt.Columns.Add("Total Formatado", typeof(string));
            foreach (DataRow linha in dt.Rows)
                linha["Total Formatado"] = Convert.ToDecimal(linha["Total"]).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));

            dgvTopVendedores.DataSource = dt;
            dgvTopVendedores.Columns["Total"].Visible = false;
        }

        private void CarregarTopClientes()
        {
            string sql = @"SELECT c.nome AS Cliente, COUNT(v.codigo_venda) AS Compras,
                    SUM(v.valor_total) AS Total
                FROM venda v
                INNER JOIN cliente c ON v.codigo_cliente = c.codigo_cliente
                GROUP BY v.codigo_cliente
                ORDER BY Total DESC
                LIMIT 5";

            DataTable dt = conexao.RetornaDados(sql);
            if (dt == null) return;

            dt.Columns.Add("Total Formatado", typeof(string));
            foreach (DataRow linha in dt.Rows)
                linha["Total Formatado"] = Convert.ToDecimal(linha["Total"]).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));

            dgvTopClientes.DataSource = dt;
            dgvTopClientes.Columns["Total"].Visible = false;
        }
    }
}
