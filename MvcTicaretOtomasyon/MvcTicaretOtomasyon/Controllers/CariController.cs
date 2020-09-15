using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcTicaretOtomasyon.Models.Siniflar;

namespace MvcTicaretOtomasyon.Controllers
{
    public class CariController : Controller
    {

        Context c = new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=> x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cariler cari)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            var cariGuncelle = c.Carilers.Find(cari.Cariid);
            cariGuncelle.CariAd = cari.CariAd;
            cariGuncelle.CariSoyad = cari.CariSoyad;
            cariGuncelle.CariSehir = cari.CariSehir;
            cariGuncelle.CariMail = cari.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x=>x.Cariid==id).ToList();
            var cr = c.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cariAdSoyad = cr;
            return View(degerler);
        }
    }
}