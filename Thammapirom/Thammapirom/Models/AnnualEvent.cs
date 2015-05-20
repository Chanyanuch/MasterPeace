using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thammapirom.Models
{
    public class AnnualEvent
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int aEventID { get; set; }
        [Required(ErrorMessage = "กรุณาระบุชื่อกิจกรรม")]
        [Display(Name = "ชื่อกิจกรรม")]
        public string aEventTitle { get; set; }
        [Required(ErrorMessage = "กรุณาระบุรายละเอียดกิจกรรม")]
        [Display(Name = "รายละเอียดกิจกรรม")]
        public string aEventDetail { get; set; }
        [Required(ErrorMessage = "กรุณาระบุวันที่จัดกิจกรรม")]
        [Display(Name = "วันที่จัดกิจกรรม")]
        public string aEventDate { get; set; }
        [Required(ErrorMessage = "กรุณาระบุเวลาจัดกิจกรรม")]
        [Display(Name = "เวลาจัดกิจกรรม")]
        public string aEventTime { get; set; }
        [Required(ErrorMessage = "กรุณาระบุสถานที่จัดกิจกรรม")]
        [Display(Name = "สถานจัดกิจกรรม")]
        public string aEventLocation { get; set; }  
       
    }
}