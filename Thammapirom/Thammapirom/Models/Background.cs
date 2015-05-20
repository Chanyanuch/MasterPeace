using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Thammapirom.Models
{
    public class Background
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int BackgroundID { get; set; }
         [Required(ErrorMessage = "กรุณาระบุข้อมูล")]
        public string BackgroundInfo { get; set; }      
    }
}