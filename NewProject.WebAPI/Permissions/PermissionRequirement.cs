using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.Application;
public class PermissionRequirement : IAuthorizationRequirement
{
    public string permission { get; private set; }

    public PermissionRequirement(string Permission)
    {
        permission = Permission;
    }
}

