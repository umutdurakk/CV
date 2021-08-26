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
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        HakkimdaRepository repo = new HakkimdaRepository();
        TblHakkimda hakk = new TblHakkimda();
        public ActionResult Index()
        {
            var hakkım = repo.List();
            return View(hakkım);
        }
        [HttpGet]
        public ActionResult HakkimdaEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult HakkimdaEkle(TblHakkimda data)
        {
            repo.TAdd(data);
            return RedirectToAction("Index");
        }
        public ActionResult HakkimdaSil(int id)
        {
            hakk = repo.Find(x => x.ID == id);
            if (hakk != null) {
                repo.TDelete(hakk);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HakkimdaDuzenle(int id)
        {
            hakk = repo.Find(x => x.ID == id);
            return View(hakk);
        }

        [HttpPost]
        public ActionResult HakkimdaDuzenle(TblHakkimda data,HttpPostedFileBase userImage)
        {
            string filename = null;
            if (userImage != null &&
                 (userImage.ContentType == "image/jpeg" ||
                  userImage.ContentType == "image/jpg" ||
                  userImage.ContentType == "image/png")) {

                filename = $"user_{data.ID}.{userImage.ContentType.Split('/')[1]}";

                userImage.SaveAs(Server.MapPath($"~/Images/{filename}"));
            }
            hakk = repo.Find(x => x.ID == data.ID);
            if (hakk != null) {
                hakk.Ad = data.Ad;
                hakk.Soyad = data.Soyad;
                hakk.Mail = data.Mail;
                hakk.Telefon = data.Telefon;
                hakk.Resim = data.Resim;
                hakk.Aciklama = data.Aciklama;
                hakk.Resim = filename;
                repo.TUpdate(hakk);
            }
            return RedirectToAction("Index");
        }
    }
}