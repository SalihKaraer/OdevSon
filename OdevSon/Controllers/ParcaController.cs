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
    
    public class ParcaController : Controller
    {
        OtoContext ptx = new OtoContext();
        [Authorize]
        public ActionResult Index()
        {

            using (OtoContext ptx = new OtoContext())
            {
                ParcaViewModel ovm = new ParcaViewModel
                {
                    Parcalar = ptx.Parcalar.ToList()
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
        public bool Ekle(Parca p)
        {

            if (ModelState.IsValid)
            {
                using (OtoContext ptx = new OtoContext())
                {
                    ptx.Parcalar.Add(p);
                    int sonuc = ptx.SaveChanges();
                    if (sonuc > 0)
                    {
                        return true;
                    }

                }
            }
            else
            {
                ModelState.AddModelError("ParcaId", "Bos");
            }
            return false;
        }
        public string Listele()
        {
            string liste = "";
            List<Parca> parcalistesi = ptx.Parcalar.ToList();
            foreach (var list in parcalistesi)
            {
                liste += "<br>" + list.ParcaAd + " " + list.ParcaTur + "<hr>";
            }
            return liste;
        }
        [Authorize]
        public ActionResult Duzenle(int? id)
        {
            using (OtoContext ptx = new OtoContext())
            {
                var prc = ptx.Parcalar.Find(id);

                return View(prc);
            }
        }

        
        [HttpPost]
        [Authorize]
        public ActionResult Duzenle(Parca prc)
        {
            using (OtoContext ptx = new OtoContext())
            {
                ptx.Entry(prc).State = EntityState.Modified;
                int sonuc = ptx.SaveChanges();
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
            using (OtoContext ptx = new OtoContext())
            {
                var prc = ptx.Parcalar.Find(id);
                ptx.Parcalar.Remove(prc);
                ptx.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}