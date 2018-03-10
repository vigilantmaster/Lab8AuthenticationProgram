using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lab8AuthenticationProgram.Data.Entities;

namespace Lab8AuthenticationProgram.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Years in School")]
        public int YearsInSchool { get; set; }
        public User MapToUser()
        {
            return new User
            {
                Id = this.Id,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                EmailAddress = this.EmailAddress,
                DOB = this.DOB,
                YearsInSchool = this.YearsInSchool
            };
        }

       
    }
}