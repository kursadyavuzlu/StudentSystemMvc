using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSystemMvc.Models;
using StudentSystemMvc.Models.EntityFramework;

namespace StudentSystemMvc.Controllers
{
    public class NotesController : Controller
    {
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        // GET: Notes
        public ActionResult Index()
        {
            var notes = db.Tbl_Notes.ToList();
            return View(notes);
        }

        [HttpGet]
        public ActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNote(Tbl_Notes p)
        {
            db.Tbl_Notes.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetNote(int id)
        {
            var note = db.Tbl_Notes.Find(id);
            return View("GetNote", note);
        }
        
        [HttpPost]
        public ActionResult GetNote(Class1 model, Tbl_Notes p, int Exam1=0, int Exam2=0, int Exam3=0, int Project=0)
        {
            if (model.process == "Calculate")
            {
                int Avr = (Exam1 + Exam2 + Exam3 + Project) / 4;
                ViewBag.avarage = Avr;
            }
            if (model.process == "UpdateNote")
            {
                var note = db.Tbl_Notes.Find(p.NoteID);
                note.Exam1 = p.Exam1;
                note.Exam2 = p.Exam2;
                note.Exam3 = p.Exam3;
                note.Project = p.Project;
                note.Avarage = p.Avarage;
                db.SaveChanges();
                return RedirectToAction("Index", "Notes");
            }

            return View();
        }
    }
}