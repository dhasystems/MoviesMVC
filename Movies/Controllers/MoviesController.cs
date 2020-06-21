using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModel db = new DBModel())
            {
                List<list> movList = db.lists.ToList<list>();
                return Json(new { data = movList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new list());
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.lists.Where(x => x.id == id).FirstOrDefault<list>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(list mov)
        {
            using (DBModel db = new DBModel())
            {
                if (mov.id == 0)
                {
                    db.lists.Add(mov);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                    
                }
                else
                {
                    db.Entry(mov).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                list mov = db.lists.Where(x => x.id == id).FirstOrDefault<list>();
                db.lists.Remove(mov);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult LogOut()
        {
            //Session["username"] = null;
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }

    }
}