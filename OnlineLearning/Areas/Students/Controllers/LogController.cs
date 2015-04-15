using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Areas.Common.Controllers;
using OnlineLearning.Attributes;

namespace OnlineLearning.Areas.Students.Controllers
{
    public class LogController : BaseController
    {
        // GET: Students/Log
       
        [Public]
        public ActionResult SLogin()
        {
            return View();
        }

    }
}