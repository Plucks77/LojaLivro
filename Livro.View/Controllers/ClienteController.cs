using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livro.Model;
using Livro.Model.Controller;
namespace Livro.View.Controllers
{
    public class ClienteController : Controller
    {
        AspNetLivroEntities4 db = new AspNetLivroEntities4();
        CCliente _c = new CCliente();
        // GET: Cliente
        public ActionResult Index(Cliente c)
        {
            if (Session["ClienteID"] != null)
            {
                return View(c);                
            }
            return RedirectToAction("Index","Home");
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
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Perfil(Cliente oCliente)
        {
            if(Session["ClienteID"] != null)
            {
            _c.Alterar(oCliente);
            Session["ClienteNome"] = oCliente.Nome;
            return View();
            }
            return RedirectToAction("Index", "Home");

        }


    }
}