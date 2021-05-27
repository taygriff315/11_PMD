using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SAT.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Attention dark one, the name field is required")]
        public string Name { get; set; }

        public string Subject { get; set; }
        [Required(ErrorMessage = "Attention dark one, the message is required")]
        [UIHint("MultilineText")] //Creates the input field as a TextArea rather than a textbox
        public string Message { get; set; }
        [Required(ErrorMessage = "Attention dark one, the email address is required")]
        [Display(Name = "Your Email")]
        [EmailAddress(ErrorMessage = "Email address was an improper format")]
        public string EmailAddress { get; set; }
    }
}