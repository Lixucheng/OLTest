using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class IAccount:IAdapter
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Account GetAccountByEmail(string Email)
        {
            var x = Db.Account.FirstOrDefault(e => e.Email == Email);
            return x==default(Account) ? null : x;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public Account GetAccountByStudentNum(long Num)
        {
            var x = Db.Account.FirstOrDefault(e => e.StudentNum == Num);
            return x == default(Account) ? null : x;
        }
    }
}