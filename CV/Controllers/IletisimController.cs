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
    public class IletisimController : Controller
    {
        // GET: Iletisim
        iletisimRepository repo = new iletisimRepository();
        Tbliletisim ilet = new Tbliletisim();
        public ActionResult Index()
        {
            var ilets = repo.List();
            return View(ilets);
        }

        [HttpGet]
        public ActionResult IletisimEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IletisimEkle(Tbliletisim data)
        {
            repo.TAdd(data);
            return RedirectToAction("Index");
        }
        public ActionResult IletisimSil(int id)
        {
            ilet = repo.Find(x => x.ID == id);
            if (ilet != null) {
                repo.TDelete(ilet);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult IletisimDuzenle(int id)
        {
            ilet = repo.Find(x => x.ID == id);

            return View(ilet);
        }

        [HttpPost]
        public ActionResult IletisimDuzenle(Tbliletisim data)
        {
            ilet = repo.Find(x => x.ID == data.ID);
            if (ilet != null) {
                ilet.AdSoyad = data.AdSoyad;
                ilet.Mail = data.Mail;
                ilet.Konu = data.Konu;
                ilet.Mesaj = data.Mesaj;
                ilet.Tarih = data.Tarih;
                repo.TUpdate(ilet);
            }
            return RedirectToAction("Index");
        }
    }
}