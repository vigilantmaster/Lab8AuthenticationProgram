﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Lab8AuthenticationProgram.Models
{
    public class TodoViewModel
    {
        [Key] public int Id { get; set; }

        [Required] [Display(Name = "Subject")] public string Subject { get; set; }

        [Required] [Display(Name = "Details")] public string Details { get; set; }

        [Required]
        [Display(Name = "Next Reminder")]
        public DateTime NextReminder { get; set; }

        [Required]
        [Display(Name = "Finished")]
        public bool Finished { get; set; }

        public String UserId { get; set; }

        [Display(Name = "Reminder Alert")] public bool ReminderAlert { get; set; }
    }
}