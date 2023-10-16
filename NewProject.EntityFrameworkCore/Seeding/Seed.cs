using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VendorView.Domain;
using VendorView.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VendorView.InfrastructureCore.Seeding
{
    public class DataInitialize
    {
        public static async Task Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                await DataMigration(applicationBuilder);

                var context = serviceScope.ServiceProvider.GetService<MainDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // if (!await context.Roles.AnyAsync())
                // {
                //     string[] roles = new string[] { "Admin" };
                //
                //     if (!context.Roles.Any())
                //     {
                //         foreach (string role in roles)
                //         {
                //             if (!context.Roles.Any(r => r.Name == role))
                //             {
                //                 try
                //                 {
                //                     await roleManager.CreateAsync(new IdentityRole(role));
                //                 }
                //                 catch (Exception ex)
                //                 {
                //                     var logger = applicationBuilder.ApplicationServices
                //                         .GetRequiredService<ILogger<DataInitialize>>();
                //                     logger.LogError(ex, ex.Message);
                //                 }
                //             }
                //         }
                //     }
                // }
            }
        }

        public static async Task<List<T>>? ReadData<T>(string fileName)
        {
            var f = @$"JsonEntities\{fileName}.json";
            var isExist = File.Exists(@$"JsonEntities\{fileName}.json");
            if (isExist)
            {
                var fileData = await System.IO.File.ReadAllTextAsync(@"JsonEntities\" + fileName + ".json");
                return JsonSerializer.Deserialize<List<T>>(fileData);
            }
            return null;
        }

        public static async Task<bool> DataMigration(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MainDbContext>();
                try
                {
                    await context.Database.MigrateAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    var logger = applicationBuilder.ApplicationServices.GetRequiredService<ILogger<DataInitialize>>();
                    logger.LogError(ex, "An error occured During Migration");
                    return false;
                }
            }
        }

        public static async Task AddPermissionClaim(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationUser applicationUser, string role, string module)
        {
            var Role = await roleManager.FindByNameAsync(role);
            if (Role != null)
            {
                var allClaims = await roleManager.GetClaimsAsync(Role);
                var allPermissions = Permissions.GeneratePermissionsForModule(module);
                foreach (var permission in allPermissions)
                {
                    if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                    {
                        await roleManager.AddClaimAsync(Role, new Claim("Permission", permission));
                        //await userManager.AddClaimAsync(applicationUser, new Claim("Permission", permission));
                    }
                }
            }
        }
    }
}
