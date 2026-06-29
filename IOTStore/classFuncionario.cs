using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTStore
{
    class classFuncionario
    {
        public classFuncionario()//METODO CONSTRUTOR
        {
            codigo_funcionario = 0;
            nome = null;
            nome_social = null;
            data_nascimento = DateTime.Now;
            sexo = null;
            estado_civil = null;
            cpf = null;
            rg = null;
            salario = 0;
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
            usuario = null;
            senha = null;
            tipo_acesso = 0;
            foto = null;
            codigo_cargo = 0;

        }// FINAL DO METODO CONSTRUTOR

        //PROPRIEDADES

        public int codigo_funcionario { get; set; }
        public string nome { get; set; }
        public string nome_social { get; set; }
        public DateTime data_nascimento { get; set; }
        public string sexo { get; set; }
        public string estado_civil { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public decimal salario { get; set; }
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
        public string usuario { get; set; }
        public string senha { get; set; }
        public int tipo_acesso { get; set; }
        public string foto { get; set; }
        public int codigo_cargo { get; set; }

        //FIM DAS PROPRIEDADES


        //MÉTODOS - FUNCIONALIDADES DO SISTEMA
        // CADASTRAR FUNCIONARIO
        // CAMPOS DATE: propriedade.ToString("yyyy-MM-dd")
        // CAMPOS DECIMAL: propriedade.ToString().Replace("," , ".")
        // NÃO PODE MANDAR ASPAS SIMPLES EM CAMPOS DO TIPO BIT

        public int CadastrarFuncionario()
        {
            string sql = $"INSERT INTO funcionario VALUES(0, '{nome}', '{nome_social}', '{data_nascimento.ToString("yyyy-MM-dd")}', '{sexo}', '{estado_civil}', '{cpf}', '{rg}', '{salario.ToString().Replace(",", ".")}', '{endereco}', {numero}, '{complemento}', '{bairro}', '{cidade}', '{estado}', '{cep}', '{telefone_residencial}', '{telefone_celular}', '{email}', 1, NOW(), '{usuario}', '{senha}', {tipo_acesso}, '{foto}', {codigo_cargo});";

            classConexao cConexao = new classConexao();

            return cConexao.ExecutaQuery(sql);

        }

        /* CONSULTA DE FUNCIONARIO*/
        /* FILTROS: NOME(INICIO E CONTEM), CARGO, CIDADE, SEXO, CPF, DATA DE ADMISSÃO, STATUS E SEXO E CIDADE*/
        /* CAMPOS EXIBIDOS NA CONSULTA: CÓDIGO FUNCIONARIO, NOME, CPF, DATA DE NASCIMENTO, CIDADE, SEXO, CARGO E CELULAR*/

        //CONSULTA FUNCIONARIO POR CIDADE

        public DataTable ConsultaFuncionarioCidade(string cidade)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.cidade = '{cidade}' ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA FUNCIONARIO POR CARGO

        public DataTable ConsultaFuncionarioCargo(int cargo)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.codigo_cargo = {cargo} ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA FUNCIONARIO POR SEXO

        public DataTable ConsultaFuncionarioSexo(string sexo)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.sexo = '{sexo}' ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA FUNCIONARIO POR CPF

        public DataTable ConsultaFuncionarioCpf(string cpf)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.cpf = '{cpf}' ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA FUNCIONARIO POR NOME INICIAL

        public DataTable ConsultaFuncionarioNomeInicio(string nomeI)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.nome LIKE '{nomeI}%' ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA FUNCIONARIO POR NOME CONTEM

        public DataTable ConsultaFuncionarioNomeContem(string nomeC)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.nome LIKE '%{nomeC}%' ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA FUNCIONARIO POR DATA CADASTRO

        public DataTable ConsultaFuncionarioCadastro(DateTime dataI, DateTime dataF)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND CAST(funcionario.data_cadastro AS DATE) BETWEEN '{dataI.ToString("yyyy-MM-dd")}' AND '{dataF.ToString("yyyy-MM-dd")}' ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA FUNCIONARIO POR STATUS, NÃO TEM WHERE funcionario.status = 1 É SEMPRE status = {status}
        public DataTable ConsultaFuncionarioStatus(int status)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = {status} ORDER BY funcionario.nome; ";//CONSULTA POR STATUS NÃO TEM WHERE funcionario.status = 1 É SEMPRE status = {status}

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA FUNCIONARIO POR SEXO E CIDADE


        public DataTable ConsultaFuncionarioSexoCidade(string sexo, string cidade)
        {
            string sql = $" SELECT funcionario.codigo_funcionario 'COD', funcionario.nome 'Nome', funcionario.nome_social 'Nome Social', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', funcionario.cidade 'Cidade', funcionario.sexo 'Sexo', cargo.nome 'Cargo', funcionario.telefone_celular FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.sexo = '{sexo}' AND funcionario.cidade = '{cidade}' ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }


        //METODO PARA BUSCAR TODOS OS DADOS DO FUNCIONARIO SELECIONADO PELO USUARIO NO FORM DE CONSULTA
        public bool DadosFuncionario(int codigo)
        {

            string sql = $"SELECT * FROM funcionario WHERE codigo_funcionario = {codigo}";

            classConexao cConexao = new classConexao();
            //MONTAR DATATABLE QUE RECEBERÁ TODOS OS DADOS DO FUNCIONARIO SELECIONADO PELO USUÁRIO
            DataTable dt = cConexao.RetornaDados(sql);

            //SE A CONSULTA DER CERTO

            if (dt.Rows.Count > 0)
            {
                //EXIBIR TODOS OS CAMPOS DA TABELA FUNCIONARIO
                codigo_funcionario = Convert.ToInt32(dt.Rows[0]["codigo_funcionario"]);
                nome = Convert.ToString(dt.Rows[0]["nome"]);
                nome_social = Convert.ToString(dt.Rows[0]["nome_social"]);
                data_nascimento = Convert.ToDateTime(dt.Rows[0]["data_nascimento"]);
                sexo = Convert.ToString(dt.Rows[0]["sexo"]);
                estado_civil = Convert.ToString(dt.Rows[0]["estado_civil"]);
                cpf = Convert.ToString(dt.Rows[0]["cpf"]);
                rg = Convert.ToString(dt.Rows[0]["rg"]);
                salario = Convert.ToDecimal(dt.Rows[0]["salario"]);
                endereco = Convert.ToString(dt.Rows[0]["endereco"]);
                numero = Convert.ToInt32(dt.Rows[0]["numero"]);
                complemento = Convert.ToString(dt.Rows[0]["complemento"]);
                bairro = Convert.ToString(dt.Rows[0]["bairro"]);
                cidade = Convert.ToString(dt.Rows[0]["cidade"]);
                estado = Convert.ToString(dt.Rows[0]["estado"]);
                cep = Convert.ToString(dt.Rows[0]["cep"]);
                telefone_residencial = Convert.ToString(dt.Rows[0]["telefone_residencial"]);
                telefone_celular = Convert.ToString(dt.Rows[0]["telefone_celular"]);
                email = Convert.ToString(dt.Rows[0]["email"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                usuario = Convert.ToString(dt.Rows[0]["usuario"]);
                senha = Convert.ToString(dt.Rows[0]["senha"]);
                tipo_acesso = Convert.ToInt32(dt.Rows[0]["tipo_acesso"]);
                foto = Convert.ToString(dt.Rows[0]["foto"]);
                codigo_cargo = Convert.ToInt32(dt.Rows[0]["codigo_cargo"]);


                return true;
            }
            else
            {
                return false;
            }
        }

        //METODO PARA ATUALIZAR FUNCIONARIO

        public int AtualizarFuncionario()
        {
            string sql = $"UPDATE funcionario SET nome = '{nome}', nome_social = '{nome_social}', data_nascimento = '{data_nascimento.ToString("yyyy-MM-dd")}', sexo = '{sexo}', estado_civil = '{estado_civil}', cpf = '{cpf}', rg = '{rg}', salario =  '{salario.ToString().Replace(",", ".")}', endereco = '{endereco}', numero = {numero}, complemento = '{complemento}', bairro = '{bairro}', cidade = '{cidade}', estado = '{estado}', cep = '{cep}', telefone_residencial = '{telefone_residencial}', telefone_celular = '{telefone_celular}', email = '{email}', status = {status}, usuario = '{usuario}', senha = '{senha}', tipo_acesso = {tipo_acesso}, foto = '{foto}', codigo_cargo = {codigo_cargo} WHERE codigo_funcionario = {codigo_funcionario}";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        //METODO PARA EXCLUIR FUNCIONARIO

        public int ExcluirFuncionario()
        {
            string sql = $"DELETE FROM funcionario WHERE codigo_funcionario = {codigo_funcionario}";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }


        //MÉTODO PARA CARREGAR AS CIDADES CADASTRADAS NO BD DA TABELA DE FUNCIONARIOS NO FORM DE CONSULTA DE FUNCIONARIOS

        public DataTable BuscarCidade()
        {
            string sql = "SELECT DISTINCT cidade FROM funcionario WHERE status = 1 ORDER BY cidade;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*MÉTODOS DE RELATÓRIO DE FUNCIONARIO*/
        /*ANIVERSARIANTES DO MÊS*/
        public DataTable RelatorioFuncionarioNiverMes(int mes)
        {
            string sql = $"SELECT funcionario.nome, funcionario.cpf, funcionario.telefone_celular, funcionario.data_nascimento, funcionario.data_cadastro, funcionario.sexo, funcionario.cidade, cargo.nome 'codigo_cargo' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND MONTH(funcionario.data_nascimento) = {mes} ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*fUNCIONARIOS POR IDADE*/
        public DataTable RelatorioFuncionarioIdada(int idadeI, int idadeF)
        {
            string sql = $"SELECT funcionario.nome, funcionario.cpf, funcionario.telefone_celular, funcionario.data_nascimento, funcionario.data_cadastro, funcionario.sexo, funcionario.cidade, cargo.nome 'codigo_cargo' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND TIMESTAMPDIFF(YEAR, funcionario.data_nascimento, NOW()) BETWEEN {idadeI} AND {idadeF} ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*FUNCIONARIOS POR CARGO*/
        public DataTable RelatorioFuncionarioCargo(int cargo)
        {
            string sql = $"SELECT funcionario.nome, funcionario.cpf, funcionario.telefone_celular, funcionario.data_nascimento, funcionario.data_cadastro, funcionario.sexo, funcionario.cidade, cargo.nome 'codigo_cargo' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.codigo_cargo = {cargo} ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*FUNCIONARIOS POR CIDADE*/
        public DataTable RelatorioFuncionarioCidade(string cidade)
        {
            string sql = $"SELECT funcionario.nome, funcionario.cpf, funcionario.telefone_celular, funcionario.data_nascimento, funcionario.data_cadastro, funcionario.sexo, funcionario.cidade, cargo.nome 'codigo_cargo' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.cidade = '{cidade}' ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*FUNCIONARIOS POR DATA DE ADMISSÃO*/
        public DataTable RelatorioFuncionarioDataCadastro(DateTime dataI, DateTime dataF)
        {
            string sql = $"SELECT funcionario.nome, funcionario.cpf, funcionario.telefone_celular, funcionario.data_nascimento, funcionario.data_cadastro, funcionario.sexo, funcionario.cidade, cargo.nome 'codigo_cargo' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND CAST(funcionario.data_cadastro AS DATE) BETWEEN '{dataI.ToString("yyyy-MM-dd")}' AND '{dataF.ToString("yyyy-MM-dd")}' ORDER BY funcionario.nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*FUNCIONARIOS POR SEXO*/
        public DataTable RelatorioFuncionarioSexo(string sexo)
        {
            string sql = $"SELECT funcionario.nome, funcionario.cpf, funcionario.telefone_celular, funcionario.data_nascimento, funcionario.data_cadastro, funcionario.sexo, funcionario.cidade, cargo.nome 'codigo_cargo' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.sexo = '{sexo}' ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        /*FUNCIONARIOS POR STATUS*/
        public DataTable RelatorioFuncionarioStatus(int status)
        {
            string sql = $"SELECT funcionario.nome, funcionario.cpf, funcionario.telefone_celular, funcionario.data_nascimento, funcionario.data_cadastro, funcionario.sexo, funcionario.cidade, cargo.nome 'codigo_cargo' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = {status} ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);

        }
    }
}
