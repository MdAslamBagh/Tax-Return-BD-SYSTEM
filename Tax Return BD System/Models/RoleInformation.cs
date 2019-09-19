using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tax_Return_BD_System.Models
{
    public class RoleInformation
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}