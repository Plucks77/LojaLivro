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
            return View(c);
        }

        public ActionResult Perfil(Cliente c)
        {
            return View(c);
        }

        
    }
}