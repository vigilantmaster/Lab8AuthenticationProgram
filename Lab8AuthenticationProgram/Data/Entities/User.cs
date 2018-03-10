using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Lab8AuthenticationProgram.Models;

namespace Lab8AuthenticationProgram.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { set; get; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int YearsInSchool { get; set; }
        public int TodoId { get; set; }
        public ICollection<Todo> UserTodo { get; set; }

        //public UserViewModel MapToUserViewModel()
        //{
        //    return new UserViewModel
        //    {
        //        Id = Id,
        //        FirstName = FirstName,
        //        MiddleName = MiddleName,
        //        LastName = LastName,
        //        EmailAddress = EmailAddress,
        //        DOB = DOB,
        //        YearsInSchool = YearsInSchool
        //    };
        //}

        public void CopyToUser(User user)
        {
            user.FirstName = this.FirstName;
            user.MiddleName = this.MiddleName;
            user.LastName = this.LastName;
            user.EmailAddress = this.EmailAddress;
            user.DOB = this.DOB;
            user.YearsInSchool = this.YearsInSchool;
        }
    }
}