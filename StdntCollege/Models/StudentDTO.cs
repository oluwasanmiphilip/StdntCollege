using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StdntCollege.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace StdntCollege.Models
{
    public class StudentDTO
    {
        [ValidateNever]
        public int Id
        {
            get; set;
        }
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(30)]
        public string StudentName
        {
            get; set;
        }
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string StudentEmail
        {
            get; set;
        }
        [Range(10, 20)]
        public int Age
        {
            get; set;
        }
    
        [Required]
        public string Address
        {
            get; set;
        }
        [DateCheck]
        public DateTime AdmissionDate 
        {
            get; set; 
        }
        [Required]
        public string Password
        {
            get; set;
        }
        [Compare(nameof(Password))]
        [Required(ErrorMessage = "Password do not match")]
        public string ConfirmPassword
        {
            get; set;
        }
    }
}

