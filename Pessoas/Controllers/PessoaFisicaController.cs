using Pessoas.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientesApi.Models;

namespace Pessoas.Controllers
{

    [Produces("application/json")]
    [Route("api/PessoaFisica")]
    public class PessoaFisicaController : Controller
    {
        private IPessoaFisicaRepository pessoaFisicaRepository;
        private static List<PessoaFisica> PessoaFisica = new List<PessoaFisica>();
        public PessoaFisicaController(IPessoaFisicaRepository _pessoaFisicaRepository)
        {
            pessoaFisicaRepository = _pessoaFisicaRepository;
        }

        [HttpGet]
        public List<PessoaFisica> GetPessoasFisicas()
        {
            if(PessoaFisica == null)
                return new List<PessoaFisica>();
            return PessoaFisica;
            /*var result = pessoaFisicaRepository.getAll();
            if (result == null)
            {
                return null;
            }
            return PessoaFisica;*/
        }

        [HttpGet("{pfId}")]
        public PessoaFisica GetPessoasFisicasId(int pfId)
        {

            return PessoaFisica[pfId - 1];
            /*var result = pessoaFisicaRepository.getAllId(pfId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);*/
        }

        [HttpPost]
        public bool InsertPessoasFisicas([FromBody] PessoaFisica pf)
        {
            pf.id = PessoaFisica.Count() + 1;
            if(pf == null)   
                return false;

            PessoaFisica.Add(pf);

            return true;
            /*var result = pessoaFisicaRepository.getAllId(pfId);
            if (result == null)
            {
                return false;
            }
            return true;*/
        }
    }
}
