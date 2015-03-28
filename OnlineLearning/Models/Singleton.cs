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
        protected Models.Score Score;

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public Models.Score GetScore()
        {
            return Score ?? (Score = new Score());
        }
        #endregion
    }
}