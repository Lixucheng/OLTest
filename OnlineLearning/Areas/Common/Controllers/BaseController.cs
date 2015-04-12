using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Models;
using System.Globalization;

namespace OnlineLearning.Areas.Common.Controllers
{
    public class BaseController : Controller
    {
        protected LXC_OnlineLearningEntities Db;
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
        protected void AddLoginCookie(string name, Models.Account account)
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
            return 1;
        }

        /// <summary>
        /// 注销
        /// </summary>
        public ActionResult Logout()
        {
            Session.Remove("login");
            Response.Cookies.Remove("login");
            return Redirect("~/students/log/login");
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            

        }


        public ActionResult _Header()
        {
            var user = Request.Cookies["login"];
            if (user == null)
            {
                 // todo: throw new Exception("用户未登录，越权");
            }
            var num= user.Values["StudentNum"];
            return View(Sgt.GetAccount().GetAccountByStudentNum(long.Parse(num)));
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
        //    var x=Session["login"] as Account;
        //    var y = Request.Cookies["login"];
        //    return Redirect(y.Values["StudentNum"]);
        //}

  
    }
}