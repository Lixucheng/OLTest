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
       
        public ActionResult Index(int id)
        {
            var alltest = Sgt.GetTest().GetTests();
            var donetest = Sgt.GetScore().GetAllStudentidList(id);
            var done=new List<Test>();
            donetest.ForEach(e => done.Add(Sgt.GetTest().Find(e.TestId)));
            done.ForEach(e => alltest.Remove(e));
            return View(done);
        }
    }
}