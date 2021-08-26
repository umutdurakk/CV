using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV.Filters;
using CV.Models.Entity;
using CV.Repositories;

namespace CV.Controllers
{
    [Auth]
    public class EgitimController : Controller
    {
        // GET: Egitim
       
        EgitimRepository repo = new EgitimRepository();
        TblEgitimlerim egitim = new TblEgitimlerim();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim data)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(data);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            egitim = repo.Find(x => x.ID == id);
            if (egitim != null) {
                repo.TDelete(egitim);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim data)
        {
            egitim = repo.Find(x => x.ID == data.ID);
            if (egitim != null) {
                egitim.Baslik = data.Baslik;
                egitim.AltBaslik1 = data.AltBaslik1;
                egitim.AltBaslik2 = data.AltBaslik2;
                egitim.GNO = data.GNO;
                egitim.Tarih = data.Tarih;
                repo.TUpdate(egitim);
            }
            return RedirectToAction("Index");
        }
    }
}