using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSystemMvc.Models.EntityFramework;

namespace StudentSystemMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        public ActionResult Index()
        {
            var lessons = db.Tbl_Lessons.ToList();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLesson(Tbl_Lessons p)
        {
            db.Tbl_Lessons.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete (int id)
        {
            var lssn = db.Tbl_Lessons.Find(id);
            db.Tbl_Lessons.Remove(lssn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetLesson(int id)
        {
            var lssn = db.Tbl_Lessons.Find(id);
            return View("GetLesson", lssn);
        }

        public ActionResult Update(Tbl_Lessons p)
        {
            var lssn = db.Tbl_Lessons.Find(p.LessonID);
            lssn.LessonName = p.LessonName;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}