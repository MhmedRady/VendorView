using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorView.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    public int SaveChanges();
}
