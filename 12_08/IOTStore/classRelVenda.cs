using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;// adicionar para datatable

namespace IOTStore
{
    class classRelVenda
    {
        //CONSTRUTOR
        public classRelVenda()
        {
            //CLASSE VENDA
            codigo_venda = 0;
            data_venda = DateTime.Now;
            desconto = 0;
            valor_total = 0;
            forma_pagamento = null;
            observacao = null;
            codigo_funcionario = 0;
            codigo_cliente = 0;

            //CLASSE ITENS
            codigo_item_venda = 0;
            qtde_item = 0;
            valor_item = 0;
            valor_total_item = 0;
            codigo_produto = 0;

            //MARCA
            codigo_marca = 0;
            
        }

        //PROPRIEDADES VENDA

        public int codigo_venda { get; set; }
        public DateTime data_venda { get; set; }
        public decimal desconto { get; set; }
        public decimal valor_total { get; set; }
        public string forma_pagamento { get; set; }
        public string observacao { get; set; }
        public int codigo_funcionario { get; set; }
        public int codigo_cliente { get; set; }

        //PROPRIEDADES ITENS VENDA

        public int codigo_item_venda { get; set; }
        public int qtde_item { get; set; }
        public decimal valor_item { get; set; }
        public decimal valor_total_item { get; set; }
        public int codigo_produto { get; set; }


        //PROPRIEDADES DA MARCA

        public int codigo_marca { get; set; }

        //METODOS RELATORIO VENDA DETALHADOS
        //METODO PARA BUSCAR POR DATA

        public DataTable RelatorioVendaDetalhadoData(DateTime datai, DateTime dataf)
        {
            string sql = $" SELECT marca.nome 'codigo_marca', produto.nome 'codigo_produto', item_venda.qtde_item, item_venda.valor_item, item_venda.valor_total_item, venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM marca JOIN produto ON marca.codigo_marca = produto.codigo_marca JOIN item_venda ON item_venda.codigo_produto = produto.codigo_produto JOIN venda ON venda.codigo_venda = item_venda.codigo_venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE CAST(venda.data_venda AS DATE) BETWEEN '{datai.ToString("yyyy-MM-dd")}' AND '{dataf.ToString("yyyy-MM-dd")}' ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        
        //METODO PARA BUSCAR POR DATA E CLIENTE

        public DataTable RelatorioVendaDetalhadoDataCliente(DateTime datai, DateTime dataf, int cliente)
        {
            string sql = $" SELECT marca.nome 'codigo_marca', produto.nome 'codigo_produto', item_venda.qtde_item, item_venda.valor_item, item_venda.valor_total_item, venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM marca JOIN produto ON marca.codigo_marca = produto.codigo_marca JOIN item_venda ON item_venda.codigo_produto = produto.codigo_produto JOIN venda ON venda.codigo_venda = item_venda.codigo_venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE CAST(venda.data_venda AS DATE) BETWEEN '{datai.ToString("yyyy-MM-dd")}' AND '{dataf.ToString("yyyy-MM-dd")}' AND venda.codigo_cliente = {cliente} ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        //METODO PARA BUSCAR POR DATA E FUNCIONARIO

        public DataTable RelatorioVendaDetalhadoDataFuncionario(DateTime datai, DateTime dataf, int funcionario)
        {
            string sql = $" SELECT marca.nome 'codigo_marca', produto.nome 'codigo_produto', item_venda.qtde_item, item_venda.valor_item, item_venda.valor_total_item, venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM marca JOIN produto ON marca.codigo_marca = produto.codigo_marca JOIN item_venda ON item_venda.codigo_produto = produto.codigo_produto JOIN venda ON venda.codigo_venda = item_venda.codigo_venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE CAST(venda.data_venda AS DATE) BETWEEN '{datai.ToString("yyyy-MM-dd")}' AND '{dataf.ToString("yyyy-MM-dd")}' AND venda.codigo_funcionario = {funcionario} ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        //METODO PARA BUSCAR POR FUNCIONARIO

        public DataTable RelatorioVendaDetalhadoFuncionario(int funcionario)
        {
            string sql = $" SELECT marca.nome 'codigo_marca', produto.nome 'codigo_produto', item_venda.qtde_item, item_venda.valor_item, item_venda.valor_total_item, venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM marca JOIN produto ON marca.codigo_marca = produto.codigo_marca JOIN item_venda ON item_venda.codigo_produto = produto.codigo_produto JOIN venda ON venda.codigo_venda = item_venda.codigo_venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE venda.codigo_funcionario = {funcionario} ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        //METODO PARA BUSCAR POR CLIENTE

        public DataTable RelatorioVendaDetalhadoCliente(int cliente)
        {
            string sql = $" SELECT marca.nome 'codigo_marca', produto.nome 'codigo_produto', item_venda.qtde_item, item_venda.valor_item, item_venda.valor_total_item, venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM marca JOIN produto ON marca.codigo_marca = produto.codigo_marca JOIN item_venda ON item_venda.codigo_produto = produto.codigo_produto JOIN venda ON venda.codigo_venda = item_venda.codigo_venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE venda.codigo_cliente = {cliente} ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        ////////////////METODOS RELATORIO VENDA SIMPLES///////////////////
        //METODO PARA BUSCAR POR DATA

        public DataTable RelatorioVendaData(DateTime datai, DateTime dataf)
        {
            string sql = $" SELECT venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE CAST(venda.data_venda AS DATE) BETWEEN '{datai.ToString("yyyy-MM-dd")}' AND '{dataf.ToString("yyyy-MM-dd")}' ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        //METODO PARA BUSCAR POR DATA E CLIENTE

        public DataTable RelatorioVendaDataCliente(DateTime datai, DateTime dataf, int cliente)
        {
            string sql = $" SELECT venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE CAST(venda.data_venda AS DATE) BETWEEN '{datai.ToString("yyyy-MM-dd")}' AND '{dataf.ToString("yyyy-MM-dd")}' AND venda.codigo_cliente = {cliente} ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        //METODO PARA BUSCAR POR DATA E FUNCIONARIO

        public DataTable RelatorioVendaDataFuncionario(DateTime datai, DateTime dataf, int funcionario)
        {
            string sql = $" SELECT venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE CAST(venda.data_venda AS DATE) BETWEEN '{datai.ToString("yyyy-MM-dd")}' AND '{dataf.ToString("yyyy-MM-dd")}' AND venda.codigo_funcionario = {funcionario} ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        //METODO PARA BUSCAR POR FUNCIONARIO

        public DataTable RelatorioVendaFuncionario(int funcionario)
        {
            string sql = $" SELECT venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE venda.codigo_funcionario = {funcionario} ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

        //METODO PARA BUSCAR POR CLIENTE

        public DataTable RelatorioVendaCliente(int cliente)
        {
            string sql = $" SELECT venda.codigo_venda, venda.data_venda, venda.forma_pagamento, venda.desconto, venda.valor_total, cliente.nome 'codigo_cliente', funcionario.nome 'codigo_funcionario' FROM venda JOIN cliente ON cliente.codigo_cliente = venda.codigo_cliente JOIN funcionario ON funcionario.codigo_funcionario = venda.codigo_funcionario WHERE venda.codigo_cliente = {cliente} ORDER BY venda.data_venda;";

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }

    }
}
