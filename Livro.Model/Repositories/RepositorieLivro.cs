using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Repositories
{
    public class RepositorieLivro
    {
        AspNetLivroEntities4 d = new AspNetLivroEntities4();

        public List<Livro> SelecionarTodosDisponiveis()
        {
            return (from p in d.Livro where p.Situation == true select p).ToList();
        }

        public List<Livro> SelecionarPorTitulo(string titulo)
        {
            return d.Livro.SqlQuery("SELECT * FROM livro WHERE Titulo LIKE '%" + titulo + "%' AND Situation = 1").ToList();
            //return (from p in e.Livro where p.Titulo == titulo select p).ToList();
        }
    }
}
