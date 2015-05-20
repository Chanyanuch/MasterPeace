using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thammapirom.Models
{
    public class CustomEvent
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int cEventID { get; set; }
        [Required(ErrorMessage = "กรุณาระบุชื่อกิจกรรม")]
        [Display(Name = "ชื่อกิจกรรม")]
        public string cEventTitle { get; set; }
        [Required(ErrorMessage = "กรุณาระบุวันที่จัดกิจกรรม")]
        [Display(Name = "วันที่จัดกิจกรรม")]
        public string cEventDate { get; set; }
        [Required(ErrorMessage = "กรุณาระบุเวลาจัดกิจกรรม")]
        [Display(Name = "เวลาจัดกิจกรรม")]
        public string cEventTime { get; set; }
        [Required(ErrorMessage = "กรุณาระบุสถานที่จัดกิจกรรม")]
        [Display(Name = "สถานจัดกิจกรรม")]
        public string cEventLocation { get; set; }
        public string cEventPurpose { get; set; }
        [Required(ErrorMessage = "กรุณาระบุรายละเอียดกิจกรรม")]
        [Display(Name = "รายละเอียดกิจกรรม")]
        public string cEventDetail { get; set; }
    }
}