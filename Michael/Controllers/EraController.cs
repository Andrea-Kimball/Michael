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
        public ActionResult Create(Era era)
        {
            if (ModelState.IsValid)
            {
                Era newEra = new Era
                {
                    EraName = era.EraName
                };
                _db.Eras.Add(newEra);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(era);
        }
       
        
        //GET: Era/Delete/{id}
        public ActionResult Delete(int? id)
        {
            var svc = CreateEraService();
            var model = svc.GetEraById(id);

            return View(model);

            
        }
        
        //POST: Album/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            var service = CreateEraService();

            service.DeleteEra(id);            

            return RedirectToAction("Index");
            

        }

        //GET: Era/EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateEraService();
            var detail = service.GetEraById(id);
            var model =
                new EraEdit
                {
                    EraId = detail.EraId,
                    EraName = detail.EraName,

                };
            return View(model);
        }
        
        //POST: Era/EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EraEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EraId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEraService();

            if (service.UpdateEra(model))
            {
                TempData["SaveResult"] = "Your Era was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Era could not be updated.");
            return View(model);
        }


        //GET Era/Details/{id}
        public ActionResult Details(int id)
        {

            var svc = CreateEraService();
            var model = svc.GetEraById(id);
            return View(model);

        }
        private EraService CreateEraService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EraService();
            return service;
        }
    }
    
}

