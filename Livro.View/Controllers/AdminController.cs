using Livro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livro.View.Controllers
{
    public class AdminController : Controller
    {
        private AspNetLivroEntities4 db = new AspNetLivroEntities4();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["AdminID"] != null)
            {
                return View(db.Cliente.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Cadastro()
        {
            if (Session["AdminID"] != null)
            {
                return View(db.Admin.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Clientes()
        {
            if (Session["AdminID"] != null)
            {
                return View(db.Cliente.ToList());
            }
            return RedirectToAction("Index", "Home");
        }
    }
}