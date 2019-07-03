using Livro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livro.Model.Controller;
using System.Net;

namespace Livro.View.Controllers
{
    public class AdminController : Controller
    {
        private AspNetLivroEntities4 db = new AspNetLivroEntities4();
        CAdmin _C = new CAdmin();
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

        public ActionResult Create()
        {
            if(Session["AdminID"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin oAdmin)
        {
            if (Session["AdminID"] != null)
            {
                _C.Incluir(oAdmin);
                return RedirectToAction("Cadastro");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int? id)
        {
            if (Session["AdminID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Livro.Model.Admin Admin = db.Admin.Find(id);
                if (Admin == null)
                {
                    return HttpNotFound();
                }
                return View(Admin);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Login,Senha,Email,Telefone")] Livro.Model.Admin admin)
        {
            if (Session["AdminID"] != null)
            {
                if (ModelState.IsValid)
                {
                    _C.Alterar(admin);
                    return RedirectToAction("Cadastro");
                }
                return RedirectToAction("Cadastro");
            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Delete(int? id)
        {
            if (Session["AdminID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Livro.Model.Admin Admin = db.Admin.Find(id);
                if (Admin == null)
                {
                    return HttpNotFound();
                }
                return View(Admin);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro.Model.Admin Admin = db.Admin.Find(id);
            _C.Excluir(Admin);
            return RedirectToAction("Cadastro");
        }
    }
}