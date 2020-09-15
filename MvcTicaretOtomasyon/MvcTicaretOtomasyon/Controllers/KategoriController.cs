using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicaretOtomasyon.Models.Siniflar;

namespace MvcTicaretOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var kategoriGetir = c.Kategoris.ToList();
            return View(kategoriGetir);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k )
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategoriSil = c.Kategoris.Find(id);
            c.Kategoris.Remove(kategoriSil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategoriGetir = c.Kategoris.Find(id);
            return View("KategoriGetir", kategoriGetir);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
          
            var kategoriGuncelle= c.Kategoris.Find(k.Kategoriid);
            kategoriGuncelle.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}