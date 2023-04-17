using CRM_Project.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM_Project.DataAccess
{
  public class DataContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer("Data Source=DESKTOP-J7P6K06; Database=CrmDB;Trusted_Connection=True;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Staff>().HasData(
          new Staff
          {
            Id = 1,
            Name = "Bayram",
            Surname = "Tatlı",
            Role = 0,
            Email = "b@b.com",
            Password = "123",
            UpdatedDate = DateTime.Now
          },
          new Staff
          {
            Id = 2,
            Name = "Firma",
            Surname = "Talebi",
            Role = 0,
            Email = "b@c.com",
            Password = "123",
            UpdatedDate = DateTime.Now
          }
      );
      modelBuilder.Entity<Company>().HasData(
        new Company
        {
          Id = 1,
          CompanyName = "Kablonet",
          Email = "k@k.com",
          Password = "123",
          UpdatedDate = DateTime.Now
        }
    );
      modelBuilder.Entity<Service>().HasData(
          new Service
          {
            Id = 1,
            ServiceStatus = 0,
            Request = "Deneme için destek talebi",
            CompanyId = 1,

            UpdatedDate = DateTime.Now
          }
      );
    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceStep> ServiceSteps { get; set; }
    public DbSet<Staff> Staffs { get; set; }

  }
}
