using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLearning.Models;
using System.Globalization;

namespace OnlineLearning.Areas.Common.Controllers
{
    public class BaceController : Controller
    {
        protected OnlineLearningEntities Db;
        protected Singleton Sgt;

        public BaceController()
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
            cookic.Values["name"] = account.Name;
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


    }
}