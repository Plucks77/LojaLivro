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
        // GET: Livro
        public ActionResult Index()
        {
            return View( (from p in db.Livro where p.Situation == true select p).ToList()
                /*db.Livro.ToList()*/);
        }

        public ActionResult Livros()
        {
            if (Session["ClienteID"] != null)
            {
                return View((from p in db.Livro where p.Situation == true select p).ToList());
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Livros(string Busca, string botao1)
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

        [HttpPost]
        public ActionResult Index(string Busca, string botao1)
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

        // GET: Livro/Details/5
        public ActionResult Details(int? id)
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

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Autor,Genero,Descricao,Valor,Situation")] Livro.Model.Livro livro)
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

        // GET: Livro/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Livro/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Autor,Genero,Descricao,Valor,Situation")] Livro.Model.Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int? id)
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
    }
}
