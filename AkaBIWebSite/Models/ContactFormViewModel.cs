﻿using System.ComponentModel.DataAnnotations;

namespace AkaBIWebSite.Models
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Type a valid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "A message is required.")]
        public string Message { get; set; }
    }
}