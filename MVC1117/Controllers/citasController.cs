using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC1117.Models;

namespace MVC1117.Controllers
{
    public class citasController : Controller
    {
        private hospitalEntities db = new hospitalEntities();

        // GET: citas
        public ActionResult Index()
        {
            var cita = db.cita.Include(c => c.medico).Include(c => c.paciente);
            return View(cita.ToList());
        }

        // GET: citas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: citas/Create
        public ActionResult Create()
        {
            ViewBag.id_medico1 = new SelectList(db.medico, "id_medico", "nom_medico");
            ViewBag.id_paciente1 = new SelectList(db.paciente, "id_paciente", "tip_doc");
            return View();
        }

        // POST: citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_cita,fecha,hora,valor,diagnostico,nom_acompañante,id_paciente1,id_medico1,activo")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_medico1 = new SelectList(db.medico, "id_medico", "nom_medico", cita.id_medico1);
            ViewBag.id_paciente1 = new SelectList(db.paciente, "id_paciente", "tip_doc", cita.id_paciente1);
            return View(cita);
        }

        // GET: citas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_medico1 = new SelectList(db.medico, "id_medico", "nom_medico", cita.id_medico1);
            ViewBag.id_paciente1 = new SelectList(db.paciente, "id_paciente", "tip_doc", cita.id_paciente1);
            return View(cita);
        }

        // POST: citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_cita,fecha,hora,valor,diagnostico,nom_acompañante,id_paciente1,id_medico1,activo")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_medico1 = new SelectList(db.medico, "id_medico", "nom_medico", cita.id_medico1);
            ViewBag.id_paciente1 = new SelectList(db.paciente, "id_paciente", "tip_doc", cita.id_paciente1);
            return View(cita);
        }

        // GET: citas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cita cita = db.cita.Find(id);
            db.cita.Remove(cita);
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
