using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace signup_signin.Controllers
{
    public class uploController : ApiController
    {
        tutorEntities entities = new tutorEntities();
        [HttpPost]
        public HttpResponseMessage ImageUp()
        {

            var httpContext = (HttpContextWrapper)Request.Properties["MS_HttpContext"];
            img std = new img();
      //      std.Title = httpContext.Request.Form["Title"];
 //           std.RollNo = httpContext.Request.Form["RollNo"];
 //           std.Semester = httpContext.Request.Form["Semester"];

            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string random = Guid.NewGuid().ToString();
                string url = "/UserImage/" + random + httpRequest.Files[0].FileName.Substring(httpRequest.Files[0].FileName.LastIndexOf('.'));
                string path = System.Web.Hosting.HostingEnvironment.MapPath(url);
                httpRequest.Files[0].SaveAs(path);
                std.Path = "http://tutorsrep.azurewebsites.net/" + url;
            }
            entities.imgs.Add(std);
            entities.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);


        }

        [HttpGet]
        public IEnumerable<img> Get()
        {
            using (tutorEntities entities = new tutorEntities())
            {

                return entities.imgs.ToList();

            }





        }

    }
}
