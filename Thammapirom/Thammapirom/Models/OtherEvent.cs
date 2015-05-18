using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thammapirom.Models
{
    public class OtherEvent : Event
    {
        [Display(Name = "จุดประสงค์กิจกรรม")]
        public string EventPurpose { get; set; }   
    }
}