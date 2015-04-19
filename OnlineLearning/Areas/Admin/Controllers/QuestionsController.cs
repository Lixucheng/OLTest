using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLearning.Areas.Admin.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Admin/Questions
        public ActionResult Add()
        {
            return View();
        }
    }
}