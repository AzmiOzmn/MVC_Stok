using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok.Models.Entity;

namespace mvcStok.Controllers
{
    public class KategoriController : Controller
    {
        mvcDbStokEntities db = new mvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori() 
        {
            return View();
        }

        [HttpPost] 
        public ActionResult YeniKategori(TBLKATEGORILER p1) 
        {
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}