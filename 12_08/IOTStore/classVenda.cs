using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTStore
{
    class classVenda
    {
        //CONSTRUTOR
        public classVenda()
        {
            codigo_venda = 0;
            data_venda = DateTime.Now;
            desconto = 0;
            valor_total = 0;
            forma_pagamento = null;
            observacao = null;
            codigo_funcionario = 0;
            codigo_cliente = 0;
        }

        //PROPRIEDADES

        public int codigo_venda { get; set; }
        public DateTime data_venda { get; set; }
        public decimal desconto { get; set; }
        public decimal valor_total { get; set; }
        public string forma_pagamento { get; set; }
        public string observacao { get; set; }
        public int codigo_funcionario { get; set; }
        public int codigo_cliente { get; set; }

        //METODO PARA CADASTRAR VENDA USANDO O METODO EXECUTAQUERYID DA CLASSE CONEXÃO, QUE VAI EXECUTAR O COMANDO DO BD O MÉTODO EXECUTAESCALAR (PARA RETORNAR O CÓDIGO DA ÚLTIMA VENDA GERADA)

        public bool CadastrarVenda()
        {
            string sql = $" INSERT INTO venda VALUES(0, NOW(),'{desconto.ToString().Replace(",", ".")}', '{valor_total.ToString().Replace(",", ".")}', '{forma_pagamento}','{observacao}', {codigo_funcionario}, {codigo_cliente}); SELECT LAST_INSERT_ID()";

            classConexao cConexao = new classConexao();

            codigo_venda = 0;
            codigo_venda = cConexao.ExecutaQueryID(sql);

            if(codigo_venda != 0)
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
