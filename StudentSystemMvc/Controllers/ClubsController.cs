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
    }
}