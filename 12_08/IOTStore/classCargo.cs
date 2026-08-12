using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTStore
{
    class classCargo
    {
        //CONSTRUTOR DA CLASSE - INICIALIZAR TODAS AS PROPRIEDADES DA CLASSE
        // O MÉTODO CONSTRUTOR PRECISA TER O MESMO NOME DA CLASSE CRIADA

        public classCargo() // TODO MÉTODO TEM () E {}
        {
            codigo_cargo = 0;
            nome = null;
            observacao = null;
            status = 0;
            data_cadastro = DateTime.Now;
        }

        //FIM DO CONSTRUTOR

        //PROPRIEDADES DA CLASSE: LER E ARMAZENAR OS DADOS QUE SERÃO ENVIADOS AO BANCO DE DADOS OU RETORNADOS DO BANCO DE DADOS
        //MESMO NOME E TIPO DE DADOS DOS CAMPOS DO BD
        //ATALHO PARA CRIAR PROPRIEDADES NO C# PROP TAB TAB
        public int codigo_cargo { get; set; } // TODA PROPRIEDADE É PUBLICA, PRECISA DE NOME, GET E SET
        public string nome { get; set; }
        public string observacao { get; set; }
        public int status { get; set; }
        public DateTime data_cadastro { get; set; }

        //FIM DO PROPRIEDADES

        //MÉTODOS - FUNCIONALIDADES DO SISTEMA
        // CRIAR MÉTODO: ENCAPSULAMENTO (PRIVATE/PUBLIC), TIPO DE RETORNO (INT/STRING/BOOL), NOME DO MÉTODO, PARÂMETROS () <- CONDIÇÕES
        //PRECISA TERMINAR COM RETURN A NÃO SER QUE SEJA UM MÉTODO VOID (EX: CONECTAR O BANCO DE DADOS, LIMPAR UM FORMULÁRIO ETC...)
        public int CadastrarCargo()
        {

            //VARIÁVEL PARA ARMAZENAR O COMANDO QUE SERÁ EXECUTADO PELO BANCO DE DADOS

            string comando_sql = "INSERT INTO cargo VALUES(0, '"+ nome + "', '" + observacao + "', 1, NOW() ); ";


            string comando_teste = $"INSERT INTO cargo VALUES(0, '{nome}', '{observacao}', 1, NOW());  "; //MESMO COMANDO COM ITERPOLAÇÃO NECESSITA COMEÇAR COM $ E {}

            //CRIAR OBJETO DA CLASSE CONEXÃO PARA USAR MÉTODO EXECUTAQUERY

            classConexao cConexao = new classConexao();

            //DEFINIR O RETURN DO MÉTODO - CHAMANDO O MÉTODO DA CLASSE CONEXÃO QUE VAI EXECUTAR O COMANDO NO BD E RETORNAR O RESULTADO -> 0 SE DEU ERRO, 1 SE DEU CERTO
            return cConexao.ExecutaQuery(comando_sql);
        }


        //METODO PARA CARREGAR A COMBO BOX DE CARGO NO FORMULARIO DE CADASTRO DE FUNCINARIOS
        public DataTable BuscarCargo()
        {
            string sql = "SELECT codigo_cargo, nome FROM cargo WHERE status = 1 ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // ==========================================================
        // MÉTODOS PARA A TELA DE CONSULTA DE CARGO
        // ==========================================================

        // MÉTODO PARA CONSULTAR CARGO PELO STATUS (0 Inativo, 1 Ativo)
        public DataTable ConsultaCargoStatus(int statusCargo)
        {
            string sql = $"SELECT * FROM cargo WHERE status = {statusCargo} ORDER BY nome;";
            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // MÉTODO PARA CONSULTAR CARGO QUE COMEÇA COM DETERMINADA LETRA/PALAVRA
        public DataTable ConsultaCargoNomeInicio(string nomeCargo)
        {
            // O sinal de % no final significa que começa com o texto digitado e pode ter qualquer coisa depois
            string sql = $"SELECT * FROM cargo WHERE nome LIKE '{nomeCargo}%' ORDER BY nome;";
            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // MÉTODO PARA CONSULTAR CARGO QUE CONTENHA DETERMINADA LETRA/PALAVRA
        public DataTable ConsultaCargoNomeContem(string nomeCargo)
        {
            // O sinal de % no começo e no final significa que o texto pode estar em qualquer parte (começo, meio ou fim)
            string sql = $"SELECT * FROM cargo WHERE nome LIKE '%{nomeCargo}%' ORDER BY nome;";
            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // MÉTODO PARA RETORNAR OS DADOS DE UM CARGO ESPECÍFICO (USADO AO CLICAR NA GRID PARA EDITAR)
        public bool DadosCargo(int codigoCargoSelecionado)
        {
            string sql = $"SELECT * FROM cargo WHERE codigo_cargo = {codigoCargoSelecionado};";
            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDados(sql);

            // Verifica se retornou algum registro do banco de dados
            if (dt.Rows.Count > 0)
            {
                // Preenche as propriedades da classe com os dados retornados do banco
                codigo_cargo = Convert.ToInt32(dt.Rows[0]["codigo_cargo"]);
                nome = dt.Rows[0]["nome"].ToString();
                observacao = dt.Rows[0]["observacao"].ToString();
                status = Convert.ToInt32(dt.Rows[0]["status"]);
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);

                return true; // Encontrou o cargo
            }
            else
            {
                return false; // Não encontrou o cargo
            }
        }

        // MÉTODO PARA CONSULTAR CARGO POR PERÍODO DE DATA DE CADASTRO
        public DataTable ConsultaCargoDataCadastro(DateTime dataInicial, DateTime dataFinal)
        {
            // Formata as datas para o padrão do banco de dados (YYYY-MM-DD)
            // Forçamos o início do dia (00:00:00) e o fim do dia (23:59:59) para garantir que pegue tudo
            string inicio = dataInicial.ToString("yyyy-MM-dd 00:00:00");
            string fim = dataFinal.ToString("yyyy-MM-dd 23:59:59");

            string sql = $"SELECT * FROM cargo WHERE data_cadastro BETWEEN '{inicio}' AND '{fim}' ORDER BY nome;";
            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // MÉTODO PARA ATUALIZAR UM CARGO EXISTENTE
        public int AtualizarCargo()
        {
            // O comando UPDATE altera os dados baseados no código do cargo
            string sql = $"UPDATE cargo SET nome = '{nome}', observacao = '{observacao}', status = {status} WHERE codigo_cargo = {codigo_cargo};";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        // MÉTODO PARA EXCLUIR UM CARGO EXISTENTE
        public int ExcluirCargo()
        {
            // O comando DELETE apaga a linha baseada no código do cargo
            string sql = $"DELETE FROM cargo WHERE codigo_cargo = {codigo_cargo};";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        //MÉTODOS PARA RELATORIO DE CARGOS
        /*CARGOS POR STATUS*/
        public DataTable RelatorioCargoStatus(int status)
        {
            string sql = $"SELECT * FROM cargo WHERE cargo.status = {status} ORDER BY cargo.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);

        }

        /*CARGOS POR DATA DE CADASTRO*/
        public DataTable RelatorioCargoDataCadastro(DateTime dataI, DateTime dataF)
        {
            string sql = $"SELECT * FROM  cargo WHERE cargo.status = 1 AND CAST(cargo.data_cadastro AS DATE) BETWEEN '{dataI.ToString("yyyy-MM-dd")}' AND '{dataF.ToString("yyyy-MM-dd")}' ORDER BY cargo.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }
    }
}
