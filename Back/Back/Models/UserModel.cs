﻿using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public UserIfnoModel UserInfo { get; set; }
    }
}