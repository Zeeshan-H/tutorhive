using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace signup_signin.Models
{
    public class ImageViewModel
    {
        public int imgId { get; set; }
        public string Title { get; set; }
        public byte[] imgByte { get; set; }
        public string Path { get; set; }

        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}