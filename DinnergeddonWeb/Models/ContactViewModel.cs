﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DinnergeddonWeb.Models
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [Display(Name = "Name*")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        //[Required]
        //[Display(Name = "Subject*")]
        //public string Subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Message*")]
        public string Message { get; set; }

    }
}