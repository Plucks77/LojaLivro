using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livro.View.Models;

namespace Livro.View.Controllers
{
    public class HomeController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {            
            Session["ClienteID"] = null;
            Session["AdminNome"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult VerificaAcesso(string rLogin, string rSenha)
        {
            AspNetLivroEntities3 E = new AspNetLivroEntities3();
            Cliente x = new Cliente();
            Admin y = new Admin();
            x = (from p in E.Cliente where p.Login == rLogin && p.Senha == rSenha select p).FirstOrDefault();
            y = (from p in E.Admin where p.Login == rLogin && p.Senha == rSenha select p).FirstOrDefault();
            if (x == null && y == null)
            {
                return View("erro");
            }
            else
            {
                if (y != null)
                {
                    Session["AdminNome"] = y.Nome;
                    Session["AdminID"] = y.ID;
                    return RedirectToAction("index","Admin");
                   // return View("Views/Admin/index.cshtml");
                }
                if (x != null)
                {
                    Session["ClienteNome"] = x.Nome;
                    Session["ClienteID"] = x.ID;                    
                    return RedirectToAction("index", "Cliente",x);                    
                    //return View("Views/Cliente/index.cshtml");
                }
                return View("erro");
            }
        }
    }
}