using Michael.Data;
using Michael.Models;
using Michael.Models.Songs;
using Michael.Services;
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
            ICollection<Song> songs = _db.Songs.Include(c => c.Category).ToList();
            return View(songs);
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
                Album newAlbum = _db.Albums.Single(c => c.AlbumId == song.AlbumId);
                Song newSong = new Song
                {
                    Title = song.Title,
                    Category = newAlbum
                };
                _db.Songs.Add(song);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(song);
        }

        //GET: Song/Delete/{id}
        public ActionResult Delete(int? id)
        {
            var svc = CreateSongService();
            var model = svc.GetSongById(id);

            return View(model);
        }

        //POST: Song/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateSongService();

            service.DeleteSong(id);

            return RedirectToAction("Index");

        }

        //GET: Song/Edit/{id}
        public ActionResult Edit(int? id)
        {
            var service = CreateSongService();
            var detail = service.GetSongById(id);
            var model =
                new SongEdit
                {
                    SongId = detail.SongId,
                    Title = detail.Title,
                };
            return View(model);
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
            var svc = CreateSongService();
            var model = svc.GetSongById(id);
            return View(model);
        }

        private SongService CreateSongService()
        {
            //var userId = User.Identity.GetUserId();
            var service = new SongService();
            return service;
        }
    }
}