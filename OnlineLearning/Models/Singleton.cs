﻿using System;
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
        protected Models.Account Account;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Models.Account GetAccount()
        {
            return Account ?? (Account = new Account());
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
    }
}