using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPilot.DbContext;
using MvcPilot.Entities;
using MvcPilot.Models;

namespace MvcPilot.Controllers
{
    public class ImageController : Controller
    {
        ImageStoreEntity imageStoreEntity = new ImageStoreEntity();
        // GET: Image
        public ActionResult Index()
        {
            ImageStoreEntity imageStoreEntity=new ImageStoreEntity();
            var list=imageStoreEntity.GetAll();
            return View(list);
        }

        [HttpPost]
        public ActionResult UploadFile(IEnumerable<HttpPostedFileBase> filename)
        {
            foreach (var file in filename)
            {
                if (file.ContentLength > 0)
                {
                    ImageStore imageStore=new ImageStore();
                    //原始文件名称
                    imageStore.Name = Path.GetFileName(file.FileName);
                    //文件类型
                    imageStore.MimeType = file.ContentType;

                    using (Stream inputStream=file.InputStream)
                    {
                        MemoryStream memoryStream=inputStream as MemoryStream;
                        if (memoryStream != null)
                        {
                            memoryStream=new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        imageStore.Content = memoryStream.ToArray();
                    }
                    //后缀名
                    string ext = Path.GetExtension(file.FileName);
                    //新名称
                    string newName =DateTimeOffset.Now.ToString();
                    string newSrc =
                        Server.MapPath("/Upload/" + DateTime.Now.ToString("yyyyMMdd") + "/" + newName + "." + ext);
                    file.SaveAs(newSrc);
                    imageStore.Src = newSrc;
                    imageStoreEntity.Inset(imageStore);

                }
            }
            return RedirectToAction("Index");

        }
    }
}