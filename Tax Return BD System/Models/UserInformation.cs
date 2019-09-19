using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tax_Return_BD_System.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phoneno { get; set; }
        public string Password { get; set; }
        public string Confirm_Password {get;set;}

    }
    public class UserDocument
    {
        [Key]

        [Display(Name = "DocumentName")]
        public string DocumentName { get; set; }

    }
}