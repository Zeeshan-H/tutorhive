using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;


namespace signup_signin.Controllers
{
    public class testingController : ApiController
    {
        [System.Web.Http.HttpGet]
        public img Get(string path)
        {
            using (tutorEntities entities = new tutorEntities())
            {

                return entities.imgs.FirstOrDefault(t => t.Path == path);

            }


        }



    }
}
