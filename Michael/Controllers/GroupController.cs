using Michael.Data;
using Michael.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Michael.Controllers
{
    public class GroupController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Group
        public ActionResult Index()
        {
            return View(_db.Groups.ToList());
        }

        //GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Group/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                _db.Groups.Add(group);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        //GET: Group/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = _db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }
        //POST: Group/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Group group = _db.Groups.Find(id);
            _db.Groups.Remove(group);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET: Group/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = _db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }
        //POST: Group/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(group).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }
        //GET Group/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = _db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }
    }
}