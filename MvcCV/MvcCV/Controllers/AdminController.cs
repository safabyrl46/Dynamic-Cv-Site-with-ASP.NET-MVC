using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<TblAdmin> repo = new Repositories.GenericRepository<TblAdmin>();
        [HttpGet]
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            var admin = repo.Find(x => x.ID == p.ID);
            admin.KullaniciAdi = p.KullaniciAdi;
            admin.Sifre = p.Sifre;
            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminDuzenle(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}