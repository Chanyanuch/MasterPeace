using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thammapirom.Models
{
    public class Event
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int EventID { get; set; }
        [Display(Name = "ชื่อกิจกรรม")]
        public string EventTitle { get; set; }
        [Display(Name = "รายละเอียดกิจกรรม")]
        public string EventDetail { get; set; }
        [Display(Name = "วันที่จัดกิจกรรม")]
        public string EventDate { get; set; }
        [Display(Name = "เวลาจัดกิจกรรม")]
        public string EventTime { get; set; }
        [Display(Name = "สถานจัดกิจกรรม")]
        public string EventLocation { get; set; }   
    }
}