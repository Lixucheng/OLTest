using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace OnlineLearning.Models.Adapter
{
    public class ITest:IAdapter
    {
        /// <summary>
        /// 查看id是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool TestExist(int id)
        {
            var x = Db.Test.Find(id);
            return x != null;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Test Find(int id)
        {
            var x = Db.Test.Find(id);
            if (x == null)
            {
                throw new Exception("没有这个考试");
            }
            return x;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="x"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool Add(String x,TimeSpan time)
        {
            if (String.IsNullOrEmpty(x))
            {
                throw new Exception("name不能为空");
            }
            if (time == TimeSpan.Zero)
            {
                throw new Exception("时间不能为0");
            }      
            var t=new Test {Name = x,Time = time};
            Db.Test.Add(t);
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Del(int id)
        {
            var x = Db.Test.Find(id);
            if (x==null)
                throw new Exception("没有你删啥！");
            Db.Test.Remove(x);
            Db.SaveChanges();
            return true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool Update(int id, string name, TimeSpan time)
        {
            var x = Db.Test.Find(id);
            if (x == null)
                throw new Exception("没有你改啥！");
            if (String.IsNullOrEmpty(name))
            {
                throw new Exception("name不能为空");
            }
            if (time == TimeSpan.Zero)
            {
                throw new Exception("时间不能为0");
            }      
            x.Name = name;
            x.Time = time;
            Db.SaveChanges();
            return true;
        }

        #region 返回一个test的习题
        /// <summary>
        /// 返回一个test的习题
        /// </summary>
        /// <param name="testid"></param>
        /// <returns></returns>
        public List<Question> GetQuestionsByTestId(int testid)
        {
            return Sgt.GetITest_question().GetQuestionsByTestId(testid);
        }
        #endregion

        /// <summary>
        /// 获取所有习题
        /// </summary>
        /// <returns></returns>
        public List<Test> GetTests()
        {
            return Db.Test.ToList();
        }

        /// <summary>
        /// 提交之后计算分数
        /// </summary>
        /// <param name="testid"></param>
        /// <param name="studentid"></param>
        public void CalculateScore(int testid, int studentid)
        {
            var questions = GetQuestionsByTestId(testid);
            int sco=0;
            questions.ForEach(e =>
            {
                var answer = Sgt.GetAnswer().FindByAllid(testid, e.Id, studentid);
                if (answer.Answer1==e.correct_op)
                {
                    sco += e.score;
                }
            });
            Sgt.GetScore().Add(studentid, testid, sco);
        }
    }

}