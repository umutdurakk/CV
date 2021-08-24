using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV.Models.Entity;

namespace CV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
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
        public PartialViewResult Iletisim()
        {
            var degerler = db.Tbliletisim.ToList();
            return PartialView(degerler);
        }
    }
}