using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok.Models.Entity;

namespace mvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        mvcDbStokEntities db = new mvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler =from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(a => a.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());

            //var degerler = db.TBLMUSTERILER.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int id) 
        {
            var sil = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mst = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",mst);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mst = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            mst.MUSTERIAD = p1.MUSTERIAD;
            mst.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}