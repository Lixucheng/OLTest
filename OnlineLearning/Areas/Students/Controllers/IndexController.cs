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
            ViewBag.count = alltest.Count;
            return View();
        }

        public ActionResult GetScore()
        {
            int id = GetStudentId();
            var donetest = Sgt.GetScore().GetAScoreByStudentid(id);
            ViewBag.list = donetest;
            ViewBag.count = donetest.Count;
            return View();
        }

        public ActionResult Test(int id)
        {
            var stu = GetStudentId();
            var quest = Sgt.GetITest_question().GetHQuestionsByTestId(id);
            ViewBag.list = quest;
            ViewBag.time = Sgt.GetTest().Find(id).Time.TotalSeconds;
            ViewBag.studentid = stu;
            ViewBag.testid = id;
            ViewBag.testname = Sgt.GetTest().Find(id).Name;
            return View();
        }

        public void Sub( int testid,int questid, string answer)
        {
            if (string.IsNullOrEmpty(answer))
            {
                answer = "";
            }
            var id = GetStudentId();    
            var x = new Answer()
            {
                studentId = id,
                TestId = testid,
                Answer1 = answer,
                questionId = questid            
            };          
            Sgt.GetAnswer().Add(x);
        }

        public ActionResult GetThisScore(int id)
        {
            Sgt.GetTest().CalculateScore(id,GetStudentId());
            ViewBag.score = Sgt.GetScore().GetOneScore(GetStudentId(),id);
            return View();
        }

       
    }
}