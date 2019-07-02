using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Livro.Model;

namespace Livro.View.Controllers
{
    public class LivroController : Controller
    {
        private AspNetLivroEntities4 db = new AspNetLivroEntities4();
        Model.Controller.CLivro _c = new Model.Controller.CLivro();

        public LivroController()
        {

        }

        // GET: Livro
        public ActionResult Index()
        {
            if(Session["AdminID"] != null)
            {
               return View((from p in db.Livro where p.Situation == true select p).ToList());
            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Livros()
        {
            if (Session["ClienteID"] != null)
            {
                return View((from p in db.Livro where p.Situation == true select p).ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Livros(string Busca, string botao)
        {
            if (Session["ClienteID"] != null)
            {
                if (botao == "Pesquisar")
            {
                List<Model.Livro> ll = _c.SelecionarPorTitulo(Busca);
                return View(ll);
            }
            if (botao == "Limpar")
            {
                List<Model.Livro> ll = _c.SelecionarTodosDisponiveis();
                return View(ll);
            }
            return View();
            }
            return RedirectToAction("Index", "Home");


        }

        [HttpPost]
        public ActionResult Index(string Busca, string botao1)
        {
            if (Session["AdminID"] != null)
            {
               if (botao1 == "Pesquisar")
            {
                List<Model.Livro> ll = _c.SelecionarPorTitulo(Busca);
                return View(ll);
            }
            if (botao1 == "Limpar")
            {
                List<Model.Livro> ll = _c.SelecionarTodosDisponiveis();
                return View(ll);
            }
            return View();
            }
            return RedirectToAction("Index", "Home");



        }

        // GET: Livro/Details/5
        public ActionResult Details(int? id)
        {
            if(Session["AdminID"] != null)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            Livro.Model.Livro livro = db.Livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
            }
            return RedirectToAction("Index", "Home");

        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            if(Session["AdminID"] != null)
            {
            return View();
            }
            return RedirectToAction("Index", "Home");

        }

        // POST: Livro/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Autor,Genero,Descricao,Valor,Situation")] Livro.Model.Livro livro)
        {
            if(Session["AdminID"] != null)
            {
            if (ModelState.IsValid)
            {
                livro.Situation = true;
                db.Livro.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livro);
            }
            return RedirectToAction("Index", "Home");

        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int? id)
        {
            if(Session["AdminID"] != null)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro.Model.Livro livro = db.Livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
            }
            return RedirectToAction("Index", "Home");

        }

        // POST: Livro/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Autor,Genero,Descricao,Valor,Situation")] Livro.Model.Livro livro)
        {
            if(Session["AdminID"] != null)
            {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
            }
            return RedirectToAction("Index", "Home");

        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int? id)
        {
            if(Session["AdminID"] != null)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro.Model.Livro livro = db.Livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
            }
            return RedirectToAction("Index", "Home");

        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro.Model.Livro livro = db.Livro.Find(id);
            db.Livro.Remove(livro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AdicionarCarrinho(int id)
        {
            if(Session["ClienteID"] != null)
            {
            var lista = (List<Model.Livro>)Session["Carrinho"];
            //List<Model.Livro> x = lista;
            Model.Livro vv = _c.SelecionarID(id);
            lista.Add(vv);
            Session["Carrinho"] = lista;
            int x;
            if (Session["QtdCarrinho"] is null)
            {
                x = 0;
            }
            else
            {
                x = int.Parse(Session["QtdCarrinho"].ToString());
            }
            x++;
            Session["QtdCarrinho"] = x;
            return RedirectToAction("Livros");
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
