﻿using MvcTicaretOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicaretOtomasyon.Controllers
{
    public class FaturaController : Controller
    {

        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {

            var liste = c.Faturalars.ToList();
            return View(liste);
        }
    }
}