using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientesApi.Models;

namespace Pessoas.Repository
{
    public interface IPessoaFisicaRepository
    {
        object getAll();

        object getAllId(int Id);

        bool insert(PessoaFisica pf);
    }
}
