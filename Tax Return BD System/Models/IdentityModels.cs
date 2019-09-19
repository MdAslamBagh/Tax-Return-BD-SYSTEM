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
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TaxDBContext", throwIfV1Schema: false)
        {
        }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.LoginInformation> LoginInformations { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.RoleInformation> RoleInformations { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.RegistrationInformation> RegistrationInformations { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.UserProfile> UserProfiles { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.UserDocument> UserDocuments { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.MenuItem> MenuItems { get; set; }
        public System.Data.Entity.DbSet<Tax_Return_BD_System.Models.SubMenuItem > SubMenuItems { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}