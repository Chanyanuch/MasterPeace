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
         [Required(ErrorMessage = "กรุณาระบุเลิ้งรูปภาพ เช่น http://i.imgur.com/HetuxRO.png")]
         [Display(Name = "ลิ้งรูปภาพ")]
        public string ImageData { get; set; }
       
    }
}