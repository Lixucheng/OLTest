using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class IAccount : IAdapter
    {

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Account GetAccountByEmail(string Email)
        {
            var x = Db.Account.FirstOrDefault(e => e.Email == Email);
            return x == default(Account) ? null : x;
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

        /// <summary>
        /// 添加一个Account
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public int Add(Models.Account Account)
        {
            if (string.IsNullOrEmpty(Account.Name))
                throw new Exception("名字不能为空!");         
            if (Account.StudentNum ==0)
                throw new Exception("学号不能为空!");
            if (string.IsNullOrEmpty(Account.Class))
                throw new Exception("班级不能为空!");
            if (string.IsNullOrEmpty(Account.Password))
                throw new Exception("密码不能为空!");
     
            Db.Account.Add(Account);
            Db.SaveChanges();
            return Account.Id;
        }

        /// <summary>
        /// 添加一个Account
        /// </summary>
        /// <param name="name"></param>
        /// <param name="studentNum"></param>
        /// <param name="Class"></param>
        /// <param name="sex"></param>
        /// <param name="age"></param>
        /// <param name="password"></param>
        /// <param name="pic"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int Add(string name, long studentNum, string Class, string sex,
            int? age, string password, string pic, string email)
        {

            return Add(new Models.Account
            {
                Name = name,
                StudentNum = studentNum,
                Class = Class,
                Sex = sex,
                Age = age,
                Password = password,
                pic = pic,
                Email = email
            });
        }

        /// <summary>
        /// 删除一个Account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            Models.Account del = Db.Account.Find(id);

            if (del == null)
                throw new Exception("没有找到对应的Account，无法删除");

            return Remove(del);

        }

        /// <summary>
        ///  删除一个Account
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public bool Remove(Models.Account Target)
        {
            if (Target == null) return false;
            Db.Account.Remove(Target);
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        /// 修改一个Account
        /// </summary>
        /// <param name="accountNew"></param>
        /// <returns></returns>
        public bool Edit(Models.Account accountNew)
        {
            var New = Db.Account.Find(accountNew.Id);
            if (New == null)
                throw new Exception("没有找到对应的Account ，无法修改!");
            if (string.IsNullOrEmpty(New.Name))
                throw new Exception("名字不能为空!");
            if (New.StudentNum == 0)
                throw new Exception("学号不能为空!");
            if (string.IsNullOrEmpty(New.Class))
                throw new Exception("班级不能为空!");
            if (string.IsNullOrEmpty(New.Password))
                throw new Exception("密码不能为空!");

            New.Name = accountNew.Name;
            New.StudentNum = accountNew.StudentNum;
            New.Sex = accountNew.Sex;
            New.Class = accountNew.Class;
            New.Age = accountNew.Age;
            New.Password = accountNew.Password;
            New.pic = accountNew.pic;
            New.Email = accountNew.Email;
            Db.Entry(New).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
            return true;
        }
        public bool Edit(string name, long studentNum, string Class, string sex,
            int? age, string password, string pic, string email)
        {

            return Edit(new Models.Account
            {
                Name = name,
                StudentNum = studentNum,
                Class = Class,
                Sex = sex,
                Age = age,
                Password = password,
                pic = pic,
                Email = email
            });
        }

        /// <summary>
        /// 查看对应ID的Account是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Models.Account Find(string Id)
        {
            return Db.Account.Find(Id);
        }
    }
}