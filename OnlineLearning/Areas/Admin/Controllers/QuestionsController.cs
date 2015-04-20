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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [ValidateInput(false)]
        public int AddTest(string content, string aop, string bop, string cop, string dop, string correctop, string score)
        {
 
            return Sgt.GetQuestion().Add(content, aop, bop, cop, dop, correctop, "", int.Parse(score));        
        }


        public ActionResult GetAll()
        {
            var x = Sgt.GetQuestion().GetAll();
            ViewBag.list = x;
            ViewBag.count = x.Count;
            return View();
        }
    }
}