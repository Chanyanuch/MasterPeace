using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Thammapirom.Models
{
    public class WelcomeImage
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ImageID { get; set; }
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
       
    }
}