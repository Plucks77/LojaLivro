using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Livro.Model;


namespace Livro.View.Controllers
{
    public class CarrinhoController : Controller
    {
        Model.Controller.CLivro _c = new Model.Controller.CLivro();
        public ActionResult Index()
        {
            var lista = (List<Model.Livro>)Session["Carrinho"];
            List<Model.Livro> x = lista;
            Model.Livro Remover = new Model.Livro();
            foreach(Model.Livro j in x)
            {
                if (j.ID == 0)
                {
                    Remover = j;               
                }
            }
             x.Remove(Remover);
            if (x.Count == 0)
            {
                return RedirectToAction("Vazio");
            }
            return View(x);
        }

        public ActionResult Vazio()
        {
            return View();
        }

        public ActionResult Remover(int id)
        {
            Model.Livro rem = new Model.Livro();
            var lista = (List<Model.Livro>)Session["Carrinho"];
            List<Model.Livro> x = lista;
            bool t = true;
            foreach(Model.Livro j in x)
            {
                if (j.ID == id)
                {
                    rem = j;
                }
            }
            t = x.Remove(rem);
            Session["Carrinho"] = x;        
            return RedirectToAction("Index");
        }

        public ActionResult Confirmado()
        {
            var lista = (List<Model.Livro>)Session["Carrinho"];
            List<Model.Livro> x = lista;
            foreach(Model.Livro rem in x)
            {
                _c.Desabilitar(rem.ID);
            }
            Session["Carrinho"] = null;
            Model.Livro a = new Model.Livro();
            List<Model.Livro> b = new List<Model.Livro>();
            b.Add(a);
            Session["Carrinho"] = b;
            return View();
        }



    }
}
