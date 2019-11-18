using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientesApi.Models
{
    public class PessoaJuridica
    {
        public int id { get; set; }
        public long cnpj { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public long cep { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string complemento { get; set; }

        public PessoaJuridica()
        {

        }
    }
}