using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Controller
{
   public class CCliente
    {
        Repositories.RepositorieCliente _r;

        public CCliente()
        {
            _r = new Repositories.RepositorieCliente();
        }

        public void Incluir(Cliente oCliente)
        {
            _r.Incluir(oCliente);
        }

        public void Alterar(Cliente oCliente)
        {
            _r.Alterar(oCliente);
        }

        public void Excluir(Cliente oCliente)
        {
            _r.Excluir(oCliente);
        }
    }
}
