﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace OnlineLearning.Areas.Common.Controllers
{
    public class UploadController : Controller
    {
        // GET: Common/Upload
        public string Index()
        {
            var filecollection = Request.Files;
            string err = string.Empty;
            string subFolder = string.Empty;
            string filePath = string.Empty;
            ;
            HttpPostedFileBase postedfile = filecollection[0];
            if (postedfile == null)
            {
                return null;
            }
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Path.GetFileName(postedfile.FileName));
            string fullUrl = Path.Combine(Server.MapPath(@"~/uploadTmp"));
            if (Directory.Exists(fullUrl) == false)
            {
                Directory.CreateDirectory(fullUrl); //如果文件夹不存在，直接创建文件夹。
            }
            var filepath = Path.Combine(fullUrl, fileName);
            postedfile.SaveAs(filepath);
            return JsonConvert.SerializeObject(new
            {
                success = true,
                file_path = @"/uploadTmp/" + fileName
            });
        }
    }
}