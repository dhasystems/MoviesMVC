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
            using (DBModel db = new DBModel())
            {
                var movlist = db.lists.ToList<list>();
                return Json(new { data = movlist }, JsonRequestBehavior.AllowGet);
            }
        }

       

    }
}