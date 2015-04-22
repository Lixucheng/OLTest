using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OnlineLearning.Models.Helper;

namespace OnlineLearning.Models.Adapter
{
    public class IQuestion:Models.Adapter.IAdapter
    {

        #region 创建问题  + Add(string content,string aop,string bop,string cop,string dop,string correctop,string image,int score)

        /// <summary>
        /// 创建问题
        /// </summary>
        /// <param name="content"></param>
        /// <param name="aop">answerA</param>
        /// <param name="bop">answer B</param>
        /// <param name="cop">answer C</param>
        /// <param name="dop">answer D</param>
        /// <param name="image"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public int Add(string content,string aop,string bop,string cop,string dop,string correctop,string image,int score)
        {
            if (String.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("内容为空！");
            }
            //ABCD　四个选项不能为空
            if(String.IsNullOrEmpty(aop))
            {
                throw new ArgumentNullException("A选项为空！");
            }
            if(String.IsNullOrEmpty(bop))
            {
                throw new ArgumentNullException("B选项为空！");
            }
            if(aop==bop)
            {
                throw new Exception("A,B选项重复！");
            }
            if(String.IsNullOrEmpty(cop))
            {
                throw new ArgumentNullException("C选项为空！");
            }
            if(cop==bop||cop==aop)
            {
                throw new Exception("C与A，B选项有所重复！");
            }
            if(String.IsNullOrEmpty(dop))
            {
                throw new ArgumentNullException("D选项为空！");
            }
            if(dop==aop||dop==bop||dop==cop)
            {
                throw new Exception("D选项与A,B,C选项有所重复！");
            }

            //正确答案不能为空 
            if(String.IsNullOrEmpty(correctop))
            {
                
                throw new ArgumentNullException("正确答案为空！");
            }

 
            if (score <= 0 || score > 100)
            {
                throw new Exception("请输出正确的分数！");
            }

            var　question=new Question()
            {           
                A_op=aop,
                B_op=bop,
                C_op=cop,
                D_op=dop,
                correct_op=correctop,
                Image=image,
                score = score,
                Question1 = content
            };

            Db.Question.Add(question);
            Db.SaveChanges();
            return 1;
        }

        #endregion

        #region 删除问题  +bool Remove(int keyid)
        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="keyid">主键</param>
        /// <returns></returns>
        public bool Remove(int keyid)
        {
            var question = Db.Question.Find(keyid);
            if(question==null)
            {
                throw new Exception("不存在该问题！");
            }
            Db.Question.Remove(question);
            Sgt.GetITest_question().DelQuest(keyid);
            Db.SaveChanges();
            return true;
        }
        #endregion

        #region 修改问题 +bool Update(int keyid,string aop,string bop,string cop,string dop,string image,int score)

        /// <summary>
        /// 修改问题
        /// </summary>
        /// <param name="keyid"></param>
        /// <param name="content"></param>
        /// <param name="aop"></param>
        /// <param name="bop"></param>
        /// <param name="cop"></param>
        /// <param name="dop"></param>
        /// <param name="correctop"></param>
        /// <param name="image"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool Update(int keyid, string content, string aop, string bop, string cop, string dop, string correctop, string image, int score)
        {
            var question=Db.Question.Find(keyid);
            if (question == null)
            {
                throw new Exception("不存在该问题！");
            }
            if (String.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("内容为空！");
            }
            //abcd选项不能为空且不能有重复
            if (String.IsNullOrEmpty(aop))
            {
                throw new ArgumentNullException("A选项为空！");
            }
            if (String.IsNullOrEmpty(bop))
            {
                throw new ArgumentNullException("B选项为空！");
            }
            if(aop==bop)
            {
                throw new Exception("A,B选项重复！");
            }
            if (String.IsNullOrEmpty(cop))
            {
                throw new ArgumentNullException("C选项为空！");
            }
            if(cop==bop||cop==aop)
            {
                throw new Exception("C与A，B选项有所重复！");
            }
            if (String.IsNullOrEmpty(dop))
            {
                throw new ArgumentNullException("D选项为空！");
            }
            if(dop==aop||dop==bop||dop==cop)
            {
                throw new Exception("D选项与A,B,C选项有所重复！");
            }


            //正确答案不能为空 且与ABCD其中之一相符
            if (String.IsNullOrEmpty(correctop))
            {

                throw new ArgumentNullException("正确答案为空！");
            }

        
            if (score <= 0 || score > 100)
            {
                throw new Exception("请输出正确的分数！");
            }

            question.Question1 = content;
            question.A_op = aop;
            question.B_op = bop;
            question.C_op = cop;
            question.D_op = dop;
            question.correct_op = correctop;
            question.Image = image;
            question.score = score;

            Db.Entry(question).State = EntityState.Modified;
            Db.SaveChanges();

            return true;

        }

        #endregion

        #region 凭借keyid返回对应问题 +Models.Question Find(int keyid)
        /// <summary>
        /// 凭借keyid返回对应问题
        /// </summary>
        /// <param name="keyid">主键</param>
        /// <returns></returns>
        public Models.Question Find(int keyid)
        {
            var question = Db.Question.Find(keyid);
            if(question==null)
            {
                throw new Exception("不存在该问题！");
            }

            return question;
        }
        #endregion

        #region 查找是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool QuestionExist(int id)
        {
            var x = Db.Question.Find(id);
            return x != null;
        }
        #endregion

        public List<HQuestion> GetAll()
        {
            var x= Db.Question.ToList();
            var r = new List<HQuestion>();
            x.ForEach(e =>
            {
                var n = new HQuestion
                {
                    A_op = new HtmlString(e.A_op),
                    B_op = new HtmlString(e.B_op),
                    C_op = new HtmlString(e.C_op),
                    D_op = new HtmlString(e.D_op),
                    Id = e.Id,
                    Image = e.Image,
                    Question1 = new HtmlString(e.Question1),
                    correct_op = e.correct_op,
                    score = e.score                    
                };
                r.Add(n);
            });
            return r;
        }

        public HQuestion GetHQuestionById(int id)
        {
            var e = Find(id);
            var res = new HQuestion()
            {
                A_op = new HtmlString(e.A_op),
                B_op = new HtmlString(e.B_op),
                C_op = new HtmlString(e.C_op),
                D_op = new HtmlString(e.D_op),
                Id = e.Id,
                Image = e.Image,
                Question1 = new HtmlString(e.Question1),
                correct_op = e.correct_op,
                score = e.score         
            };
            return res;
        }
    }
}