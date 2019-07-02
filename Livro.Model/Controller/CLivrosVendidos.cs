using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Controller
{
    public class CLivrosVendidos
    {
        Repositories.RepositorieLivrosVendidos L;
        public CLivrosVendidos()
        {
            L = new Repositories.RepositorieLivrosVendidos();
        }

        public void Incluir(LivrosVendidos oLivros)
        {
            L.Incluir(oLivros);
        }

        public void Excluir(LivrosVendidos oLivros)
        {
            L.Excluir(oLivros);
        }
    }
}
