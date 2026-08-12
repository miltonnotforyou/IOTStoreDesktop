using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTStore
{
    class classItensVenda
    {
        //CONSTRUTOR

        public classItensVenda()
        {
            codigo_item_venda = 0;
            qtde_item = 0;
            valor_item = 0;
            valor_total_item = 0;
            codigo_produto = 0;
            codigo_venda = 0;
        }

        //PROPRIEDADES

        public int codigo_item_venda { get; set; }
        public int qtde_item { get; set; }
        public decimal valor_item { get; set; }
        public decimal valor_total_item { get; set; }
        public int codigo_produto { get; set; }
        public int codigo_venda { get; set; }


        //METODO 

        public bool CadastrarItemVenda()
        {
            string sql = $" INSERT INTO item_venda VALUES (0, {qtde_item}, '{valor_item.ToString().Replace(",", ".")}', '{valor_total_item.ToString().Replace(",", ".")}', {codigo_produto}, {codigo_venda})";

            classConexao cConexao = new classConexao();

            int resp = cConexao.ExecutaQuery(sql);

            if (resp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
