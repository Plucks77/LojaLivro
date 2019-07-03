using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livro.Model;
using Livro.Model.Controller;
namespace Livro.View.Controllers
{
    public class HomeController : Controller
    {
        CCliente _c;

        public HomeController()
        {
            _c = new CCliente();
        }

        // GET: Login
        public ActionResult Index()
        {            
            Session["ClienteID"] = null;
            Session["AdminNome"] = null;
            Session.Clear();
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult VerificaAcesso(string rLogin, string rSenha)
        {
            AspNetLivroEntities4 E = new AspNetLivroEntities4();
            Cliente x = new Cliente();
            Admin y = new Admin();
            x = (from p in E.Cliente where p.Login == rLogin && p.Senha == rSenha select p).FirstOrDefault();
            y = (from p in E.Admin where p.Login == rLogin && p.Senha == rSenha select p).FirstOrDefault();
            if (x == null && y == null)
            {
                return View("Index");
            }
            else
            {
                if (y != null)
                {
                    Session["AdminNome"] = y.Nome;
                    Session["AdminID"] = y.ID;
                    return RedirectToAction("index","Admin");                   
                }
                if (x != null)
                {
                    Session["ClienteNome"] = x.Nome;
                    Session["ClienteID"] = x.ID;
                    Model.Livro a = new Model.Livro();
                    List<Model.Livro> b = new List<Model.Livro>();
                    b.Add(a);
                    Session["Carrinho"] = b;
                    return RedirectToAction("index", "Cliente",x);                                        
                }
                return View("erro");
            }
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Cliente oCliente)
        {
            if(oCliente != null)
            {
                Session["ClienteNome"] = oCliente.Nome;
                
                Session["QtdCarrinho"] = null;
                Model.Livro a = new Model.Livro();
                List<Model.Livro> b = new List<Model.Livro>();
                b.Add(a);
                Session["Carrinho"] = b;
                _c.Incluir(oCliente);
                Session["ClienteID"] = oCliente.ID;
                return RedirectToAction("index","Cliente");
            }
            return View("CriarConta");
        }
    }
}