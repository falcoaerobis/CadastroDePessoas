using Pessoas.Oracle;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;
using ClientesApi.Models;

namespace Pessoas.Repository
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        IConfiguration configuration;
        public PessoaFisicaRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        //Pegar os dados de uma pessoa fisica com base em seu id
        public object getAllId(int Id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("pf_id", OracleDbType.Int32, ParameterDirection.Input, Id);
                dyParam.Add("pessoacursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "sp_get_pessoasfisicasId";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        //Pegar todas as pessoas fisicas
        public object getAll()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("pessoacursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "sp_get_pessoasfisicas";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool insert(PessoaFisica pf){
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("pf_nome", OracleDbType.Int32, ParameterDirection.Input, pf.nome);
                dyParam.Add("pf_sobrenome", OracleDbType.Int32, ParameterDirection.Input, pf.sobrenome);
                dyParam.Add("pf_cpf", OracleDbType.Int32, ParameterDirection.Input, pf.cpf);
                dyParam.Add("pf_dataNascimento", OracleDbType.Int32, ParameterDirection.Input, pf.dataNascimento);
                dyParam.Add("pf_cep", OracleDbType.Int32, ParameterDirection.Input, pf.cep);
                dyParam.Add("pf_logradouro", OracleDbType.Int32, ParameterDirection.Input, pf.logradouro);
                dyParam.Add("pf_numero", OracleDbType.Int32, ParameterDirection.Input, pf.numero);
                dyParam.Add("pf_complemento", OracleDbType.Int32, ParameterDirection.Input, pf.complemento);
                dyParam.Add("pf_bairro", OracleDbType.Int32, ParameterDirection.Input, pf.bairro);
                dyParam.Add("pf_cidade", OracleDbType.Int32, ParameterDirection.Input, pf.cidade);
                dyParam.Add("pf_uf", OracleDbType.Int32, ParameterDirection.Input, pf.uf);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "sp_insert_pessoasfisicas";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("DBConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}