﻿using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Attributes;
using OnlineLearning.Models;

namespace OnlineLearning.Areas.Common.Controllers
{
    public class AdminBaseController : Controller
    {
        protected OnlineLearningEntities Db;
        protected Singleton Sgt;

        public AdminBaseController()
        {
            Sgt = new Singleton();
            Db = Sgt.GetDbContext();
        }

        /// <summary>
        ///     添加cookic
        /// </summary>
        /// <param name="name"></param>
        /// <param name="account"></param>
        protected void AddLoginCookie(string name, TeacherAccount account)
        {
            var cookic = new HttpCookie(name); //根据name实例化一个httpcookie
            cookic.Values["id"] = account.ID.ToString(CultureInfo.InvariantCulture); //向cookie中添加信息
            cookic.Values["time"] = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            Response.Cookies.Add(cookic); //传递给浏览器
        }

        /// <summary>
        ///     添加session
        /// </summary>
        /// <param name="name"></param>
        /// <param name="account"></param>
        protected void AddLoginSession(string name, TeacherAccount account)
        {
            Session.Add(name, account);
        }


        /// <summary>
        ///     登陆
        /// </summary>
        /// <param name="num"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Public]
        public int Login(int num, string password)
        {
            var account = Sgt.GetTeacherAccount().Find(num); //根据输入的学号查找学生类
            if (account == null || account.PassWord != password) //判断密码正确或者错误
            {
                return 0;
            }
            AddLoginCookie("login", account); //密码正确就添加cookic
            AddLoginSession("login", account);
            return account.ID;
        }

        /// <summary>
        ///     注销
        /// </summary>
        public ActionResult Logout()
        {
            Session["login"] = null;
            Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1); //向浏览器返回信息使cookie失效
            return Redirect("~/admin/manage/tlogin");
        }

        /// <summary>
        ///     验证
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var a = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //如果 没有 Public 特性， 则进行登录权限检查
            var attribute = filterContext.ActionDescriptor.GetCustomAttributes(typeof (PublicAttribute), false);
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof (PublicAttribute), false).Length == 0)
            {
                var y = Request.Cookies["login"];
                if (y == null)
                {
                    filterContext.Result = new RedirectResult("~/admin/manage/tlogin");
                    return;
                }
                var num = y.Values["id"];
                if (num == null)
                {
                    filterContext.Result = new RedirectResult("~/admin/manage/tlogin");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }

        [Public]
        public ActionResult _Header()
        {
            var user = Request.Cookies["login"];
            if (user == null)
            {
                throw new Exception("cookic错误，请重新登录");
            }
            var num = user.Values["id"];
            return View(Sgt.GetTeacherAccount().Find(int.Parse(num)));
        }

        public int GetTeacherId()
        {
            var y = Request.Cookies["login"];
            return int.Parse(y.Values["id"]);
        }
    }
}