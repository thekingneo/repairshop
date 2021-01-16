using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShop.Shared.Models;

namespace RepairShop.Server.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CustomerDataEntityConfig().Configure(modelBuilder.Entity<CustomerData>());

            
        }

        public DbSet<CustomerData> CustomerDataT { get; set; }
        public DbSet<TvCheckIn> TvCheckInT { get; set; }
        public DbSet<TvCheckOut> TvCheckOutT { get; set; }
        public DbSet<CashRegister> CashRegisterT { get; set; }
        
        
    }
    
    public class CustomerDataEntityConfig : IEntityTypeConfiguration<CustomerData>
    {
        public void Configure(EntityTypeBuilder<CustomerData> builder)
        {
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.PhoneNumber).IsRequired();
            builder.Property(b => b.TvBrand).IsRequired();
            builder.Property(b => b.TvInch).IsRequired();
            
        }
    }
    
    
    public static class QueriesExtensions
    {
        public static IQueryable<CustomerData> GetAllCustomerTvsAndCheckins( this AppDbContext db )
        {
            // I assume `UserInRoles` is a linking table for a many-to-many relationship:
            return db
                .CustomerDataT
                .Include(uir => uir.TvCheckIns);

        }

    }
}