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
        // GET: Admin/Manage/登陆
        [Public]
        public ActionResult TLogin()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Test()
        {
            var x = Sgt.GetTest().GetTests();
            ViewBag.list = x;
            ViewBag.count = x.Count;
            return View();
        }

        public ActionResult TestDel(int id)
        {
            Sgt.GetTest().Del(id);
            return Redirect("/admin/manage/test");
        }

        public void TestUpdate(int id, string name, TimeSpan time)
        {
            Sgt.GetTest().Update(id, name, time);
        }

        public ActionResult TestAdd(string name, TimeSpan time)
        {
            Sgt.GetTest().Add(name, time);
            return Redirect("test");
        }


    }
}