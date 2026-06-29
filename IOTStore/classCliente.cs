using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTStore
{
    class classCliente
    {
        public classCliente()//METODO CONSTRUTOR
        {
            codigo_cliente = 0;
            nome = null;
            nome_social = null;
            data_nascimento = DateTime.Now;
            sexo = null;
            cpf = null;
            rg = null;
            endereco = null;
            numero = 0;
            complemento = null;
            bairro = null;
            cidade = null;
            estado = null;
            cep = null;
            telefone_residencial = null;
            telefone_celular = null;
            email = null;
            status = 0;
            data_cadastro = DateTime.Now;
            
        }// FINAL DO METODO CONSTRUTOR

        //PROPRIEDADES

        public int codigo_cliente { get; set; }
        public string nome { get; set; }
        public string nome_social { get; set; }
        public DateTime data_nascimento { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string telefone_residencial { get; set; }
        public string telefone_celular { get; set; }
        public string email { get; set; }
        public int status { get; set; }
        public DateTime data_cadastro { get; set; }
      
        //FIM DAS PROPRIEDADES


        //MÉTODOS - FUNCIONALIDADES DO SISTEMA
        // CADASTRAR Cliente
        // CAMPOS DATE: propriedade.ToString("yyyy-MM-dd")
        // CAMPOS DECIMAL: propriedade.ToString().Replace("," , ".")
        // NÃO PODE MANDAR ASPAS SIMPLES EM CAMPOS DO TIPO BIT

        public int CadastrarCliente()
        {
            string sql = $"INSERT INTO cliente VALUES(0, '{nome}', '{nome_social}', '{data_nascimento.ToString("yyyy-MM-dd")}', '{sexo}', '{cpf}', '{rg}', '{endereco}', {numero}, '{complemento}', '{bairro}', '{cidade}', '{estado}', '{cep}', '{telefone_residencial}','{telefone_celular}', '{email}', 1, NOW());";

            classConexao cConexao = new classConexao();

            return cConexao.ExecutaQuery(sql);

        }

        /* CONSULTA DE CLIENTE */
        /* FILTROS: NOME (INÍCIO E CONTÉM), CIDADE, SEXO, CPF, DATA DE CADASTRO, STATUS E SEXO E CIDADE */
        /* CAMPOS EXIBIDOS NA CONSULTA: CÓDIGO CLIENTE, NOME, NOME SOCIAL, CPF, DATA DE NASCIMENTO, CIDADE, SEXO E CELULAR */

        // CONSULTA CLIENTE POR CIDADE
        public DataTable ConsultaClienteCidade(string cidade)
        {
            string sql = $" SELECT codigo_cliente 'COD', nome 'Nome', nome_social 'Nome Social', cpf 'CPF', data_nascimento 'Nascimento', cidade 'Cidade', sexo 'Sexo', telefone_celular 'Celular' FROM cliente WHERE status = 1 AND cidade = '{cidade}' ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // CONSULTA CLIENTE POR SEXO
        public DataTable ConsultaClienteSexo(string sexo)
        {
            string sql = $" SELECT codigo_cliente 'COD', nome 'Nome', nome_social 'Nome Social', cpf 'CPF', data_nascimento 'Nascimento', cidade 'Cidade', sexo 'Sexo', telefone_celular 'Celular' FROM cliente WHERE status = 1 AND sexo = '{sexo}' ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // CONSULTA CLIENTE POR CPF
        public DataTable ConsultaClienteCpf(string cpf)
        {
            string sql = $" SELECT codigo_cliente 'COD', nome 'Nome', nome_social 'Nome Social', cpf 'CPF', data_nascimento 'Nascimento', cidade 'Cidade', sexo 'Sexo', telefone_celular 'Celular' FROM cliente WHERE status = 1 AND cpf = '{cpf}' ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // CONSULTA CLIENTE POR NOME INICIAL
        public DataTable ConsultaClienteNomeInicio(string nomeI)
        {
            string sql = $" SELECT codigo_cliente 'COD', nome 'Nome', nome_social 'Nome Social', cpf 'CPF', data_nascimento 'Nascimento', cidade 'Cidade', sexo 'Sexo', telefone_celular 'Celular' FROM cliente WHERE status = 1 AND nome LIKE '{nomeI}%' ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // CONSULTA CLIENTE POR NOME CONTÉM
        public DataTable ConsultaClienteNomeContem(string nomeC)
        {
            string sql = $" SELECT codigo_cliente 'COD', nome 'Nome', nome_social 'Nome Social', cpf 'CPF', data_nascimento 'Nascimento', cidade 'Cidade', sexo 'Sexo', telefone_celular 'Celular' FROM cliente WHERE status = 1 AND nome LIKE '%{nomeC}%' ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // CONSULTA CLIENTE POR DATA DE CADASTRO
        public DataTable ConsultaClienteCadastro(DateTime dataI, DateTime dataF)
        {
            string sql = $" SELECT codigo_cliente 'COD', nome 'Nome', nome_social 'Nome Social', cpf 'CPF', data_nascimento 'Nascimento', cidade 'Cidade', sexo 'Sexo', telefone_celular 'Celular' FROM cliente WHERE status = 1 AND CAST(data_cadastro AS DATE) BETWEEN '{dataI.ToString("yyyy-MM-dd")}' AND '{dataF.ToString("yyyy-MM-dd")}' ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // CONSULTA CLIENTE POR STATUS
        public DataTable ConsultaClienteStatus(int status)
        {
            string sql = $" SELECT codigo_cliente 'COD', nome 'Nome', nome_social 'Nome Social', cpf 'CPF', data_nascimento 'Nascimento', cidade 'Cidade', sexo 'Sexo', telefone_celular 'Celular' FROM cliente WHERE status = {status} ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        // CONSULTA CLIENTE POR SEXO E CIDADE
        public DataTable ConsultaClienteSexoCidade(string sexo, string cidade)
        {
            string sql = $" SELECT codigo_cliente 'COD', nome 'Nome', nome_social 'Nome Social', cpf 'CPF', data_nascimento 'Nascimento', cidade 'Cidade', sexo 'Sexo', telefone_celular 'Celular' FROM cliente WHERE status = 1 AND sexo = '{sexo}' AND cidade = '{cidade}' ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }


        // MÉTODO PARA BUSCAR TODOS OS DADOS DO CLIENTE SELECIONADO NO FORM DE CONSULTA
        public bool DadosCliente(int codigo)
        {
            string sql = $"SELECT * FROM cliente WHERE codigo_cliente = {codigo}";

            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDados(sql);

            if (dt.Rows.Count > 0)
            {
                codigo_cliente = Convert.ToInt32(dt.Rows[0]["codigo_cliente"]);
                nome = Convert.ToString(dt.Rows[0]["nome"]);
                nome_social = Convert.ToString(dt.Rows[0]["nome_social"]);
                data_nascimento = Convert.ToDateTime(dt.Rows[0]["data_nascimento"]);
                sexo = Convert.ToString(dt.Rows[0]["sexo"]);
                cpf = Convert.ToString(dt.Rows[0]["cpf"]);
                rg = Convert.ToString(dt.Rows[0]["rg"]);
                endereco = Convert.ToString(dt.Rows[0]["endereco"]);
                numero = Convert.ToInt32(dt.Rows[0]["numero"]);
                complemento = Convert.ToString(dt.Rows[0]["complemento"]);
                bairro = Convert.ToString(dt.Rows[0]["bairro"]);
                cidade = Convert.ToString(dt.Rows[0]["cidade"]);
                estado = Convert.ToString(dt.Rows[0]["estado"]);
                cep = Convert.ToString(dt.Rows[0]["CEP"]); // Baseado no BD
                telefone_residencial = Convert.ToString(dt.Rows[0]["telefone_residencial"]);
                telefone_celular = Convert.ToString(dt.Rows[0]["telefone_celular"]);
                email = Convert.ToString(dt.Rows[0]["email"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);

                return true;
            }
            else
            {
                return false;
            }
        }

        // MÉTODO PARA ATUALIZAR CLIENTE
        public int AtualizarCliente()
        {
            string sql = $"UPDATE cliente SET nome = '{nome}', nome_social = '{nome_social}', data_nascimento = '{data_nascimento.ToString("yyyy-MM-dd")}', sexo = '{sexo}', cpf = '{cpf}', rg = '{rg}', endereco = '{endereco}', numero = {numero}, complemento = '{complemento}', bairro = '{bairro}', cidade = '{cidade}', estado = '{estado}', CEP = '{cep}', telefone_residencial = '{telefone_residencial}', telefone_celular = '{telefone_celular}', email = '{email}', status = {status} WHERE codigo_cliente = {codigo_cliente}";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        // MÉTODO PARA EXCLUIR CLIENTE
        public int ExcluirCliente()
        {
            string sql = $"DELETE FROM cliente WHERE codigo_cliente = {codigo_cliente}";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        // MÉTODO PARA CARREGAR AS CIDADES CADASTRADAS NO BD PARA A COMBOBOX DE CONSULTA
        public DataTable BuscarCidadeCliente()
        {
            string sql = "SELECT DISTINCT cidade FROM cliente WHERE status = 1 ORDER BY cidade;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*MÉTODOS DE RELATÓRIO DE CLIENTE*/
        /*ANIVERSARIANTES DO MÊS*/
        public DataTable RelatorioClienteNiverMes(int mes)
        {
            string sql = $"SELECT cliente.codigo_cliente, cliente.nome, cliente.cpf, cliente.telefone_celular, cliente.data_nascimento, cliente.data_cadastro, cliente.sexo, cliente.cidade FROM cliente  WHERE cliente.status = 1 AND MONTH(cliente.data_nascimento) = {mes} ORDER BY cliente.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*clienteS POR IDADE*/
        public DataTable RelatorioClienteIdada(int idadeI, int idadeF)
        {
            string sql = $"SELECT cliente.codigo_cliente, cliente.nome, cliente.cpf, cliente.telefone_celular, cliente.data_nascimento, cliente.data_cadastro, cliente.sexo, cliente.cidade FROM cliente  WHERE cliente.status = 1 AND TIMESTAMPDIFF(YEAR, cliente.data_nascimento, NOW()) BETWEEN {idadeI} AND {idadeF} ORDER BY cliente.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*CLIENTES POR CIDADE*/
        public DataTable RelatorioClienteCidade(string cidade)
        {
            string sql = $"SELECT cliente.codigo_cliente, cliente.nome, cliente.cpf, cliente.telefone_celular, cliente.data_nascimento, cliente.data_cadastro, cliente.sexo, cliente.cidade FROM cliente  WHERE cliente.status = 1 AND cliente.cidade = '{cidade}' ORDER BY cliente.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*CLIENTES POR DATA DE CADASTRO*/
        public DataTable RelatorioClienteDataCadastro(DateTime dataI, DateTime dataF)
        {
            string sql = $"SELECT cliente.codigo_cliente, cliente.nome, cliente.cpf, cliente.telefone_celular, cliente.data_nascimento, cliente.data_cadastro, cliente.sexo, cliente.cidade FROM cliente  WHERE cliente.status = 1 AND CAST(cliente.data_cadastro AS DATE) BETWEEN '{dataI.ToString("yyyy-MM-dd")}' AND '{dataF.ToString("yyyy-MM-dd")}' ORDER BY cliente.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*CLIENTES POR SEXO*/
        public DataTable RelatorioClienteSexo(string sexo)
        {
            string sql = $"SELECT cliente.codigo_cliente, cliente.nome, cliente.cpf, cliente.telefone_celular, cliente.data_nascimento, cliente.data_cadastro, cliente.sexo, cliente.cidade FROM cliente  WHERE cliente.status = 1 AND cliente.sexo = '{sexo}' ORDER BY cliente.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*CLIENTES POR STATUS*/
        public DataTable RelatorioClienteStatus(int status)
        {
            string sql = $"SELECT cliente.codigo_cliente, cliente.nome, cliente.cpf, cliente.telefone_celular, cliente.data_nascimento, cliente.data_cadastro, cliente.sexo, cliente.cidade FROM cliente  WHERE cliente.status = {status} ORDER BY cliente.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);

        }


    }
}
