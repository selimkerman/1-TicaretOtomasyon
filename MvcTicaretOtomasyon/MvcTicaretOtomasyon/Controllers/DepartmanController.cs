using MvcTicaretOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicaretOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {

        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var departmanGetir = c.Departmans.Where(x=>x.Durum==true).ToList();


            return View(departmanGetir);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman k)
        {
            c.Departmans.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmanSil(int id)
        {
            var departman = c.Departmans.Find(id);
            departman.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = c.Departmans.Find(id);
            return View("DepartmanGetir",departman);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departmanGuncelle = c.Departmans.Find(d.Departmanid);
            departmanGuncelle.DepartmanAd = d.DepartmanAd;
            departmanGuncelle.Durum = d.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
           
        }

        public ActionResult DepartmanDetay(int Id)
        {
            var departmanPersoneliGetir = c.Personels.Where(x => x.Departmanid == Id).ToList();
            var departmanAdi = c.Departmans.Where(x => x.Departmanid == Id).Select(y => y.DepartmanAd).FirstOrDefault();

            ViewBag.departmanAd = departmanAdi;
  
            return View(departmanPersoneliGetir);
        }

        public ActionResult DepartmanSatislar(int id)
        {

            var personelSatisListele = c.SatisHarekets.Where(x=> x.Personelid ==id).ToList();
            var cr = c.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.personelAdSoyad = cr;
            return View(personelSatisListele);
        }
    }
}