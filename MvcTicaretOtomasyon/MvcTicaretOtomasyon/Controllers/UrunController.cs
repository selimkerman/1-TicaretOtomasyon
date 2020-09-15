using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicaretOtomasyon.Models.Siniflar;

namespace MvcTicaretOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urunGetir = c.Uruns.Where(x=>x.Durum==true).ToList();
            return View(urunGetir);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.Kategoriid.ToString()
                                         }
                                         ).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun yeniUrun)
        {
            c.Uruns.Add(yeniUrun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int urunId)
        {
            var urunSil = c.Uruns.Find(urunId);
            urunSil.Durum=false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.Kategoriid.ToString()
                                           }
                                      ).ToList();
            ViewBag.dgr1 = deger1;

            var urunDeger = c.Uruns.Find(id);
            return View("UrunGetir", urunDeger);
        }


        public ActionResult UrunGuncelle(Urun u)
        {
            var urunGuncelle = c.Uruns.Find(u.Urunid);       
            urunGuncelle.AlisFiyat = u.AlisFiyat;
            urunGuncelle.Durum = u.Durum;
            urunGuncelle.Kategori = u.Kategori;
            urunGuncelle.Kategoriid = u.Kategoriid;
            urunGuncelle.Marka = u.Marka;
            urunGuncelle.SatisFiyat = u.SatisFiyat;
            urunGuncelle.Stok = u.Stok;
            urunGuncelle.UrunAd = u.UrunAd;
            urunGuncelle.UrunGorsel = u.UrunGorsel;
    
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}