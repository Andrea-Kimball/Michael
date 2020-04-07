using Michael.Data;
using Michael.Models.Era;
using Michael.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Michael.Controllers
{
    public class EraController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Era
        public ActionResult Index()
        {
            return View(_db.Eras.ToList());
        }
        //GET: Era/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Era/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EraCreate era)
        {
            if (ModelState.IsValid) return View(era);
            var service = CreateEraService();
            if(service.CreateEra(era))
            {
                TempData["SaveResult"] = "New Era created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create new Era.");
            return View(era);
        }
        //GET: Era/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Era era= _db.Eras.Find(id);
            if (era == null)
            {
                return HttpNotFound();
            }
            return View(era);
        }
        //POST: Album/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Era era = _db.Eras.Find(id);
            _db.Eras.Remove(era);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET: EraEdit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Era era = _db.Eras.Find(id);
            if (era == null)
            {
                return HttpNotFound();
            }
            return View(era);
        }
        //POST: Era/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Era era)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(era).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(era);
        }
        //GET Era/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Era era = _db.Eras.Find(id);
            if (era == null)
            {
                return HttpNotFound();
            }
            return View(era);
        }
        private EraService CreateEraService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EraService(userId);
            return service;
        }
    }
}