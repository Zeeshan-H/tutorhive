using signup_signin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace signup_signin.Controllers
{
    public class finalupController : ApiController
    {
        [Mime]
        public async Task<FileUploadDetails> Post()
        {
            // file path
            var fileuploadPath = HttpContext.Current.Server.MapPath("~/UserImage");
            tutorEntities db = new tutorEntities();
            img im = new img();

            // 
            var multiFormDataStreamProvider = new MultiFileUploadProvider(fileuploadPath);

            // Read the MIME multipart asynchronously 
            await Request.Content.ReadAsMultipartAsync(multiFormDataStreamProvider);

            string uploadingFileName = multiFormDataStreamProvider
                .FileData.Select(x => x.LocalFileName).FirstOrDefault();

            im.Title = Path.GetFileName(uploadingFileName);
            im.Path = uploadingFileName;
            db.imgs.Add(im);
            db.SaveChanges();
            
            // Create response, assigning appropriate values to properties 
            return new FileUploadDetails
            {
                FilePath = uploadingFileName,

                FileName = Path.GetFileName(uploadingFileName),

                FileLength = new FileInfo(uploadingFileName).Length,

                FileCreatedTime = DateTime.Now.ToLongDateString()
            
            
            
            };

         

        }
 
    }
}
