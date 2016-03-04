using System;
using System.Collections.Generic;
using System.Linq;
using OnlineLearning.Models.Helper;

namespace OnlineLearning.Models.Adapter
{
    public class ITest_question : IAdapter
    {
        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="testid"></param>
        /// <param name="questionid"></param>
        /// <returns></returns>
        public bool Add(int testid, int questionid)
        {
            if (!Sgt.GetQuestion().QuestionExist(questionid))
            {
                throw new Exception("不存在此question");
            }
            if (!Sgt.GetTest().TestExist(testid))
            {
                throw new Exception("不存在此test");
            }
            var x = Db.Test_question.Where(e => e.QuestionId == questionid && e.TestId == testid).ToList();
            if (x.Count > 0)
            {
                throw new Exception("重复添加");
            }
            var testQuestion = new Test_question {QuestionId = questionid, TestId = testid};
            Db.Test_question.Add(testQuestion);
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        ///     修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testid"></param>
        /// <param name="questionid"></param>
        /// <returns></returns>
        public bool Update(int id, int testid, int questionid)
        {
            if (!Sgt.GetQuestion().QuestionExist(questionid))
            {
                throw new Exception("不存在此question");
            }
            if (!Sgt.GetTest().TestExist(testid))
            {
                throw new Exception("不存在此test");
            }
            var x = Db.Test_question.Find(id);
            if (x == null)
            {
                throw new Exception("没有你改什么！");
            }
            var y = Db.Test_question.Where(e => e.QuestionId == questionid && e.TestId == testid).ToList();
            if (y.Count > 0)
            {
                throw new Exception("重复");
            }
            x.QuestionId = questionid;
            x.TestId = testid;
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Del(int id)
        {
            var x = Db.Test_question.Find(id);
            if (x == null)
            {
                throw new Exception("没有你删什么！");
            }
            Db.Test_question.Remove(x);
            Db.SaveChanges();
            return true;
        }

        public bool Del(int testid, int questid)
        {
            var x = Db.Test_question.FirstOrDefault(e => e.TestId == testid && e.QuestionId == questid);
            if (x == null)
            {
                throw new Exception("没有你删什么！");
            }
            Db.Test_question.Remove(x);
            Db.SaveChanges();
            return true;
        }

        public bool DelTest(int testid)
        {
            var x = Db.Test_question.Where(e => e.TestId == testid).ToList();
            Db.Test_question.RemoveRange(x);
            Db.SaveChanges();
            return true;
        }

        public bool DelQuest(int questid)
        {
            var x = Db.Test_question.Where(e => e.QuestionId == questid).ToList();
            Db.Test_question.RemoveRange(x);
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        ///     返回一个Test的习题
        /// </summary>
        /// <param name="testid"></param>
        /// <returns></returns>
        public List<HQuestion> GetHQuestionsByTestId(int testid)
        {
            var list = Db.Test_question.Where(e => e.TestId == testid).ToList();
            var ret = new List<HQuestion>();
            list.ForEach(e => ret.Add(Sgt.GetQuestion().GetHQuestionById(e.QuestionId)));
            return ret;
        }

        public List<Question> GetQuestionsByTestId(int testid)
        {
            var list = Db.Test_question.Where(e => e.TestId == testid).ToList();
            var ret = new List<Question>();
            list.ForEach(e => ret.Add(Sgt.GetQuestion().Find(e.QuestionId)));
            return ret;
        }
    }
}