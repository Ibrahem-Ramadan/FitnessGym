using Microsoft.AspNetCore.Identity;
using FitnessGym.Data;
using FitnessGym.Models;

namespace FitnessGym.Seeds
{
    public static class Seeding
    {
        public static async Task SeedAdminUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManger)
        {
            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@fitness-gym.com",
                FullName = "Admin",
                Gender = 'M',
                EmailConfirmed = true

            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);

            if (user == null)
            {
               
                if(userManager.CreateAsync(adminUser, "Admin=123").Result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManger)
        {
            if (!roleManger.Roles.Any())
            {
                await roleManger.CreateAsync(new IdentityRole("Admin"));
                await roleManger.CreateAsync(new IdentityRole("Trainee"));
            }
        }
        public static async Task SeedProgramsAsync(ApplicationDbContext dbContext)
        {
            if (!dbContext.Programs.Any())
            {
                await dbContext.Programs.AddAsync(new Programs(){ProgramName= "Basic Fitness"});
                await dbContext.Programs.AddAsync(new Programs(){ProgramName= "Advanced Muscle Course" });
                await dbContext.Programs.AddAsync(new Programs(){ProgramName= "New Gym Training" });
                await dbContext.Programs.AddAsync(new Programs(){ProgramName= "Yoga Training" });
                await dbContext.Programs.AddAsync(new Programs(){ProgramName= "Basic Muscle Course" });
                await dbContext.Programs.AddAsync(new Programs(){ProgramName= "Body Building Course" });

                await dbContext.SaveChangesAsync();

            }
        }
        public static async Task SeedSubscriptionsAsync(ApplicationDbContext dbContext)
        {
            if (!dbContext.Subscriptions.Any())
            {
                await dbContext.Subscriptions.AddAsync(new Subscription() { Type = "Monthly", Fees = 100 });
                await dbContext.Subscriptions.AddAsync(new Subscription() { Type="3-Month" , Fees=250});
                await dbContext.Subscriptions.AddAsync(new Subscription() { Type ="6-Month", Fees = 450 });
                await dbContext.Subscriptions.AddAsync(new Subscription() { Type = "12-Month", Fees = 850 });

                await dbContext.SaveChangesAsync();
           
            }
        }
    }
}
