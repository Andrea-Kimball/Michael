using Michael.Data;
using Michael.Models;
using Michael.Models.Albums;
using Michael.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Michael.Controllers
{
    public class AlbumController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Album
        public ActionResult Index()
        {
            ICollection<Album> albums = _db.Albums.Include(c => c.Category).ToList();
            return View(albums);
        }

        //GET: Album/Create
        public ActionResult Create()
        {                            
            return View();
        }

        //POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Create(Album album)
        {
           if (ModelState.IsValid)
           {
                Era newEra = _db.Eras.Single(c => c.EraId == album.EraId);
                Album newAlbum = new Album
                {
                    Title = album.Title,
                    AlbumDescription = album.AlbumDescription,
                    Category = newEra
                };
                _db.Albums.Add(newAlbum);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
            
        }

        //GET: Album/Delete/{id}
        public ActionResult Delete(int? id)
        {
            var svc = CreateAlbumService();
            var model = svc.GetAlbumById(id);

            return View(model);
        }
        
        //POST: Album/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateAlbumService();

            service.DeleteAlbum(id);

            return RedirectToAction("Index");

        }

        //GET: Album/Edit/{id}
        public ActionResult Edit(int? id)
        {
            var service = CreateAlbumService();
            var detail = service.GetAlbumById(id);
            var model =
                new AlbumEdit
                {
                    AlbumId = detail.AlbumId,
                    Title = detail.Title,
                    AlbumDescription= detail.AlbumDescription

                };
            return View(model);
        }
       
        //POST: Album/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(album).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }
        
        //GET Album/Details/{id}
        public ActionResult Details(int? id)
        {
            var svc = CreateAlbumService();
            var model = svc.GetAlbumById(id);
            return View(model);
        }

        //View Albums by Era 
        public ActionResult Era(int eraid)
        {
            if(eraid == 0)
            {
                return Redirect("/Era");
            }
            Era theEra = _db.Eras
                .Include(e => e.Albums)
                .Single(e => e.EraId == eraid);
            ViewBag.title = "Albums in Era: " + theEra.EraName;
            return View("Index", theEra.Albums);
        }

        private AlbumService CreateAlbumService()
        {
            //var userId = User.Identity.GetUserId();
            var service = new AlbumService();
            return service;
        }
        
        
    }
}