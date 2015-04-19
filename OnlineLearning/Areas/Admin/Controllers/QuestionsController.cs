using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Areas.Common.Controllers;

namespace OnlineLearning.Areas.Admin.Controllers
{
    public class QuestionsController : AdminBaseController
    {
        // GET: Admin/Questions
        public ActionResult Add()
        {
            return View();
        }
    }
}