using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Controller
{
    public class CVenda
    {
        Repositories.RepositorieVenda V;

        public CVenda()
        {
            V = new Repositories.RepositorieVenda();
        }

        public void Incluir(Venda oVenda)
        {
            V.Incluir(oVenda);
        }

        public void Excluir(Venda oVenda)
        {
            V.Excluir(oVenda);
        }
    }
}
