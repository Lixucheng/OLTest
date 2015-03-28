using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class IAdapter
    {
        protected OnlineLearningEntities db;

        protected Singleton sgt;

        public IAdapter()
        {
            sgt = new Singleton();
            db = sgt.GetDbContext();
        }
    }
}