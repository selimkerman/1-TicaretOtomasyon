using MvcTicaretOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicaretOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {

        Context c = new Context();
        // GET: UrunDetay
        public ActionResult Index()
        {

            Class1 cs = new Class1();
            cs.uruns = c.Uruns.Where(x => x.Urunid==1).ToList();
            cs.detays = c.Detays.Where(y => y.Detayid==1).ToList();
            //var degerler = c.Uruns.Where(x=>x.Urunid==1).ToList();
            return View(cs);
        }
    }
}