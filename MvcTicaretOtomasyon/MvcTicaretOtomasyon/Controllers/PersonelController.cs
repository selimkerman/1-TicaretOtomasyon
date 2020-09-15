using MvcTicaretOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicaretOtomasyon.Controllers
{
    public class PersonelController : Controller
    {

        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelGetir(int id)
        {
            var personel = c.Personels.Find(id);
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }
                                    ).ToList();
            ViewBag.prsnl1 = deger1;
            return View("PersonelGetir", personel);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var personelGuncelle = c.Personels.Find(p.Personelid);
            personelGuncelle.PersonelAd = p.PersonelAd;
            personelGuncelle.PersonelSoyad = p.PersonelSoyad;
            personelGuncelle.PersonelGorsel = p.PersonelGorsel;
            personelGuncelle.Departman.DepartmanAd = p.Departman.DepartmanAd;
          //  departmanGuncelle.Durum = p.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}