using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Areas.Common.Controllers;

namespace OnlineLearning.Areas.Students.Controllers
{
    public class IndexController : BaseController
    {
       
        public ActionResult Index()
        {
            return View();
        }
    }
}