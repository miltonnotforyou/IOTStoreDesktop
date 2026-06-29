using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTStore
{
    class classProduto
    {
        public classProduto() // MÉTODO CONSTRUTOR
        {
            codigo_produto = 0;
            nome = null;
            descricao = null;
            qtde_estoque = 0;
            preco_custo = 0;
            lucro = null; // <- NOVO CAMPO
            preco_venda = 0;
            status_promocao = false;
            desconto_promocao = 0;
            preco_promocao = 0;
            foto = null;
            data_cadastro = DateTime.Now;
            status = 0;
            codigo_marca = 0;
            codigo_categoria = 0;
        }

        // PROPRIEDADES
        public int codigo_produto { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int qtde_estoque { get; set; }
        public decimal preco_custo { get; set; }
        public string lucro { get; set; } // <- NOVO CAMPO
        public decimal preco_venda { get; set; }
        public bool status_promocao { get; set; }
        public decimal desconto_promocao { get; set; }
        public decimal preco_promocao { get; set; }
        public string foto { get; set; }
        public DateTime data_cadastro { get; set; }
        public int status { get; set; }
        public int codigo_marca { get; set; }
        public int codigo_categoria { get; set; }

        // MÉTODO DE CADASTRO
        public int CadastrarProduto()
        {
            // Declarar as colunas blinda o seu código contra mudanças na ordem da tabela do BD
            string sql = $"INSERT INTO produto (nome, descricao, qtde_estoque, preco_custo, lucro, preco_venda, status_promocao, desconto_promocao, preco_promocao, foto, data_cadastro, status, codigo_marca, codigo_categoria) " +
                         $"VALUES (" +
                         $"'{nome}', " +
                         $"'{descricao}', " +
                         $"{qtde_estoque}, " +
                         $"'{preco_custo.ToString().Replace(",", ".")}', " +
                         $"'{lucro}', " +
                         $"'{preco_venda.ToString().Replace(",", ".")}', " +
                         $"{(status_promocao ? 1 : 0)}, " +
                         $"'{desconto_promocao.ToString().Replace(",", ".")}', " +
                         $"'{preco_promocao.ToString().Replace(",", ".")}', " +
                         $"'{foto}', " +
                         $"NOW(), " +
                         $"1, " +
                         $"{codigo_marca}, " +
                         $"{codigo_categoria});";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        /* ====================================================================
           MÉTODOS DE CONSULTA DE PRODUTOS (Filtros do FormConsultaProduto)
           ==================================================================== */

        // 1. CONSULTA PRODUTO POR NOME INICIAL
        public DataTable ConsultaProdutoNomeInicio(string nomeI)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.nome LIKE '{nomeI}%' ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 2. CONSULTA PRODUTO POR NOME CONTÉM
        public DataTable ConsultaProdutoNomeContem(string nomeC)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.nome LIKE '%{nomeC}%' ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 3. CONSULTA PRODUTO POR CÓDIGO DIRETO (Baseado no campo codigoProduto da tela)
        public DataTable ConsultaProdutoCodigo(int codigo)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.codigo_produto = {codigo}; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 4. CONSULTA PRODUTO POR CATEGORIA (Baseado no gbCategoria da tela)
        public DataTable ConsultaProdutoCategoria(int categoria)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.codigo_categoria = {categoria} ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 5. CONSULTA PRODUTO POR MARCA (Baseado no cbMarca da tela)
        public DataTable ConsultaProdutoMarca(int marca)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.codigo_marca = {marca} ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 6. CONSULTA PRODUTO POR FAIXA DE PREÇO (Filtro estratégico avançado)
        public DataTable ConsultaProdutoFaixaPreco(decimal min, decimal max)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.preco_venda BETWEEN {min.ToString().Replace(",", ".")} AND {max.ToString().Replace(",", ".")} " +
                         $" ORDER BY produto.preco_venda ASC; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 7. CONSULTA PRODUTO POR STATUS ATIVO/INATIVO (Baseado no gbStatus da tela)
        public DataTable ConsultaProdutoStatus(int status)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = {status} ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 8. CONSULTA PRODUTO POR STATUS DE ESTOQUE (ComboBox: Normal, Baixo, Zero)
        public DataTable ConsultaProdutoEstoqueStatus(string statusEstoque)
        {
            string condicao = "";

            // Define a regra matemática para cada palavra da sua ComboBox
            if (statusEstoque == "Zero")
            {
                condicao = "produto.qtde_estoque = 0";
            }
            else if (statusEstoque == "Baixo")
            {
                // Considera estoque baixo tudo que for entre 1 e 10
                condicao = "produto.qtde_estoque > 0 AND produto.qtde_estoque <= 10";
            }
            else if (statusEstoque == "Normal")
            {
                // Considera normal tudo que for maior que 10
                condicao = "produto.qtde_estoque > 10";
            }

            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND {condicao} " +
                         $" ORDER BY produto.qtde_estoque ASC; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 9. CONSULTA PRODUTO POR MARCA E CATEGORIA JUNTAS
        public DataTable ConsultaProdutoMarcaCategoria(int marca, int categoria)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.codigo_marca = {marca} AND produto.codigo_categoria = {categoria} " +
                         $" ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 10. CONSULTA PRODUTO POR STATUS DE PROMOÇÃO (Sim = 1, Não = 0)
        public DataTable ConsultaProdutoPromocao(int statusPromocao)
        {
            string sql = $" SELECT produto.codigo_produto 'COD', produto.nome 'Nome', produto.qtde_estoque 'Estoque', produto.preco_venda 'Preço Venda', marca.nome 'Marca', categoria.nome 'Categoria' " +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.status_promocao = {statusPromocao} " +
                         $" ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 11. MÉTODO PARA BUSCAR TODOS OS DADOS DO PRODUTO SELECIONADO NA GRID DE CONSULTA
        public bool DadosProduto(int codigo)
        {
            string sql = $"SELECT * FROM produto WHERE codigo_produto = {codigo}";

            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDados(sql);

            if (dt.Rows.Count > 0)
            {
                codigo_produto = Convert.ToInt32(dt.Rows[0]["codigo_produto"]);
                nome = Convert.ToString(dt.Rows[0]["nome"]);
                descricao = Convert.ToString(dt.Rows[0]["descricao"]);
                qtde_estoque = Convert.ToInt32(dt.Rows[0]["qtde_estoque"]);
                preco_custo = Convert.ToDecimal(dt.Rows[0]["preco_custo"]);
                lucro = Convert.ToString(dt.Rows[0]["lucro"]);
                preco_venda = Convert.ToDecimal(dt.Rows[0]["preco_venda"]);
                status_promocao = Convert.ToBoolean(dt.Rows[0]["status_promocao"]);
                desconto_promocao = Convert.ToDecimal(dt.Rows[0]["desconto_promocao"]);
                preco_promocao = Convert.ToDecimal(dt.Rows[0]["preco_promocao"]);
                foto = Convert.ToString(dt.Rows[0]["foto"]);
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);
                codigo_marca = Convert.ToInt32(dt.Rows[0]["codigo_marca"]);
                codigo_categoria = Convert.ToInt32(dt.Rows[0]["codigo_categoria"]);

                return true;
            }
            else
            {
                return false;
            }
        }

        // 12. MÉTODO PARA ATUALIZAR PRODUTO
        public int CorrigirEAtualizarProduto()
        {
            string sql = $"UPDATE produto SET nome = '{nome}', descricao = '{descricao}', qtde_estoque = {qtde_estoque}, preco_custo = '{preco_custo.ToString().Replace(",", ".")}', lucro = '{lucro}', preco_venda = '{preco_venda.ToString().Replace(",", ".")}', status_promocao = {(status_promocao ? 1 : 0)}, desconto_promocao = '{desconto_promocao.ToString().Replace(",", ".")}', preco_promocao = '{preco_promocao.ToString().Replace(",", ".")}', foto = '{foto}', status = {status}, codigo_marca = {codigo_marca}, codigo_categoria = {codigo_categoria} WHERE codigo_produto = {codigo_produto}";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        // 13. MÉTODO PARA EXCLUIR PRODUTO
        public int ExcluirProduto()
        {
            string sql = $"DELETE FROM produto WHERE codigo_produto = {codigo_produto}";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        //RELATÓRIOS DE PRODUTOD

        // 1. RELATÓRIO PRODUTO POR CATEGORIA (Baseado no gbCategoria da tela)
        public DataTable RelatorioProdutoCategoria(int categoria)
        {
            string sql = $" SELECT produto.codigo_produto, produto.nome, produto.qtde_estoque, produto.preco_venda, produto.lucro, produto.data_cadastro, produto.foto, marca.nome, categoria.nome" +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.codigo_categoria = {categoria} ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 2. RELATÓRIO PRODUTO POR MARCA (Baseado no cbMarca da tela)
        public DataTable RelatorioProdutoMarca(int marca)
        {
            string sql = $" SELECT produto.codigo_produto, produto.nome, produto.qtde_estoque, produto.preco_venda, produto.lucro, produto.data_cadastro, produto.foto, marca.nome, categoria.nome" +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.codigo_marca = {marca} ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 3. RELATÓRIO PRODUTO POR FAIXA DE PREÇO (Filtro estratégico avançado)
        public DataTable RelatorioProdutoFaixaPreco(decimal min, decimal max)
        {
            string sql = $" SELECT produto.codigo_produto, produto.nome, produto.qtde_estoque, produto.preco_venda, produto.lucro, produto.data_cadastro, produto.foto, marca.nome, categoria.nome" +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.preco_venda BETWEEN {min.ToString().Replace(",", ".")} AND {max.ToString().Replace(",", ".")} " +
                         $" ORDER BY produto.preco_venda ASC; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 4. RELATÓRIO PRODUTO POR STATUS ATIVO/INATIVO (Baseado no gbStatus da tela)
        public DataTable RelatorioProdutoStatus(int status)
        {
            string sql = $" SELECT produto.codigo_produto, produto.nome, produto.qtde_estoque, produto.preco_venda, produto.lucro, produto.data_cadastro, produto.foto, marca.nome, categoria.nome" +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = {status} ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 5. RELATÓRIO PRODUTO POR STATUS DE ESTOQUE (ComboBox: Normal, Baixo, Zero)
        public DataTable RelatorioProdutoEstoqueStatus(string statusEstoque)
        {
            string condicao = "";

            // Define a regra matemática para cada palavra da sua ComboBox
            if (statusEstoque == "Zero")
            {
                condicao = "produto.qtde_estoque = 0";
            }
            else if (statusEstoque == "Baixo")
            {
                // Considera estoque baixo tudo que for entre 1 e 10
                condicao = "produto.qtde_estoque > 0 AND produto.qtde_estoque <= 10";
            }
            else if (statusEstoque == "Normal")
            {
                // Considera normal tudo que for maior que 10
                condicao = "produto.qtde_estoque > 10";
            }

            string sql = $" SELECT produto.codigo_produto, produto.nome, produto.qtde_estoque, produto.preco_venda, produto.lucro, produto.data_cadastro, produto.foto, marca.nome, categoria.nome" +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND {condicao} " +
                         $" ORDER BY produto.qtde_estoque ASC; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 6. RELATÓRIO PRODUTO POR MARCA E CATEGORIA JUNTAS
        public DataTable RelatorioProdutoMarcaCategoria(int marca, int categoria)
        {
            string sql = $" SELECT produto.codigo_produto, produto.nome, produto.qtde_estoque, produto.preco_venda, produto.lucro, produto.data_cadastro, produto.foto, marca.nome, categoria.nome" +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.codigo_marca = {marca} AND produto.codigo_categoria = {categoria} " +
                         $" ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 7. RELATÓRIO PRODUTO POR STATUS DE PROMOÇÃO (Sim = 1, Não = 0)
        public DataTable RelatorioProdutoPromocao(int statusPromocao)
        {
            string sql = $" SELECT produto.codigo_produto, produto.nome, produto.qtde_estoque, produto.preco_venda, produto.lucro, produto.data_cadastro, produto.foto, marca.nome, categoria.nome" +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria " +
                         $" WHERE produto.status = 1 AND produto.status_promocao = {statusPromocao} " +
                         $" ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // 8 PRODUTOS POR DATA DE CADASTRO*/
        public DataTable RelatorioProdutoDataCadastro(DateTime dataI, DateTime dataF)
        {
            string sql = $" SELECT produto.codigo_produto, produto.nome, produto.qtde_estoque, produto.preco_venda, produto.lucro, produto.data_cadastro, produto.foto, marca.nome, categoria.nome" +
                         $" FROM produto " +
                         $" JOIN marca ON produto.codigo_marca = marca.codigo_marca " +
                         $" JOIN categoria ON produto.codigo_categoria = categoria.codigo_categoria" +
                         $" WHERE produto.status = 1 AND CAST(produto.data_cadastro AS DATE) BETWEEN '{dataI.ToString("yyyy-MM-dd")}' AND '{dataF.ToString("yyyy-MM-dd")}' ORDER BY produto.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }


    }
}