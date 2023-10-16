using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using VendorView.Domain.BaseEntities;

namespace VendorView.Domain
{
    public class Vendor: BaseEntity<int>
    {
        public string? FullName { get; set; }
    }
}
