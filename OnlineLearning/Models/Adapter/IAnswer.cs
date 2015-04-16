using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineLearning.Models.Adapter
{
    public class IAnswer:Models.Adapter.IAdapter
    {
        //增加答案
        public bool Add(Models.Answer answer)
        {
            if (answer.Answer1 == null || answer.questionId == null || answer.studentId == null || answer.TestId == null)
            {
                throw new Exception("模型的所有属性都不能为空");
            }
            Db.Answer.Add(answer);
            Db.SaveChanges();
            return true;
        }

        //删除答案：通过模型删除
        public bool Remove(Models.Answer answer)
        {
            var x = Db.Answer.Find(answer.Id);
            if (x == null)
            {
                throw new Exception("答案不存在");
            }
            Db.Answer.Remove(x);
            Db.SaveChanges();
            return true;
        }
        ////删除答案：通过ID删除
        public bool RemoveById(int id)
        {
            var x = Db.Answer.Find(id);
            if (x == null)
            {
                throw new Exception("答案不存在");
            }
            Db.Answer.Remove(x);
            Db.SaveChanges();
            return true;
        }
        //删除答案：通过学生删除
        public bool RemoveByStudentId(int id)
        {
            var x = Db.Answer.FirstOrDefault(e => e.studentId == id);
            if (x == null)
            {
                throw new Exception("答案不存在");
            }
            Db.Answer.Remove(x);
            Db.SaveChanges();
            return true;
        }

        //更改答案
        public bool Update(Models.Answer answer)
        {
            var x = Db.Answer.Find(answer.Id);
            if (x == null)
            {
                throw new Exception("答案不存在");
            }
            if (answer.Answer1 == null || answer.questionId == null || answer.studentId == null || answer.TestId == null)
            {
                throw new Exception("模型的所有属性都不能为空");
            }
            x.questionId = answer.questionId;
            x.studentId = answer.studentId;
            x.TestId = answer.TestId;
            x.Answer1 = answer.Answer1;
            Db.Entry(x).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        //寻找答案:通过ID查找
        public Models.Answer Find(int id)
        {
            var x = Db.Answer.Find(id);
            if (x == null)
            {
                throw new Exception("答案不存在");
            }
            return x;
        }

        //寻找答案:通过问题查找
        public Models.Answer FindByQuestionId(int id)
        {
            var x = Db.Answer.FirstOrDefault(e => e.questionId == id);
            if (x == null)
            {
                throw new Exception("答案不存在");
            }
            return x;
        }

        //寻找答案:通过各种id查找
        public Models.Answer FindByAllid(int testid,int questionId,int studentid)
        {
            var x = Db.Answer.FirstOrDefault(e => e.studentId== studentid&&e.TestId==testid&&e.questionId==questionId);
            if (x == null)
            {
                throw new Exception("答案不存在");
            }
            return x;
        }
    }
}