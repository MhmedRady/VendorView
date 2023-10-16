using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VendorView.Domain;

namespace VendorView.InfrastructureCore;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Vendor> Vendors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // UserConfiguration
        new UserConfiguration().Configure(builder.Entity<ApplicationUser>());
        new VendorConfiguration().Configure(builder.Entity<Vendor>());

        // Relation Metion
        MapperRelationships.MapeRelationships(builder);

        base.OnModelCreating(builder);
    }
}
