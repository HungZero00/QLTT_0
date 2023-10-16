using QLTT_0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;


namespace QLTT_0.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult QLCN()
        {
         
            var lstCN = db.CHUYENNGANHs.ToList();
            return View(lstCN);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            ViewBag.MaCN = new SelectList(db.CHUYENNGANHs.ToList().OrderBy(n => n.TenCN), "MaCN", "TenCN");
                return View();
        }
        public ActionResult Edit(int? id)
        {
            
            CHUYENNGANH cn = db.CHUYENNGANHs.SingleOrDefault(n => n.MaCN == id);
            if (cn == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaCN = cn.MaCN;
            ViewBag.MaCN = new SelectList(db.CHUYENNGANHs.ToList().OrderBy(n => n.TenCN), "MaCN", "TenCN");
            return View(cn);
        }
        public ActionResult Details(int? id)
        {
          
            CHUYENNGANH cn = db.CHUYENNGANHs.SingleOrDefault(n => n.MaCN == id);
            if (cn == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaCN = cn.MaCN;
            return View(cn);
        }
        public ActionResult Delete(int? id)
        {
            CHUYENNGANH cn = db.CHUYENNGANHs.SingleOrDefault(n => n.MaCN == id);
            if (cn == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaCN = cn.MaCN;
            db.CHUYENNGANHs.Remove(cn);
            db.SaveChanges();
            return RedirectToAction("QLCN");
        }
    }
}