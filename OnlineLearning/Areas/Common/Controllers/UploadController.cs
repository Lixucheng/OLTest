using System;
using System.IO;
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
            var err = string.Empty;
            var subFolder = string.Empty;
            var filePath = string.Empty;
            ;
            var postedfile = filecollection[0];
            if (postedfile == null)
            {
                return null;
            }
            var fileName = Guid.NewGuid() + Path.GetExtension(Path.GetFileName(postedfile.FileName));
            var fullUrl = Path.Combine(Server.MapPath(@"~/uploadTmp"));
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