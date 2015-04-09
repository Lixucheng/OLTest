using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models
{
    public class Singleton
    {
        #region Context
        //数据库上下文单例
        protected OnlineLearningEntities TheContext;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public OnlineLearningEntities GetDbContext()
        {
            return TheContext ?? (TheContext = new OnlineLearningEntities());
        }
        #endregion

        public void Dispose()
        {
            if (TheContext != null)
                TheContext.Dispose();
        }

       

        #region Account
        //数据库上下文单例
        protected Models.Adapter.IAccount Account;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Models.Adapter.IAccount GetAccount()
        {
            return Account ?? (Account = new Adapter.IAccount());
        }
        #endregion


        #region Score
        //数据库上下文单例
        protected Models.Adapter.IScore Score;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Models.Adapter.IScore GetScore()
        {
            return Score ?? (Score = new Adapter.IScore());
        }
        #endregion


        #region Test
        //数据库上下文单例
        protected Adapter.ITest Test;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Adapter.ITest GetTest()
        {
            return Test ?? (Test = new Adapter.ITest());
        }
        #endregion

        #region teacherAccount
        //数据库上下文单例
        protected Models.TeacherAccount TeacherAccount;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Models.TeacherAccount GetTeacherAccount()
        {
            return TeacherAccount ?? (TeacherAccount = new TeacherAccount());
        }
        #endregion

        #region Answer
        //数据库上下文单例
        protected Models.Answer Answer;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Models.Answer GetAnswer()
        {
            return Answer ?? (Answer = new Answer());
        }
        #endregion


        #region Question
        //数据库上下文单例
        protected Models.Adapter.IQuestion Question;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Models.Adapter.IQuestion GetQuestion()
        {
            return Question ?? (Question = new Adapter.IQuestion());
        }
        #endregion


        #region ITest_question
        //数据库上下文单例
        protected Models.Adapter.ITest_question ITest_question;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Models.Adapter.ITest_question GetITest_question()
        {
            return ITest_question ?? (ITest_question = new Adapter.ITest_question());
        }
        #endregion

    }
}