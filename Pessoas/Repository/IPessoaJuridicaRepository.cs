using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientesApi.Models;

namespace Pessoas.Repository
{
    public interface IPessoaJuridicaRepository
    {
        object getAll();

        object getAllId(int Id);

        bool insert(PessoaJuridica pj);
    }
}
