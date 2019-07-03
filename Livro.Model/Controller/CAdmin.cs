using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Controller
{
    public class CAdmin
    {
        Repositories.RepositorieAdmin _A;

        public CAdmin()
        {
            _A = new Repositories.RepositorieAdmin();
        }

        public void Incluir(Admin o)
        {
            _A.Incluir(o);
        }

        public void Alterar(Admin o)
        {
            _A.Alterar(o);
        }

        public void Excluir(Admin o)
        {
            _A.Excluir(o);
        }
    }
}
