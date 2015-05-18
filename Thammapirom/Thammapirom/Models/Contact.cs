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
        [Display(Name = "ผู้ติดต่อ")]
        public string Sender { get; set; }    
        [Display(Name = "อีเมลล์ผู้ติดต่อ")]
        public string SenderEmail { get; set; }
        [Display(Name = "ชื่อเรื่องติดต่อ")]
        public string ContactTitle { get; set; }
        [Display(Name = "ข้อความ")]
        public string ContactMessage { get; set; }   
    }
}