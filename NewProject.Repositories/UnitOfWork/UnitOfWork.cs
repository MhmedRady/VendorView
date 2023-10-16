using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VendorView.InfrastructureCore;

namespace VendorView.Repositories;

public class UnitOfWork: IUnitOfWork, IDisposable
{
    private readonly MainDbContext _context;
    private readonly ILogger _logger;
    public UnitOfWork(MainDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("logs");
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync(); 
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
