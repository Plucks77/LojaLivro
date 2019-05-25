using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Repositories
{
    public class RepositorieCliente
    {
        AspNetLivroEntities4 e;

        public RepositorieCliente()
        {
            e = new AspNetLivroEntities4();
        }

        public void Incluir(Cliente oCliente)
        {
            e.Entry(oCliente).State = System.Data.Entity.EntityState.Added;
            e.SaveChanges();
        }

        public void Alterar(Cliente oCliente)
        {
            e.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
            e.SaveChanges();
        }

        public void Excluir(Cliente oCliente)
        {
            e.Entry(oCliente).State = System.Data.Entity.EntityState.Deleted;
            e.SaveChanges();
        }
    }
}
