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
        protected void AddLoginCookie(string name, Models.Account account)
        {
            var cookic = new HttpCookie(name);
            cookic.Values["StudentNum"] = account.StudentNum.ToString();
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
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        protected bool Login(long Num, string password)
        {
            var account = Sgt.GetAccount().GetAccountByStudentNum(Num);
            if (account == null||account.Password!=password)
            {
                return false;
            }
            AddLoginCookie("login",account);
            AddLoginSession("login",account);
            return true;
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
            return View();
        }

        /// <summary>
        /// test
        /// </summary>
        public void Login()
        {
            Login(201392301, "lxc123");
        }

        public ActionResult TestLogin()
        {
            var x=Session["login"] as Account;
            var y = Request.Cookies["login"];
            return Redirect(y.Values["StudentNum"]);
        }

  
    }
}