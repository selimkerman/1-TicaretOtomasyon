using MvcTicaretOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicaretOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {
        Context c = new Context();
        // GET: İstatistik
        public ActionResult Index()
        {
            var toplamCariSayisi = c.Carilers.Count().ToString();
            var toplamUrunSayisi = c.Uruns.Count().ToString();
            var toplamPersonelSayisi = c.Personels.Count().ToString();
            var toplamKategoriSayisi = c.Kategoris.Count().ToString();  
            var toplamStokSayisi = c.Uruns.Sum(x => x.Stok).ToString();
            var toplamMarkaSayisi = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            var kritikSeviye = c.Uruns.Count(x => x.Stok <= 20).ToString();
          //  var maxFiyatliUrun = c.Uruns.Count(x => x.AlisFiyat >= 2500).ToString();
            var maxFiyatliUrun = (from x in c.Uruns orderby x.AlisFiyat descending select x.UrunAd).FirstOrDefault();
            var minFiyatliUrun = (from x in c.Uruns orderby x.AlisFiyat select x.UrunAd).FirstOrDefault();
            var toplamLaptopSayisi = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            var toplamKekSayisi = c.Uruns.Count(x => x.UrunAd == "kek").ToString();

            var toplamAlisFiyati = c.Uruns.Sum(x => x.AlisFiyat).ToString();
            var toplamSatisFiyati = c.Uruns.Sum(x => x.SatisFiyat).ToString();
            //  var toplamKazanc =  (toplamAlisFiyati) - toplamSatisFiyati;

            DateTime today = DateTime.Today;
            var bugunkuSatis = c.SatisHarekets.Count(x => x.Tarih == today).ToString();

            var maxMarka = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();

            var enCokSatan = c.Uruns.Where(u => u.Urunid ==(c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(s=>s.UrunAd).FirstOrDefault();

            ViewBag.toplamCari = toplamCariSayisi;
            ViewBag.toplamUrun = toplamUrunSayisi;
            ViewBag.toplamPersonel = toplamPersonelSayisi;
            ViewBag.toplamKategori = toplamKategoriSayisi;
            ViewBag.toplamLaptop = toplamLaptopSayisi;
            ViewBag.toplamStok = toplamStokSayisi;
            ViewBag.toplamMarka = toplamMarkaSayisi;
            ViewBag.kritikSeviye = kritikSeviye;
            ViewBag.maxFiyatliUrun = maxFiyatliUrun;
            ViewBag.minFiyatliUrun = minFiyatliUrun;
            ViewBag.toplamKek = toplamKekSayisi;
            ViewBag.toplamAlisFiyati = toplamAlisFiyati;
            ViewBag.toplamSatisFiyati = toplamSatisFiyati;
            ViewBag.bugunkuSatis = bugunkuSatis;
            ViewBag.maxMarka = maxMarka;
            ViewBag.enCokSatan = enCokSatan;
         //   ViewBag.toplamKazanc = toplamKazanc;
            return View();
        }
    
    
    public ActionResult KolayTablolar()
        {

            return View();
        }
    }
}