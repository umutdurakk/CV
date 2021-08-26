using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV.Models.Entity;
using CV.Models.Sess;
using CV.Repositories;
using CV.Filters;

namespace CV.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        DbCvEntities db = new DbCvEntities();
        AdminRepository repo = new AdminRepository();
        TblAdmin admin = new TblAdmin();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        
        public PartialViewResult Hakkımda()
        {
            var degerler = db.TblHakkimda.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var degerler = db.TblDeneyimler.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Egitim()
        {
            var degerler = db.TblEgitimlerim.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Yetenek()
        {
            var degerler = db.TblYetenekler.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Hobiler()
        {
            var degerler = db.TblHobilerim.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Sertifika()
        {
            var degerler = db.TblSertifikalarım.ToList();
            return PartialView(degerler);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Tbliletisim ileti)
        {
            ileti.Tarih = DateTime.Now;
            db.Tbliletisim.Add(ileti);
            db.SaveChanges();
            return PartialView(); 
        }
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(TblAdmin admins)
        {
            admin = repo.Find(x => x.KullaniciAdi == admins.KullaniciAdi && x.Sifre == admins.Sifre);
            if (admin!=null)
            {
                CurrentSession.Set<TblAdmin>("login",admin);
                return RedirectToAction("Index", "Hakkimda");
            }

            return View();
        }
        [Auth]
        public ActionResult Logout()
        {
            CurrentSession.Clear();
            return RedirectToAction("Index");
        }
    }
}