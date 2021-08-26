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
    public class YetenekController : Controller
    {
        // GET: Yetenek
        
        YetenekRepository repo = new YetenekRepository();
        TblYetenekler yetenek = new TblYetenekler();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(TblYetenekler data)
        {
            repo.TAdd(data);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            yetenek = repo.Find(x => x.ID == id);
            if (yetenek != null) {
                repo.TDelete(yetenek);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            yetenek = repo.Find(x => x.ID == id);

            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYetenekler data)
        {
            yetenek = repo.Find(x => x.ID == data.ID);
            if (yetenek != null) {
                yetenek.Yetenek = data.Yetenek;
                yetenek.Derece = data.Derece;
                repo.TUpdate(yetenek);
            }
            return RedirectToAction("Index");
        }
    }
}