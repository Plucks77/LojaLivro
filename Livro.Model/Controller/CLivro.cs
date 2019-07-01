using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Controller
{
    public class CLivro
    {
        Repositories.RepositorieLivro R = new Repositories.RepositorieLivro();

        public List<Livro> SelecionarTodosDisponiveis()
        {
            return R.SelecionarTodosDisponiveis();
        }

        public List<Livro> SelecionarPorTitulo(string titulo)
        {
            return R.SelecionarPorTitulo(titulo);
        }

        public Livro SelecionarID(int id)
        {
            return R.SelecionarID(id);
        }

        public void Alterar(Livro oLivro)
        {
            R.Alterar(oLivro);
        }

        public void Desabilitar(int id)
        {
            R.Desabilitar(id);
        }
    }
}
