﻿using System;
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
    }
}