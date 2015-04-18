using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Attributes;
using OnlineLearning.Models;
using System.Globalization;

namespace OnlineLearning.Areas.Common.Controllers
{
    public class BaseController : Controller
    {
        protected OnlineLearningEntities Db;
        protected Singleton Sgt;

        public BaseController()
        {
            Sgt = new Singleton();
            Db = Sgt.GetDbContext();
        }

        /// <summary>
        /// 添加cookic
        /// </summary>
        /// <param name="name"></param>
        /// <param name="account"></param>
        protected void AddLoginCookie(string name, Account account)
        {
            var cookic = new HttpCookie(name);
            cookic.Values["StudentNum"] = account.StudentNum.ToString(CultureInfo.InvariantCulture);
            cookic.Values["time"] = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            Response.Cookies.Add(cookic);      
        }

        /// <summary>
        /// 添加session
        /// </summary>
        /// <param name="name"></param>
        /// <param name="account"></param>
        protected void AddLoginSession(string name, Account account)
        {
            Session.Add(name,account);
        }

       
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="num"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Public]
        public int Login(long num, string password)
        {
            var account = Sgt.GetAccount().GetAccountByStudentNum(num);
            if (account == null||account.Password!=password)
            {
                return 0;
            }
            AddLoginCookie("login",account);
            AddLoginSession("login",account);
            //return Redirect("~/students/index/index");
            return account.Id;
        }

        /// <summary>
        /// 注销
        /// </summary>
        public ActionResult Logout()
        {
            Session["login"]=null;
            Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1);
            return Redirect("~/students/log/slogin");
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var a = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //如果 没有 Public 特性， 则进行登录权限检查
            var attribute = filterContext.ActionDescriptor.GetCustomAttributes(typeof(PublicAttribute), false);
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(PublicAttribute), false).Length == 0)
            {
                var y = Request.Cookies["login"];
                if (y == null)
                {
                    filterContext.Result = new RedirectResult("/Students/Log/SLogin");
                    return;
                }
                var num = y.Values["StudentNum"];
                if (num == null)
                {
                    // redirect to login
                    filterContext.Result = new RedirectResult("/Students/Log/SLogin");
                    return;
                }
                var x = Session["login"] as Account;
                if (x== null)
                {
                    // redirect to login
                    filterContext.Result = new RedirectResult("/Students/Log/SLogin");
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
            var num= user.Values["StudentNum"];
            return View(Sgt.GetAccount().GetAccountByStudentNum(long.Parse(num)));
        }

        public int GetStudentId()
        {
            var x = Session["login"] as Account;
            return x.Id;
        }


        ///// <summary>
        ///// test
        ///// </summary>
        //public void Login()
        //{
        //    Login(201392301, "lxc123");
        //}



        //public ActionResult TestLogin()
        //{
        //    var x = Session["login"] as Account;
        //    var y = Request.Cookies["login"];
        //    return Redirect(y.Values["StudentNum"]);
        //}

  
    }
}