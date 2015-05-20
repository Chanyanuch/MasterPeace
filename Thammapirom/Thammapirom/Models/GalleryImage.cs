using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Thammapirom.Models
{
    public class GalleryImage
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ImageID { get; set; }
        [Required(ErrorMessage = "กรุณาระบุเลิ้งรูปภาพ เช่น http://i.imgur.com/qeF2c4e.jpg")]
         [Display(Name = "ลิ้งรูปภาพ")]
        public string ImageData { get; set; }
    }
}