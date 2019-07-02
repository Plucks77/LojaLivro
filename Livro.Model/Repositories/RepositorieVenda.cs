using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Repositories
{
    public class RepositorieVenda
    {
        AspNetLivroEntities4 E;

        public RepositorieVenda()
        {
            E = new AspNetLivroEntities4();
        }

        public void Incluir(Venda oVenda)
        {
            E.Venda.Add(oVenda);
            E.SaveChanges();
        }

        public void Excluir(Venda oVenda)
        {
            E.Entry(oVenda).State = System.Data.Entity.EntityState.Deleted;
            E.SaveChanges();
        }
    }
}
