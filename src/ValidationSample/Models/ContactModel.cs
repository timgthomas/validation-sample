namespace ValidationSample.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using FluentValidation.Attributes;

    [Validator(typeof(ContactModelValidator))]
    public class ContactModel
    {
        public string Name { get; set; }

        public string Email { get; set; }
        
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}