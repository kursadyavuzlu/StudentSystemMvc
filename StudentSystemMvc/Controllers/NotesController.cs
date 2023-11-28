﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}