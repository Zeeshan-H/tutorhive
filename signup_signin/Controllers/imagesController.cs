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
    public class imagesController : ApiController
    {


        public Task<IEnumerable<string>> Post()
        {

       

         

            if (Request.Content.IsMimeMultipartContent())
            {

                string fullPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider(fullPath);
                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    var fileInfo = streamProvider.FileData.Select(i =>
                    {
                        var info = new FileInfo(i.LocalFileName);
                        tutorEntities db = new tutorEntities();
                        test img = new test();
                        img.ImageData = File.ReadAllBytes(info.FullName);
                        img.imgPath = i.LocalFileName ;
                        db.tests.Add(img);
                        db.SaveChanges();
                        return "File uploaded successfully!";
                    });
                    return fileInfo;
                });
                return task;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Request!"));
            }
        }









        
        


        public List<int> Get()
        {
            tutorEntities db = new tutorEntities();
            var data = from i in db.tests
                       select i.Id;

            
            
            return data.ToList();
        }

   
    
        
      

        public HttpResponseMessage Get(int id)
        {
            tutorEntities db = new tutorEntities();
            var data = from i in db.tests
                       where i.Id == id
                       select i;
            test img = (test)data.SingleOrDefault();

           
            byte[] imgData = img.ImageData;
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            return response;
        }
        
        
    }
  
 
}
