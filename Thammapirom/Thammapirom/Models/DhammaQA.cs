using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thammapirom.Models
{
    public class DhammaQA
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int QAID { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "คำถาม")]
        public string Question { get; set; }
        [DataType(DataType.MultilineText)]
       
        [Display(Name = "Dhamma Answer")]
        public string Answer { get; set; }      
    }
}