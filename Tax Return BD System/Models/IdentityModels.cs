using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Tax_Return_BD_System.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       

        public string UserType { get; internal set; }        
        public string FirstName { get; internal set; }
        public string MiddleName { get; internal set; }
        public string LastName { get; internal set; }
        public string Status { get; internal set; }
        public int UserId { get; internal set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
          
            
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("TaxDBContext")
        {
        }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.LoginInformation> LoginInformations { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.RoleInformation> RoleInformations { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.UserProfile> UserProfiles { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.UserDocument> UserDocuments { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.MenuItem> MenuItems { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.SubMenuItem > SubMenuItems { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.UserRole> UserRoles { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.FileDetail> FileDetails { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.RegistrationInformation> RegistrationInformations { get; set; }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}