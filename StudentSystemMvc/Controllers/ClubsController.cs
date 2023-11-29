using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSystemMvc.Models.EntityFramework;

namespace StudentSystemMvc.Controllers
{
    public class ClubsController : Controller
    {
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        // GET: Clubs
        public ActionResult Index()
        {
            var clubs = db.Tbl_Clubs.ToList();
            return View(clubs);
        }

        [HttpGet]
        public ActionResult AddClub()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClub(Tbl_Clubs p)
        {
            db.Tbl_Clubs.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete (int id)
        {
            var club = db.Tbl_Clubs.Find(id);
            db.Tbl_Clubs.Remove(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetClub(int id)
        {
            var club = db.Tbl_Clubs.Find(id);
            return View("GetClub", club);
        }

        public ActionResult Update(Tbl_Clubs p)
        {
            var club = db.Tbl_Clubs.Find(p.ClubID);
            club.ClubName = p.ClubName;
            db.SaveChanges();
            return RedirectToAction("Index", "Clubs");
        }
    }
}