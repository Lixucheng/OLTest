﻿using System.Web;

namespace OnlineLearning.Models.Adapter
{
    public class IAdapter
    {
        protected Singleton Sgt
        {
            get { return HttpContext.Current.Items["_Singleton"] as Singleton; }
        }

        protected OnlineLearningEntities Db
        {
            get { return Sgt.GetDbContext(); }
        }
    }
}