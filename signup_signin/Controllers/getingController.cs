using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace signup_signin.Controllers
{
    public class getingController : Controller
    {
        // GET: geting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(string id)
        {
            var dir = System.Web.HttpContext.Current.Server.MapPath("/UserImage");
            var path = Path.Combine(dir, id + ".jpg");
            return base.File(path, "image/jpeg");


        }

    }
}