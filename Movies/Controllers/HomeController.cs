using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            using (DBModels db = new DBModels())
            {
                var movlist = db.Lists.ToList<List>();
                return Json(new { data = movlist }, JsonRequestBehavior.AllowGet);
            }
        }

       

    }
}