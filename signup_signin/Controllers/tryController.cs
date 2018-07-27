using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace signup_signin.Controllers
{
    public class tryController : ApiController
    {
        [HttpGet]
        
        
        public HttpResponseMessage ImageGet(string imagename)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            var path = "~/UserImage/" + imagename;
            path = System.Web.Hosting.HostingEnvironment.MapPath(path);
            var ext = System.IO.Path.GetExtension(path);

            var contents = System.IO.File.ReadAllBytes(path);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(contents);

            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/" + ext);

            return response;
        }

        
    }
}
