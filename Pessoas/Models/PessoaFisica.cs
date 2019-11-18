using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientesApi.Models
{
    public class PessoaFisica
    {
        public int id { get; set; }
        public long cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public long cep { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }

        public PessoaFisica()
        {
            
        }
    }
}