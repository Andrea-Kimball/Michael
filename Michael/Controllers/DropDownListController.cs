using Michael.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Michael.Controllers
{
    public class DropDownListController : Controller
    {
        // GET: DropDownList
        public ActionResult Index()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            ViewBag.EraList = new SelectList(GetEraList(), "EraId", "EraName");
            return View();
        }

        public List<Era> GetEraList()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            List<Era> eras = ctx.Eras.ToList();
            return eras;
        }
        public ActionResult GetAlbumList(int EraId)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            List<Album> selectList = ctx.Albums.Where(x => x.EraId == EraId).ToList();
            ViewBag.AlbumList = new SelectList(selectList, "AlbumId", "Title");
            return View();
        }

    }
}