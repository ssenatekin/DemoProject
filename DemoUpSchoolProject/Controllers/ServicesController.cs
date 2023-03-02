using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        //tolist,add,reöove,where
        UpSchoolDbPortfolioEntities1 db =new UpSchoolDbPortfolioEntities1(); 

        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }

        [HttpGet] //sadece sayfa yüklendiği zaman çalışsın
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost] //post işlemi olursa burdaki işlemi gerçekleştir
        public ActionResult AddService(TblServices p)
        {
            db.TblServices.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblServices.Find(id);
            db.TblServices.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblServices.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblServices p)
        {
            var values = db.TblServices.Find(p.ServicesID);
            values.Title=p.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}