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
        [Display(Name = "Clip Title")]
        public string ClipTitle { get; set; }
        [Display(Name = "Clip Embed Code")]
        public string ClipEmbedCode { get; set; }      
    }
}