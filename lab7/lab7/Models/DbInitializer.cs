using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace lab7.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            IdentityRole r_admin = new IdentityRole { Name = "Administrator" };
            IdentityRole r_employer = new IdentityRole { Name = "Employer" };
            IdentityRole r_guest = new IdentityRole { Name = "Guest" };

            ApplicationUser u_admin = new ApplicationUser { Email = "admin@belstu.by", UserName = "admin@belstu.by" };
            ApplicationUser u_employer = new ApplicationUser { Email = "emp@belstu.by", UserName = "emp@belstu.by" };
            ApplicationUser u_guest = new ApplicationUser { Email = "guest@belstu.by", UserName = "guest@belstu.by" };
            ApplicationUser u_super = new ApplicationUser { Email = "super@belstu.by", UserName = "super@belstu.by" };

            bool b_admin = roleManager.Create(r_admin).Succeeded;
            bool b_employer = roleManager.Create(r_employer).Succeeded;
            bool b_guest = roleManager.Create(r_guest).Succeeded;

            bool bu_admin = userManager.Create(u_admin, "qwe123").Succeeded;
            bool bu_employer = userManager.Create(u_employer, "qwe123").Succeeded;
            bool bu_guest = userManager.Create(u_guest, "qwe123").Succeeded;
            bool bu_super = userManager.Create(u_super, "qwe123").Succeeded;

            if (b_admin && bu_admin)
            {
                userManager.AddToRole(u_admin.Id, r_admin.Name);
            }

            if (b_employer && bu_employer)
            {
                userManager.AddToRole(u_employer.Id, r_employer.Name);
            }

            if (b_guest && bu_guest)
            {
                userManager.AddToRole(u_guest.Id, r_guest.Name);
            }

            if (b_admin && b_guest && b_employer && bu_super)
            {
                userManager.AddToRoles(u_super.Id, r_admin.Name, r_employer.Name, r_guest.Name);
            }

            base.Seed(context);
        }
    }
}