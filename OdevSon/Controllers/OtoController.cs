using OdevSon.Dal;
using OdevSon.Models;
using OdevSon.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdevSon.Controllers
{
    public class OtoController : Controller
    {
        //GET: Oto
        OtoContext ctx = new OtoContext();
        [Authorize]
        public ActionResult Index()
        {

            using (OtoContext ctx = new OtoContext())
            {
                OtoViewModel ovm = new OtoViewModel
                {
                    Otomobil = ctx.Otomobil.ToList()
                };

                return View(ovm);
            }

        }

        [Authorize]
        public ActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public bool Ekle(Oto o)
        {

            if (ModelState.IsValid)
            {
                using (OtoContext ctx = new OtoContext())
                {
                    ctx.Otomobil.Add(o);
                    int sonuc = ctx.SaveChanges();
                    if (sonuc > 0)
                    {
                        return true;
                    }

                }
            }
            else
            {
                ModelState.AddModelError("AracId", "Bos");
            }
            return false;
        }
        
        public string Listele()
        {
            string liste = "";
            List<Oto> otolistesi = ctx.Otomobil.ToList();
            foreach (var list in otolistesi)
            {
                liste += "<br>" + list.Marka + " " + list.Model + "<hr>"  ;
            }
            return liste;
        }
        [Authorize]
        public ActionResult Duzenle(int? id)
        {
            using (OtoContext ctx = new OtoContext())
            {
                var ato = ctx.Otomobil.Find(id);

                return View(ato);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Duzenle(Oto ato)
        {
            using (OtoContext ctx = new OtoContext())
            {
                ctx.Entry(ato).State = EntityState.Modified;
                int sonuc = ctx.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
        [Authorize]
        public ActionResult Sil(int? id)
        {
            using (OtoContext ctx = new OtoContext())
            {
                var ato = ctx.Otomobil.Find(id);
                ctx.Otomobil.Remove(ato);
                ctx.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}