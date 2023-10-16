using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.Application;

public class CreateUserInput
{
    public string FullName { get; set; }
    public string? PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string? RoleName { get; set; }
}
