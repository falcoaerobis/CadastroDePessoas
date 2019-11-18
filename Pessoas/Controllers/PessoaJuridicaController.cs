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
    [Route("api/PessoaJuridica")]
    public class PessoaJuridicaController : Controller
    {
        private IPessoaJuridicaRepository pessoaJuridicaRepository;
        private static List<PessoaJuridica> PessoaJuridica = new List<PessoaJuridica>();
        public PessoaJuridicaController(IPessoaJuridicaRepository _pessoaJuridicaRepository)
        {
            pessoaJuridicaRepository = _pessoaJuridicaRepository;
        }

        [HttpGet]
        public List<PessoaJuridica> GetPessoasJuridicas()
        {
            if(PessoaJuridica == null)
                return new List<PessoaJuridica>();
            return PessoaJuridica;
            /*var result = pessoaFisicaRepository.getAll();
            if (result == null)
            {
                return null;
            }
            return PessoaFisica;*/
        }

        [HttpGet("{pfId}")]
        public PessoaJuridica GetPessoasJuricasId(int pjId)
        {

            return PessoaJuridica[pjId - 1];
            /*var result = pessoaFisicaRepository.getAllId(pfId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);*/
        }

        [HttpPost]
        public bool InsertPessoasJuridicas([FromBody] PessoaJuridica pj)
        {
            
            if(pj == null)   
                return false;

            pj.id = PessoaJuridica.Count() + 1;
            PessoaJuridica.Add(pj);

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
