using MvcTicaretOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicaretOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satis
        public ActionResult Index()
        {

            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> seciliUrun = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();

            List<SelectListItem> seciliCari = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            List<SelectListItem> seciliPersonel = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.Personelid.ToString()
                                           }).ToList();



            ViewBag.seciliUrun = seciliUrun;
            ViewBag.seciliCari = seciliCari;
            ViewBag.seciliPersonel = seciliPersonel;


            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
            satis.Tarih =DateTime.Parse(DateTime.Now.ToString());
            c.SatisHarekets.Add(satis);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            
            List<SelectListItem> deger2 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();
            
            List<SelectListItem> deger3 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.Cariid.ToString()
                                           }).ToList();
            ViewBag.personelSecimi = deger1;
            ViewBag.urunSecimi = deger2;
            ViewBag.cariSecimi = deger3;

            var degerler = c.SatisHarekets.Find(id);
            return View("SatisGetir", degerler);
        }


        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var deger = c.SatisHarekets.Find(s.Satisid);

            deger.Cariid = s.Cariid;
            deger.Adet = s.Adet;
            deger.Fiyat = s.Fiyat;
            deger.ToplamTutar = s.ToplamTutar;
            deger.Personelid = s.Personelid;
            deger.Urunid = s.Urunid;
            deger.Tarih = s.Tarih;
            

            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SatisDetay (int id)
        {
            var degerler = c.SatisHarekets.Where(item => item.Satisid == id).ToList();
            return View(degerler);
        }
    }
}