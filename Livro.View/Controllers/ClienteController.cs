using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livro.View.Models;

namespace Livro.View.Controllers
{
    public class ClienteController : Controller
    {
        AspNetLivroEntities3 db = new AspNetLivroEntities3();
        // GET: Cliente
        public ActionResult Index(Cliente c)
        {
            if (Session["ClienteID"] != null)
            {
                return View(c);
            }
            return HttpNotFound();
        }




        public ActionResult Perfil()
        {
            if (Session["ClienteID"] != null)
            {
                int k = int.Parse(Session["ClienteID"].ToString());
                Cliente c = (from p in db.Cliente where p.ID == k select p).FirstOrDefault();
                if (c != null)
                {
                    return View(c);
                }
            }
            return HttpNotFound();
        }


    }
}