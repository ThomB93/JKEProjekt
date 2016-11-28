using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JKEMVC.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JKEMVC.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Navn")]
        public string FromName { get; set; }

        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required, Display(Name = "Tlf")]
        public string FromTlf { get; set; }

        [Required, Display(Name = "Besked")]
        public string Message { get; set; }
    }
}