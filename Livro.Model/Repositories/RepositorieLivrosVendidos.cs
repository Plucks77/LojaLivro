using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Repositories
{
   public class RepositorieLivrosVendidos
    {
        AspNetLivroEntities4 E;

        public RepositorieLivrosVendidos()
        {
            E = new AspNetLivroEntities4();
        }

        public void Incluir(LivrosVendidos oLivros)
        {
            E.LivrosVendidos.Add(oLivros);
            E.SaveChanges();
        }

        public void Excluir(LivrosVendidos oLivros)
        {
            E.Entry(oLivros).State = System.Data.Entity.EntityState.Deleted;
            E.SaveChanges();
        }
    }
}
