using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;


namespace Thammapirom.Models
{
 
    public class ActivityClip

    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ClipID { get; set; }
         [Required(ErrorMessage = "กรุณาระบุเชื่อคลิป เช่น กฐินสามัคคีวัดป่าธรรมาภิรมย์ ปี ๕๕ แผ่นที่ ๑  (๔ พฤศจิกายน พ.ศ. ๒๕๕๕)")]
        [Display(Name = "ชื่อคลิป")]
        public string ClipTitle { get; set; }
         [Required(ErrorMessage = "กรุณาระบุลิ้งคลิป เช่น https://www.youtube.com/embed/Q1wpgnd9Jyg")]
        [Display(Name = "ลิ้ง")]
        public string ClipEmbedCode { get; set; }      
    }
}