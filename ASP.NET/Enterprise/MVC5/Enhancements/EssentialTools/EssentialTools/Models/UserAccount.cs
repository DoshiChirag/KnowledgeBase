using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EssentialTools.Models
{
    public class UserAccount 
    { 
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confiorm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your confirm password is does not match password")]
        public string ConfirmPassword { get; set; }


    }

}