using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using signup_signin.Models;
using System.IO;

namespace signup_signin.Controllers
{
    public class imageuploadController : Controller
    {
        // GET: imageupload
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult upload(ImageViewModel model)
        {
            tutorEntities et = new tutorEntities();
            int imgId = 0;
            var file = model.ImageFile;
            byte[] imagebyte = null;
            if (file != null)
            {

                file.SaveAs(Server.MapPath("/savedimages/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);
                img img = new img();
                img.Title = file.FileName;
                img.imgByte = imagebyte;
                img.Path = "/savedimages/" + file.FileName;
                et.imgs.Add(img);
                et.SaveChanges();
                imgId = img.imgId;

            }

            return Json(imgId, JsonRequestBehavior.AllowGet);

        }


        public ActionResult display(int imgId)
        {
            tutorEntities et = new tutorEntities();

            var img = et.imgs.SingleOrDefault(x => x.imgId == imgId);

            return File(img.imgByte, "image/jpg");
        }


    }
}