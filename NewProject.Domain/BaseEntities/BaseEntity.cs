using VendorView.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.Domain;

public class BaseEntity<TKey>: Entity<TKey>, ICreationalTime
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public string? UpdatedBy { get; set; }
}
