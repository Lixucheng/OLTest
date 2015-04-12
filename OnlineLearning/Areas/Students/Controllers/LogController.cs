using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLearning.Areas.Students.Controllers
{
    public class LogController : Controller
    {
        // GET: Students/Log
       
        public ActionResult Login()
        {
            return View();
        }

    }
}