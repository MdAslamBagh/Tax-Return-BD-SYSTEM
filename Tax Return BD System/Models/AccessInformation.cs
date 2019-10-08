using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tax_Return_BD_System.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
    public class SubMenuItem
    {
        [Key]
        public int SubMenuId { get; set; }
        public int MenuId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
    public class RoleInformation
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
    public class UserRole
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}