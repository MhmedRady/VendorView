using VendorView.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.Application;

public class UsersCountInRole : Entity<string>
{
    public string? RoleName { get; set; }
    public int Count { get; set; } = 0;
}
