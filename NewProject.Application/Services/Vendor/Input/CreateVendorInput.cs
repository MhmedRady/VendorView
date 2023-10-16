using VendorView.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.Application;

public class CreateVendorInput
{
    public string FullName { get; set; }
    //public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; }
    //public DateTime? UpdateAt { get; set; }
    public string? UpdatedBy { get; set; }
}
