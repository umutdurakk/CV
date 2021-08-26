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
    public class HobiController : Controller
    {
        // GET: Deneyim
        HobiRepository repo = new HobiRepository();
        TblHobilerim hobi = new TblHobilerim();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult HobiEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult HobiEkle(TblHobilerim data)
        {
            repo.TAdd(data);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            hobi = repo.Find(x => x.ID == id);
            if (hobi != null) {
                repo.TDelete(hobi);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HobiDuzenle(int id)
        {
            hobi = repo.Find(x => x.ID == id);

            return View(hobi);
        }

        [HttpPost]
        public ActionResult HobiDuzenle(TblHobilerim data)
        {
            hobi = repo.Find(x => x.ID == data.ID);
            if (hobi != null) {
                hobi.Aciklama1 = data.Aciklama1;
                hobi.Aciklama2 = data.Aciklama2;
                repo.TUpdate(hobi);
            }
            return RedirectToAction("Index");
        }
    }
}