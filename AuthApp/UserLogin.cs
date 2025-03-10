﻿using System.ComponentModel.DataAnnotations;

namespace appmvc.AuthApp
{
    public class UserLogin
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember this user?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
