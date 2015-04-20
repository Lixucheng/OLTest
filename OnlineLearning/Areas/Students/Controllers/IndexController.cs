using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Areas.Common.Controllers;
using OnlineLearning.Models;

namespace OnlineLearning.Areas.Students.Controllers
{
    
    public class IndexController : BaseController
    {
        
        public ActionResult Index()
        {
            int id = GetStudentId();
            var alltest = Sgt.GetTest().GetTests();
            var donetest = Sgt.GetScore().GetAScoreByStudentid(id);
            var done=new List<Test>();
            donetest.ForEach(e => done.Add(Sgt.GetTest().Find(e.TestId)));
            done.ForEach(e => alltest.Remove(e));
            ViewBag.test = alltest;
            return View();
        }

        public ActionResult GetScore()
        {
            int id = GetStudentId();
            var donetest = Sgt.GetScore().GetAScoreByStudentid(id);
            ViewBag.list = donetest;
            return View();
        }

        public ActionResult Test(int id)
        {
            var stu = GetStudentId();
            
            return View();
        }

       
    }
}