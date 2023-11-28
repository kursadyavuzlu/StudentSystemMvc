using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystemMvc.Controllers
{
    public class CalculaterController : Controller
    {
        // GET: Calculater
        public ActionResult Index(int number1=0, int number2=0)
        {
            int result = number1 + number2;
            ViewBag.rst = result;
            return View();
        }
    }
}