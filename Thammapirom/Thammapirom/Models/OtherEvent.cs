using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thammapirom.Models
{
    public class OtherEvent
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int oEventID { get; set; }

        [Required(ErrorMessage = "กรุณาระบุชื่อกิจกรรม")]
        [Display(Name = "ชื่อกิจกรรม")]
        public string oEventTitle { get; set; }
        [Required(ErrorMessage = "กรุณาระบุรายละเอียดกิจกรรม")]
        [Display(Name = "รายละเอียดกิจกรรม")]
        public string oEventDetail { get; set; }
        [Required(ErrorMessage = "กรุณาระบุวันที่จัดกิจกรรม")]
        [Display(Name = "วันที่จัดกิจกรรม")]
        public string oEventDate { get; set; }
        [Required(ErrorMessage = "กรุณาระบุเวลาจัดกิจกรรม")]
        [Display(Name = "เวลาจัดกิจกรรม")]
        public string oEventTime { get; set; }
        [Required(ErrorMessage = "กรุณาระบุสถานที่จัดกิจกรรม")]
        [Display(Name = "สถานจัดกิจกรรม")]
        public string oEventLocation { get; set; }
        [Display(Name = "จุดประสงค์กิจกรรม")]
        public string oEventPurpose { get; set; }
    }
}