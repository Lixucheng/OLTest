using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class ITest:IAdapter
    {
        public bool TestExist(int id)
        {
            var x = Db.Test.Find(id);
            return x != null;
        }
    }
}