using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.Application;

public class LoginDto
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
