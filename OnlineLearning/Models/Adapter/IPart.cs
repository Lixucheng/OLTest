using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class IPart: IAdapter
    {
        //添加单元
        public bool Add(string name ,int no)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("单元标题不能为空");
            }          
            var x = Db.part.FirstOrDefault(e => e.No == no);
            if (no == 0&&x!=null)
            {
                throw new Exception("请添加正确的no");
            }
            var newone = new part {Name = name, No = no};
            Db.part.Add(newone);
            Db.SaveChanges();
            return true;
        }

        //删除单元
        public bool Del(int id)
        {
            var x = Db.part.Find(id);
            if (x==null)
            {
                throw new Exception("没有你删除什么！");
            }
            Db.part.Remove(x);
            Db.SaveChanges();
            return true;
        }

        //修改单元
        public bool Update(int id, string name, int no)
        {
            var y = Db.part.Find(id);
            if (y==null)
            {
                throw new Exception("没有！");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("单元标题不能为空");
            }
            var x = Db.part.FirstOrDefault(e => e.No == no);
            if (no == 0 && x != null)
            {
                throw new Exception("请添加正确的no");
            }
            y.Name = name;
            y.No = no;
            Db.SaveChanges();
            return true;
        }

        //返回所有
        public List<part> GetAll()
        {
            return Db.part.ToList();
        }
    }
}