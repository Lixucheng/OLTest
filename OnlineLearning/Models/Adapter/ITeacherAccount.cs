using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class ITeacherAccount:Models.Adapter.IAdapter
    {

        //增加用户
        public bool Add(Models.TeacherAccount teacher)
        {
            if (teacher.Name == null || teacher.PassWord == null)
            {
                throw new Exception("Name或PassWord不能为空");
            }
            Db.TeacherAccount.Add(teacher);
            Db.SaveChanges();
            return true;
        }

        //删除用户：通过模型删除
        public bool Remove(Models.TeacherAccount teacher)
        {
            var x = Db.TeacherAccount.Find(teacher.ID);
            if (x == null)
            {
                throw new Exception("用户不存在");
            }
            Db.TeacherAccount.Remove(x);
            Db.SaveChanges();
            return true;
        }
        ////删除用户：通过ID删除
        public bool Remove(long id)
        {
            var x = Db.TeacherAccount.Find(id);
            if (x == null)
            {
                throw new Exception("用户不存在");
            }
            Db.TeacherAccount.Remove(x);
            Db.SaveChanges();
            return true;
        }
        //删除用户：通过Name删除
        public bool Remove(string name)
        {
            var x = Db.TeacherAccount.FirstOrDefault(e => e.Name == name);
            if (x == null)
            {
                throw new Exception("用户不存在");
            }
            Db.TeacherAccount.Remove(x);
            Db.SaveChanges();
            return true;
        }

        //更改信息
        public bool Update(Models.TeacherAccount teacher)
        {
            var x = Db.TeacherAccount.Find(teacher.ID);
            if (x == null)
            {
                throw new Exception("用户不存在");
            }
            if (teacher.Name == null || teacher.PassWord == null)
            {
                throw new Exception("Name或PassWord不能为空");
            }
            x.Name = teacher.Name;
            x.PassWord = teacher.PassWord;
            x.Pic = teacher.Pic;
            x.Sex = teacher.Sex;
            x.Age = teacher.Age;
            x.Email = teacher.Email;
            Db.Entry(x).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        //寻找用户:通过ID查找
        public Models.TeacherAccount Find(long id)
        {
            var x = Db.TeacherAccount.Find(id);
            if (x == null)
            {
                throw new Exception("用户不存在");
            }
            return x;
        }

        //寻找用户:通过Name查找
        public Models.TeacherAccount Find(string name)
        {
            var x = Db.TeacherAccount.FirstOrDefault(e => e.Name == name);
            if (x == null)
            {
                throw new Exception("用户不存在");
            }
            return x;
        }
    }
}