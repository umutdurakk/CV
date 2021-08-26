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
    public class DeneyimController : Controller
    {
        
           // GET: Deneyim
           DeneyimRepository repo = new DeneyimRepository();
        TblDeneyimler deneyim = new TblDeneyimler();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimler data)
        { 
            repo.TAdd(data);    
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            deneyim = repo.Find(x=>x.ID==id);
            if (deneyim!=null)
            {
                repo.TDelete(deneyim);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimDuzenle(int id)
        {
            deneyim = repo.Find(x => x.ID == id);

            return View(deneyim);
        }

        [HttpPost]
        public ActionResult DeneyimDuzenle(TblDeneyimler data)
        {
            deneyim = repo.Find(x => x.ID == data.ID);
            if (deneyim != null)
            {
                deneyim.Baslik = data.Baslik;
                deneyim.AltBaslik = data.AltBaslik;
                deneyim.Tarih = data.Tarih;
                deneyim.Aciklama = data.Aciklama;
                repo.TUpdate(deneyim);
            }
            return RedirectToAction("Index");
        }
    }
}