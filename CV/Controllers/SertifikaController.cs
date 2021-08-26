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
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        SertifikaRepository repo = new SertifikaRepository();
        TblSertifikalarım sertifika = new TblSertifikalarım();
        public ActionResult Index()
        {
           var sertifikas = repo.List();
            return View(sertifikas);
        }
        public ActionResult SertifikaSil(int id)
        {
            sertifika = repo.Find(x => x.ID == id);
            if (sertifika != null) {
                repo.TDelete(sertifika);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarım data)
        {
            repo.TAdd(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaDuzenle(int id)
        {
            sertifika = repo.Find(x => x.ID == id);

            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaDuzenle(TblSertifikalarım data)
        {
            sertifika = repo.Find(x => x.ID == data.ID);
            if (sertifika != null) {
                sertifika.Baslik = data.Baslik;
                sertifika.Aciklama = data.Aciklama;
                repo.TUpdate(sertifika);
            }
            return RedirectToAction("Index");
        }
    }
}