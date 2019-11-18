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
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        IConfiguration configuration;
        public PessoaJuridicaRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        //Pegar os dados de uma pessoa fisica com base em seu id
        public object getAllId(int Id)
        {
            return new PessoaJuridica();
            /*object result = null;
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

            return result;*/
        }

        //Pegar todas as pessoas fisicas
        public object getAll()
        {
            return new List<PessoaJuridica>();
            /*object result = null;
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

            return result;*/
        }

        public bool insert(PessoaJuridica pj){
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("pj_razaoSocial", OracleDbType.Int32, ParameterDirection.Input, pj.razaoSocial);
                dyParam.Add("pj_nomeFantasia", OracleDbType.Int32, ParameterDirection.Input, pj.nomeFantasia);
                dyParam.Add("pj_cnpj", OracleDbType.Int32, ParameterDirection.Input, pj.cnpj);
                dyParam.Add("pj_cep", OracleDbType.Int32, ParameterDirection.Input, pj.cep);
                dyParam.Add("pj_logradouro", OracleDbType.Int32, ParameterDirection.Input, pj.logradouro);
                dyParam.Add("pj_numero", OracleDbType.Int32, ParameterDirection.Input, pj.numero);
                dyParam.Add("pj_complemento", OracleDbType.Int32, ParameterDirection.Input, pj.complemento);
                dyParam.Add("pj_bairro", OracleDbType.Int32, ParameterDirection.Input, pj.bairro);
                dyParam.Add("pj_cidade", OracleDbType.Int32, ParameterDirection.Input, pj.cidade);
                dyParam.Add("pj_uf", OracleDbType.Int32, ParameterDirection.Input, pj.uf);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "sp_insert_pessoasjuridicas";

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