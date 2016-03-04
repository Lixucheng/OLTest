using OnlineLearning.Models.Adapter;

namespace OnlineLearning.Models
{
    public class Singleton
    {
        public void Dispose()
        {
            if (TheContext != null)
                TheContext.Dispose();
        }

        #region Context

        //数据库上下文单例
        protected OnlineLearningEntities TheContext;

        /// <summary>
        ///     获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public OnlineLearningEntities GetDbContext()
        {
            return TheContext ?? (TheContext = new OnlineLearningEntities());
        }

        #endregion

        #region Account

        //数据库上下文单例
        protected IAccount Account;

        /// <summary>
        ///     获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public IAccount GetAccount()
        {
            return Account ?? (Account = new IAccount());
        }

        #endregion

        #region Score

        //分数上下文单例
        protected IScore Score;

        /// <summary>
        ///     获取分数上下文
        /// </summary>
        /// <returns></returns>
        public IScore GetScore()
        {
            return Score ?? (Score = new IScore());
        }

        #endregion

        #region Test

        //测试上下文单例
        protected ITest Test;

        /// <summary>
        ///     获取考试上下文
        /// </summary>
        /// <returns></returns>
        public ITest GetTest()
        {
            return Test ?? (Test = new ITest());
        }

        #endregion

        #region teacherAccount

        //数据库上下文单例
        protected ITeacherAccount TeacherAccount;

        /// <summary>
        ///     获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public ITeacherAccount GetTeacherAccount()
        {
            return TeacherAccount ?? (TeacherAccount = new ITeacherAccount());
        }

        #endregion

        #region Answer

        //答案上下文单例
        protected IAnswer Answer;

        /// <summary>
        ///     获取答案上下文
        /// </summary>
        /// <returns></returns>
        public IAnswer GetAnswer()
        {
            return Answer ?? (Answer = new IAnswer());
        }

        #endregion

        #region Question

        //问题上下文单例
        protected IQuestion Question;

        /// <summary>
        ///     获取问题上下文
        /// </summary>
        /// <returns></returns>
        public IQuestion GetQuestion()
        {
            return Question ?? (Question = new IQuestion());
        }

        #endregion

        #region ITest_question

        //数据库上下文单例
        protected ITest_question ITest_question;

        /// <summary>
        ///     获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public ITest_question GetITest_question()
        {
            return ITest_question ?? (ITest_question = new ITest_question());
        }

        #endregion

        #region IPart

        //数据库上下文单例
        protected IPart IPart;

        /// <summary>
        ///     获单元上下文
        /// </summary>
        /// <returns></returns>
        public IPart GetIPart()
        {
            return IPart ?? (IPart = new IPart());
        }

        #endregion
    }
}