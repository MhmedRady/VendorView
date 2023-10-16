using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendorView.InfrastructureCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.Application
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly MainDbContext _dbContext;
        public PermissionHandler(MainDbContext _DbContext)
        {
            _dbContext = _DbContext;
        }
        // protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        // {
        //     if (context.User == null)
        //         return;
        //
        //     var GetRoles = _dbContext.UserRoles.Where(e => e.UserId == context.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
        //     var Claims = new List<IdentityRoleClaim<string>>();
        //     foreach (var role in GetRoles)
        //     {
        //         Claims.AddRange(_dbContext.RoleClaims.Where(e => e.RoleId == role.RoleId).ToList());
        //     }
        //
        //     if (Claims.Any(e => e.ClaimType == "Permission" && e.ClaimValue == requirement.permission))
        //     {
        //         context.Succeed(requirement);
        //         return;
        //     }
        // }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}
