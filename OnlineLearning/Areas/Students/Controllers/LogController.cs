using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Attributes;

namespace OnlineLearning.Areas.Students.Controllers
{
    public class LogController : Controller
    {
        // GET: Students/Log
       
        [Public]
        public ActionResult Login()
        {
            return View();
        }

    }
}