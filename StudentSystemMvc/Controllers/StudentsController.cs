using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSystemMvc.Models.EntityFramework;

namespace StudentSystemMvc.Controllers
{
    public class StudentsController : Controller
    {
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        // GET: Students
        public ActionResult Index()
        {
            var students = db.Tbl_Students.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            List<SelectListItem> values = (from i in db.Tbl_Clubs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ClubName,
                                               Value = i.ClubID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Tbl_Students p)
        {
            var clb = db.Tbl_Clubs.Where(m => m.ClubID == p.Tbl_Clubs.ClubID).FirstOrDefault();
            p.Tbl_Clubs = clb;
            db.Tbl_Students.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}