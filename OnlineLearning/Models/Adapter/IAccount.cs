using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineLearning.Models.Adapter
{
    public class IAccount : IAdapter
    {
        /// <summary>
        ///     获取
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Account GetAccountByEmail(string Email)
        {
            var x = Db.Account.FirstOrDefault(e => e.Email == Email);
            return x == default(Account) ? null : x;
        }

        /// <summary>
        ///     获取
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public Account GetAccountByStudentNum(long Num)
        {
            var x = Db.Account.FirstOrDefault(e => e.StudentNum == Num);
            return x == default(Account) ? null : x;
        }

        /// <summary>
        ///     添加一个Account
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public int Add(Account Account)
        {
            if (string.IsNullOrEmpty(Account.Name))
                throw new Exception("名字不能为空!");
            if (Account.StudentNum == 0)
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
        ///     添加一个Account
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
            return Add(new Account
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
        ///     删除一个Account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            var del = Db.Account.Find(id);

            if (del == null)
                throw new Exception("没有找到对应的Account，无法删除");

            return Remove(del);
        }

        /// <summary>
        ///     删除一个Account
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public bool Remove(Account Target)
        {
            if (Target == null) return false;
            Db.Account.Remove(Target);
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        ///     修改一个Account
        /// </summary>
        /// <param name="accountNew"></param>
        /// <returns></returns>
        public bool Edit(Account accountNew)
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
            Db.Entry(New).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        public bool Edit(string name, long studentNum, string Class, string sex,
            int? age, string password, string pic, string email)
        {
            return Edit(new Account
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

        public bool EditPassWord(int id, string pass)
        {
            var New = Db.Account.Find(id);
            if (New == null)
                throw new Exception("没有找到对应的Account ，无法修改!");
            if (string.IsNullOrEmpty(pass))
                throw new Exception("密码不能为空!");
            New.Password = pass;
            Db.Entry(New).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        ///     查看对应ID的Account是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Account Find(int Id)
        {
            return Db.Account.Find(Id);
        }

        public List<Account> GetAccountsByClassname(string classname)
        {
            return Db.Account.Where(e => e.Class == classname).ToList();
        }

        public List<string> GetClassNames()
        {
            var x = Db.Account.ToList();
            var name = new List<string>();
            x.ForEach(e =>
            {
                var al = name.Find(a => a == e.Class);
                if (al == null)
                {
                    name.Add(e.Class);
                }
            });
            return name;
        }
    }
}