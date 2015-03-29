using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class IScore:Models.Adapter.IAdapter
    {   
        //判断studentid等是否输入的函数还未完成，完成后将-1等替代
        #region 创建新成绩 +int Add(int studentid=-1,int testid=-1,double score=-1
        /// <summary>
        /// 创建新成绩   
        /// sgt.GetStudentAdapter().StudentExist(studentid)未实现
        /// sgt.GetTestAdapter().TestExist(testid)未实现
        /// </summary>
        /// <param name="studentid">学生id</param>
        /// <param name="testid">测试id</param>
        /// <param name="scroe">学生成绩</param>
        /// <returns></returns>
        public int Add(int studentid=-1,int testid=-1,double score=-1)
        {   
            //学生Id不能为空
            if(studentid==-1)
            {
                throw new Exception("StudentId为空!");
            }
            //测试Id不能为空
            if (testid == -1)
            {
                throw new Exception("TestId为空!");
            }
            //成绩不能为空
            if (score == -1)
            {
                throw new Exception("Score为空！");
            }
            //此函数还未实现 用于判断是否存在testid对应测试
            if(Sgt.GetTest().TestExist(testid)==false)
            {
                throw new Exception("不存在该测试！");
            }
            //Todo:此函数还未实现  用于判断是否存在studentid 对应学生
            //if(sgt.GetStudentAdapter().StudentExist(studentid)==false)
            //{
            //    throw new Exception("不存在该学生！");
            //}

            var tmp = Db.Score.FirstOrDefault(e => e.StudentId == studentid && e.TestId == testid);
            if(tmp!=null)
            {
                throw new Exception("已存在该数据！");
            }

            var iscore = new Score()
            {
                StudentId = studentid,
                TestId = testid,
                Score1 = score,
            };
            Db.Score.Add(iscore);
            Db.SaveChanges();
            return iscore.Id;
        }
        #endregion

        #region 删除成绩 +bool Remove(int keyid)
        /// <summary>
        /// 删除成绩
        /// </summary>
        /// <param name="id">keyid</param>
        /// <returns></returns>
        public bool Remove(int keyid)
        {
            var iscore = Db.Score.FirstOrDefault(e => e.Id == keyid);
            if (iscore == null)
            {
                throw new Exception("不存在该项成绩！");
            }

            Db.Score.Remove(iscore);
            Db.SaveChanges();
            return true;
        }
        #endregion

        #region 修改成绩 +bool Update(int id = -1, int studentid = -1, int testid = -1, double score = -1)
        /// <summary>
        /// 修改成绩
        /// </summary>
        /// <param name="id">keyid</param>
        /// <param name="studentid">学生id</param>
        /// <param name="testid">测试id</param>
        /// <param name="score">成绩</param>
        /// <returns></returns>
        public bool Update(int id = -1, int studentid = -1, int testid = -1, double score = -1)
        {   
            //keyid不能为空
            if (id == -1)
            {
                throw new Exception("id为空！");
            }
            //学生id不能为空
            if (studentid == -1)
            {
                throw new Exception("StudentId为空!");
            }
            //测试Id不能为空
            if (testid == -1)
            {
                throw new Exception("TestId为空!");
            }
            //成绩不能为空
            if (score == -1)
            {
                throw new Exception("Score为空！");
            }

            var iscore = Db.Score.Find(id);
            if (iscore == null)
            {
                throw new Exception("不存在欲修改的数据！");
            }

           iscore.StudentId = studentid;
           iscore.TestId = testid;
           iscore.Score1 = score;

           Db.Entry(iscore).State = EntityState.Modified;
           Db.SaveChanges();
           return true;
        }
        #endregion

        #region 凭keyid查找成绩项 + Models.Score Find(int keyid=-1)
        /// <summary>
        /// 凭keyid查找成绩项
        /// </summary>
        /// <param name="id">keyid</param>
        /// <returns></returns>
         public Models.Score Find(int keyid=-1)
         {
             //keyid不能为空
             if (keyid == -1)
            {
                throw new Exception("keyid为空！");
            }
            return Db.Score.Find(keyid);
         }
        #endregion

         #region 返回所有testid相同的成绩项 +List<Models.Score> GetAllTestidList(int testid=-1)
         /// <summary>
        /// 返回所有testid相同的成绩项
        /// </summary>
        /// <param name="testid">测试id</param>
        /// <returns></returns>
        public List<Models.Score> GetAllTestidList(int testid=-1)
         {
             //测试Id不能为空
             if (testid == -1)
             {
                 throw new Exception("TestId为空!");
             }
             return Db.Score.Where(e => e.TestId == testid).ToList();

         }
         #endregion

        #region 返回studentid对应学生的所有成绩项 +List<Models.Score> GetAllStudentidList(int studentid=-1)
        /// <summary>
        /// 返回studentid对应学生的所有成绩项
        /// </summary>
        /// <param name="studentid">学生id</param>
        /// <returns></returns>
        public List<Models.Score> GetAllStudentidList(int studentid=-1) 
        {
            //student不能为空
            if (studentid == -1)
            {
                throw new Exception("StudentId为空!");
            }

            return Db.Score.Where(e => e.StudentId == studentid).ToList();
        }
        #endregion

        #region 返回所有成绩为score的成绩项 +List<Models.Score> GetAllScoreList(double score=-1)
        /// <summary>
        /// 返回所有成绩为score的成绩项
        /// </summary>
        /// <param name="score">成绩</param>
        /// <returns></returns>
        public List<Models.Score> GetAllScoreList(double score=-1) 
        {
            //score不能为空
            if (score == -1)
            {
                throw new Exception("score为空!");
            }

            return Db.Score.Where(e => e.Score1 == score).ToList();
        }

        #endregion

    }

}