using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Areas.Common.Controllers;
using OnlineLearning.Attributes;

namespace OnlineLearning.Areas.Admin.Controllers
{
    public class ManageController : AdminBaseController
    {
        // GET: Admin/Manage
        [Public]
        public ActionResult TLogin()
        {
            return View();
        }

        [Public]
        public ActionResult Index()
        {
            return View();
        }
    }
}