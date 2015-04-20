﻿using System;
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

        //添加习题
        public ActionResult TestAdd(string name, TimeSpan time)
        {
            Sgt.GetTest().Add(name, time);
            return Redirect("test");
        }

        //给试题添加习题
        [HttpGet]
        public ActionResult Test_addquestions(int id)
        {
            var x = Sgt.GetQuestion().GetAll();
            ViewBag.list = x;
            ViewBag.count = x.Count;
            ViewBag.test = Sgt.GetTest().Find(id).Name;
            return View(id);
        }

        [HttpPost]
        public int Test_addquestions(int testid, int questid)
        {
            return Sgt.GetITest_question().Add(testid, questid) ? 1 : 0;
        }

        //查看一个test的习题
        public ActionResult Test_getquestions(int id)
        {
            return View();
        }
    }
}