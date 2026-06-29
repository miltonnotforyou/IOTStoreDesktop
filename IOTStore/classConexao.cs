using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTStore
{
    class classConexao
    {

        //PRECISAMOS USAR UM OBJETO PARA A CONEXÃO COM O BANCO
        //OBJETO MySqlConnection TRATA A CONEXÃO COM O MySQL ou MariaDB
        private MySqlConnection c;

        //MySqlCommand TRATA OS TIPOS DE COMANDO E CADA AÇÃO QUE DEVERÁ SER TOMADA,
        //COMO POR EXEMPLO UM SELECT OU INSERT
        private MySqlCommand cmd;

        //MySqlDataAdapter: RESULTADO DO ExecuteReader (utilizado para executar uma instrução SQL que retorna um DataReader)
        //DataReader: é preenchido com o resultado de uma instrução SQL do tipo SELECT.

        //DataSet -> ARMAZENA DADOS EM EM MEMÓRIA, PODEMOS TER UM CONJUNTO DE TABELAS
        //DataTable -> É UMA TABELA APENAS QUE PODEMOS MONTAR NO AMBIENTE DE PROGRAMAÇÃO
        private MySqlDataAdapter adapter;

        private string erro;

        public classConexao()
        {
            this.c = new MySqlConnection();
            this.cmd = null;
            this.adapter = null;
            erro = null;
        }

        #region Métodos para Gerenciar a Conexão

        // ABRIR A CONEXÃO COM O BANCO
        // CRIAMOS A STRING CONEXÃO, OU PRECISAMOS PEGAR ESTA STRING DE ALGUM LUGAR CADA SERVIDOR TEM SUA STRING DE CONEXÃO
        private void Conectar()
        {
            //WEB
            //string conexao = @"Persist Security Info = False; Server = 000.000.000.000; Database = NomeBanco; uid = Usuario; pwd= Senha ";

            //LOCAL
            string conexao = @"Persist Security Info=False; Server = localhost; Database = iot_store; uid=root; pwd= ''";

            //c.State -> STATE É UMA PROPRIEDADE QUE PODEMOS VERIFICAR O ESTADO DA CONEXÃO, COMO NO PROJETO VAMOS SEMPRE FECHAR A CONEXÃO 
            //PODEREMOS MANTER O ESTADO SEMPRE FECHADO DEPENDO DA SITUAÇÃO PODEREMOS REALIZAR E MANTER O ESTADO ABERTO  
            if (c.State == ConnectionState.Closed || c.State == ConnectionState.Broken)
            {
                //INFORMA QUAL É A CONEXÃO QUE VAMOS USAR
                c.ConnectionString = conexao;
                //ABRIR A CONEXÃO 
                c.Open();
            }
        }

        //TODA A CONEXÃO DEVE SER FECHADA E LIBERADA
        //c.Dispose() LIBERA A CONEXÃO
        //c.Close() FECHA A CONEXÃO
        //PODEMOS LIBERAR E FECHAR EM QUALQUER MOMENTO CHAMANDO ESTE MÉTODO
        private void Desconectar()
        {
            //if (this.c.State == ConnectionState.Open)
            //{
            //    this.c.Dispose();
            //    this.c.Close();
            //}


            if (c != null && (c.State == ConnectionState.Open || c.State == ConnectionState.Broken))
            {
                c.Close();
                c.Dispose();
            }


        }

        #endregion


        #region Métodos que trata o tipo de acesso

        //MÉTODO UTILIZADO PARA EXECUTAR OS COMANDOS DO BD - INSERT, UPDATE E DELETE
        //EXECUTA A QUERY E DEPENDE DO RETORNO DO BANCO SQL(0 OU 1)
        //0 -> QUANDO GERA ALGUM ERRO
        //1 -> QUANDO OCORRE TUDO CERTO
        public int ExecutaQuery(string query)
        {
            try
            {
                Conectar();

                using (MySqlCommand cmd = new MySqlCommand(query, c))
                {
                    int resp = cmd.ExecuteNonQuery();
                    return resp;
                }
            }
            catch (MySqlException ex)//PARA IDENTIFICAR UM ERRO NO SQL COLOQUE UM BREAKPOINT PARA RECEBER A MENSAGEM DO BANCO DE DADOS
            {
                erro = ex.Message;
                return 0;
            }
            finally
            {
                Desconectar();
            }

        }


        //DataTable: REPRESENTA UMA TABELA DE DADOS NA MEMÓRIA
        //MySqlDataAdapter SERÁ USADO PARA EXECUTAR COMANDOS USANDO UM DataSet OU DataTable
        //USADO SEMPRE QUE UMA CONSULTA NO BD TEM QUE SER FEITA
        //MÉTODO PARA EXECUTAR TODOS OS COMANDOS DE CONSULTA
        public DataTable RetornaDados(string query)
        {
            try
            {
                Conectar();

                using (MySqlCommand cmd = new MySqlCommand(query, c))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (MySqlException ex)
            {
                erro = ex.Message;
                return null;
            }
            finally
            {
                Desconectar();
            }
        }




        //O método ExecuteScalar é utilizado para executar instruções SQL utilizando funções agregadas, como COUNT, SUM, MIN, MAX e AVG.Este método retorna apenas um valor como resultado.

        //O método ExecuteScalar é usado para executar Comandos SQL ou storeprocedure, após a execução retornar um único valor do banco de dados. Ele também retorna a primeira coluna da primeira linha no conjunto de resultados de um banco de dados.

        //USADO PARA CADASTRAR, QUANDO ESPERAMOS O CÓDIGO DE RETORNO, CHAVE PRIMÁRIA(PK)
        //SERÁ USADO NOS CADASTROS NxN
        public int ExecutaQueryID(string query)
        {
            try
            {
                int aux = 0;
                Conectar();

                this.cmd = new MySqlCommand(query, this.c);
                //ExecuteScalar: RECUPERAR UM VALOR ÚNICO DE UM BANCO DE DADOS (PK)
                aux = Convert.ToInt32(cmd.ExecuteScalar());

                Desconectar();
                return aux;
            }
            catch (MySqlException sqlex)
            {
                erro = sqlex.Message;
                Desconectar();
                return 0;
            }
        }
        #endregion


    }
}
