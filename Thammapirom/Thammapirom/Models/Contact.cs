using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
namespace Thammapirom.Models
{
    public class Contact
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ContactID { get; set; }
        [Required(ErrorMessage = "กรุณาระบุชื่อของผู้ติดต่อ")]
        [Display(Name = "ผู้ติดต่อ")]
        public string Sender { get; set; }
        [Required(ErrorMessage = "กรุณารุบะอีเมลล์ติดต่อกลับ")]
        [RegularExpression(".+\\@.+\\..+",
        ErrorMessage = "กรุณาระบุอีเมลล์ให้ถูกต้อง")]
        [Display(Name = "อีเมลล์ผู้ติดต่อ")]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "กรุณาระบุหัวเรื่อง")]
        [Display(Name = "หัวเรื่องติดต่อ")]
        public string ContactTitle { get; set; }
        [Required(ErrorMessage = "กรุณาระบุข้อความของคุณ")]
        [Display(Name = "ข้อความ")]
        public string ContactMessage { get; set; }
    }
}