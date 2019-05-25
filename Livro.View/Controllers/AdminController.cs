using Livro.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livro.View.Controllers
{
    public class AdminController : Controller
    {
        private AspNetLivroEntities3 db = new AspNetLivroEntities3();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["AdminID"] != null)
            {
                return View();
            }
            return HttpNotFound();
        }

        public ActionResult Cadastro()
        {
            if (Session["AdminID"] != null)
            {
                return View(db.Admin.ToList());
            }
            return HttpNotFound();
        }

        public ActionResult Clientes()
        {
            if (Session["AdminID"] != null)
            {
                return View(db.Cliente.ToList());
            }
            return HttpNotFound();
        }
    }
}