using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Livro.Model;
using Livro.Model.Controller;
namespace Livro.View.Controllers
{
    public class CarrinhoController : Controller
    {
        CLivro _c;
        CVenda _cvenda;
        CLivrosVendidos _cLivrosVendidos;

        public CarrinhoController()
        {
            _c = new CLivro();
            _cvenda = new CVenda();
            _cLivrosVendidos = new CLivrosVendidos();
        }

        public ActionResult Index()
        {
            if(Session["ClienteID"] != null)
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
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Vazio()
        {
            if(Session["ClienteID"] != null)
            {
                return View();
            }
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Remover(int id)
        {
            Model.Livro rem = new Model.Livro();
            var lista = (List<Model.Livro>)Session["Carrinho"];
            List<Model.Livro> x = lista;
            foreach(Model.Livro j in x)
            {
                if (j.ID == id)
                {
                    rem = j;
                }
            }
            x.Remove(rem);
            Session["Carrinho"] = x;
            int xx = int.Parse(Session["QtdCarrinho"].ToString());
            xx--;
            if(xx == 0)
            {
                Session["QtdCarrinho"] = null;
            }
            else
            {
                Session["QtdCarrinho"] = xx;
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Confirmado()
        {
            if(Session["ClienteID"] != null)
            {
            var lista = (List<Model.Livro>)Session["Carrinho"];
            List<Model.Livro> x = lista;
                decimal ValorTotall = 0;
            foreach(Model.Livro rem in x)
            {
                _c.Desabilitar(rem.ID);
                 ValorTotall = ValorTotall + rem.Valor;
            }
            Session["Carrinho"] = null;
            Model.Livro a = new Model.Livro();
            List<Model.Livro> b = new List<Model.Livro>();
            b.Add(a);
            Session["Carrinho"] = b;
            Session["QtdCarrinho"] = null;
                Venda V = new Venda();
                V.IDCliente = int.Parse (Session["ClienteID"].ToString());
                V.Data = DateTime.Now;
                V.ValorTotal = ValorTotall;
                _cvenda.Incluir(V);

                
                foreach (Model.Livro vendidos in x)
                {
                    LivrosVendidos LV = new LivrosVendidos();
                    LV.IDVenda = V.ID;
                    LV.IDLivro = vendidos.ID;
                    LV.Valor = vendidos.Valor;
                    _cLivrosVendidos.Incluir(LV);
                }

                    return View();
            }
            return RedirectToAction("Index", "Home");

        }



    }
}
