using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace signup_signin.Models
{
    public class ImageModel
    {

        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string imgPath { get; set; }

        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}