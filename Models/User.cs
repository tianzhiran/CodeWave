﻿using System.ComponentModel.DataAnnotations;

namespace FlixNow.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; } = "Customer"; // Default is "Customer"

    }
}