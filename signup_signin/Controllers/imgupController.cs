using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace signup_signin.Controllers
{
    public class imgupController : ApiController
    {
      
        
        
        [HttpPost]
        public async Task<string> Upload()
        {
            
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            // extract file name and file contents
            var fileNameParam = provider.Contents[0].Headers.ContentDisposition.Parameters
                .FirstOrDefault(p => p.Name.ToLower() == "filename");
            string fileName = (fileNameParam == null) ? "" : fileNameParam.Value.Trim('"');
            byte[] file = await provider.Contents[0].ReadAsByteArrayAsync();

            // Here you can use EF with an entity with a byte[] property, or
            // an stored procedure with a varbinary parameter to insert the
            // data into the DB

            tutorEntities entities = new tutorEntities();
            img im = new img();
            im.imgByte = file;
            im.Title = fileName;
            entities.imgs.Add(im);
            entities.SaveChanges();

            var result
                = string.Format("Received '{0}' with length: {1}", fileName, file.Length);
            return result;
        }

       
        [HttpGet]

        public List<int> GetImage()
        {
            tutorEntities db = new tutorEntities();
            var data = from i in db.imgs
                       select i.imgId;
            return data.ToList();
        }

        [HttpGet]

        public HttpResponseMessage GetImage(int id)
        {
            tutorEntities db = new tutorEntities();
            var data = from i in db.imgs
                       where i.imgId == id
                       select i;
            img im = (img)data.SingleOrDefault();
            byte[] imgData = im.imgByte;
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            return response;
        }

    }
}
