using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro.Model.Repositories
{
    public class RepositorieAdmin
    {
        AspNetLivroEntities4 _E;

        public RepositorieAdmin()
        {
            _E = new AspNetLivroEntities4();
        }

        public void Incluir(Admin o)
        {
            _E.Admin.Add(o);
            _E.SaveChanges();
        }

        public void Alterar(Admin o)
        {
            _E.Entry(o).State = System.Data.Entity.EntityState.Modified;
            _E.SaveChanges();
        }

        public void Excluir(Admin o)
        {
            _E.Entry(o).State = System.Data.Entity.EntityState.Deleted;
            _E.SaveChanges();
        }


    }
}
