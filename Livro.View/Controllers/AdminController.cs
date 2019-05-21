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
            return View();
        }

        public ActionResult Cadastro()
        {
            
            return View(db.Admin.ToList());
        }
    }
}