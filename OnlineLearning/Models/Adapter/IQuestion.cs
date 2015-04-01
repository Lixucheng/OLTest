using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class IQuestion:Models.Adapter.IAdapter
    {

        #region 创建问题  + int Add(string aop,string bop,string cop,string dop,string correctop,string image,int partid)
        /// <summary>
        /// 创建问题
        /// </summary>
        /// <param name="aop">answerA</param>
        /// <param name="bop">answer B</param>
        /// <param name="cop">answer C</param>
        /// <param name="dop">answer D</param>
        /// <param name="image"></param>
        /// <param name="partid">所属单元id</param>
        /// <returns></returns>
        public int Add(string aop,string bop,string cop,string dop,string correctop,string image,int partid)
        {   
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

            //正确答案不能为空 且与ABCD其中之一相符
            if(String.IsNullOrEmpty(correctop))
            {
                
                throw new ArgumentNullException("正确答案为空！");
            }

            if(correctop!=aop&&correctop!=bop&&correctop!=cop&&correctop!=dop)
            {
                throw new Exception("答案不存在于ABCD四个选项中！");
            }
            var x=Db.part.Find(partid);
            if(x==null)
            {
                throw new Exception("不存在该问题所属单元！");
            }

            var　question=new Question()
            {
                A_op=aop,
                B_op=bop,
                C_op=cop,
                D_op=dop,
                correct_op=correctop,
                Image=image,
                PartId=partid
            };

            Db.Question.Add(question);
            Db.SaveChanges();
            return question.Id;
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
            Db.SaveChanges();
            return true;
        }
        #endregion

        
        #region 修改问题 +bool Update(int keyid,string aop,string bop,string cop,string dop,string image,int partid)
        /// <summary>
        /// 修改问题
        /// </summary>
        /// <param name="keyid"></param>
        /// <param name="aop"></param>
        /// <param name="bop"></param>
        /// <param name="cop"></param>
        /// <param name="dop"></param>
        /// <param name="image"></param>
        /// <param name="partid"></param>
        /// <returns></returns>
        public bool Update(int keyid, string aop, string bop, string cop, string dop, string correctop, string image, int partid)
        {
            var question=Db.Question.Find(keyid);
            if(question==null)
            {
                throw new Exception("不存在该问题！");
            }

            //abcd选项不能为空且不能有重复
            if(aop==null)
            {
                throw new ArgumentNullException("A选项为空！");
            }
            if(bop==null)
            {
                throw new ArgumentNullException("B选项为空！");
            }
            if(aop==bop)
            {
                throw new Exception("A,B选项重复！");
            }
            if(cop==null)
            {
                throw new ArgumentNullException("C选项为空！");
            }
            if(cop==bop||cop==aop)
            {
                throw new Exception("C与A，B选项有所重复！");
            }
            if(dop==null)
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

            if (correctop != aop && correctop != bop && correctop != cop && correctop != dop)
            {
                throw new Exception("答案不存在于ABCD四个选项中！");
            }
            var x = Db.part.Find(partid);
            if (x == null)
            {
                throw new Exception("不存在该问题所属单元！");
            }

            question.A_op = aop;
            question.B_op = bop;
            question.C_op = cop;
            question.D_op = dop;
            question.correct_op = correctop;
            question.PartId=partid;
            question.Image = image;

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

    }
}