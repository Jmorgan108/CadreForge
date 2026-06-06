using CadreForge.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CadreForge.Data
{
    public static class DbInitializer
    {
        public static async Task SeedDataAsync(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await context.Database.EnsureCreatedAsync();

            // -------------------------
            // 1. ROLES
            // -------------------------
            string[] roles = { "Admin", "User", "PowerUser" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // -------------------------
            // 3. MODEL STATUSES
            // -------------------------
            if (!context.ModelStatuses.Any())
            {
                context.ModelStatuses.AddRange(
                    new ModelStatus { Name = "Unbuilt", IsBuiltIn = true },
                    new ModelStatus { Name = "Built", IsBuiltIn = true },
                    new ModelStatus { Name = "Primed", IsBuiltIn = true },
                    new ModelStatus { Name = "Base Coated", IsBuiltIn = true },
                    new ModelStatus { Name = "In Progress", IsBuiltIn = true },
                    new ModelStatus { Name = "Completed", IsBuiltIn = true }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}