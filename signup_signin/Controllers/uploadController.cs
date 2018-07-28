using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace signup_signin.Controllers
{
    public class uploadController : Controller
    {
        // GET: upload
        [HttpGet]
        public ActionResult SaveImages()
        {


            return View();
        }

        [HttpPost]

        public ActionResult SaveImages(HttpPostedFileBase uploadedImage)
        {
            tutorEntities entities = new tutorEntities();

            tbl_img img = new tbl_img();

           

            if (uploadedImage.ContentLength > 0)
            {

               string imgFileName = Path.GetFileName(uploadedImage.FileName);

                string FolderPath = Path.Combine(Server.MapPath("~/UploadedImages"), imgFileName);
               
                uploadedImage.SaveAs(FolderPath);
            }

            img.imgName = uploadedImage.FileName;
            img.imgPath = "H:/Ms Visual Studio 2013  Ultimate + Serial [danhuk]/Projects/signup_signin/signup_signin/UploadedImages/" + uploadedImage.FileName;
            entities.tbl_img.Add(img);
            entities.SaveChanges();

            ViewBag.imgName = uploadedImage.FileName;


            ViewBag.Message = "Image File is uploaded successfuly";


            var obj = entities.tbl_img.Where(c => c.imgId == img.imgId).FirstOrDefault();

            if (obj != null)
            {

                img.imgName = obj.imgName;
            }

            return View(img);
        }


    }
}