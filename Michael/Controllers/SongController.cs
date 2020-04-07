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
    public class SongController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Song
        public ActionResult Index()
        {
            return View(_db.Songs.ToList());
        }      

        
        //GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Song/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Song song)
        {
            if (ModelState.IsValid)
            {
                _db.Songs.Add(song);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(song);
        }

        //GET: Song/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = _db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }
        //POST: Song/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Song song = _db.Songs.Find(id);
            _db.Songs.Remove(song);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET: Song/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = _db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }
        //POST: Song/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Song song)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(song).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(song);
        }
        //GET Song/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = _db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }
    }
}