﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Areas.Common.Controllers;
using OnlineLearning.Attributes;

namespace OnlineLearning.Areas.Students.Controllers
{
    public class LogController : BaseController
    {
        // GET: Students/Log
       
        [Public]
        public ActionResult SLogin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UpdatePassword()
        {
            int id = GetStudentId();
            var user=Sgt.GetAccount().Find(id);
            ViewBag.Old = user.Password;
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePasswork(string password)
        {
            Sgt.GetAccount().EditPassWord(GetStudentId(), password);
            return Redirect("~/Students/Index/Index");
        }

        public int TestPassword(string oldpassword)
        {
            var x = Sgt.GetAccount().Find(GetStudentId());
            return x.Password != oldpassword ? 0 : 1;
        }
    }
}