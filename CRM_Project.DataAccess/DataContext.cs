using CRM_Project.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM_Project.DataAccess
{
  public class DataContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer("Data Source=DESKTOP-F7C98MR\\SQLEXPRESS; Database=CrmDB;Trusted_Connection=True;TrustServerCertificate=True");
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
          },
          new Staff
          {
            Id = 3,
            Name = "Suat",
            Surname = "Bıçakçı",
            Role = Core.Enums.Role.Destek,
            Email = "s@s.com",
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
        },
        new Company
        {
          Id = 2,
          CompanyName = "Uludağ Üniversitesi",
          Email = "u@u.com",
          Password = "123",
          UpdatedDate = DateTime.Now
        }
    );
      modelBuilder.Entity<Service>().HasData(
          new Service
          {
            Id = 1,
            ServiceStatus = Core.Enums.ServiceStatus.Devam_Eden,
            Request = "Deneme için destek talebi",
            CompanyId = 1,
            MoneySpent= 6100,
            LastDate= DateTime.Now,
            UpdatedDate = DateTime.MinValue
          }
      );
      modelBuilder.Entity<ServiceStep>().HasData(
          new ServiceStep
          {
            Id = 1,
            ServiceId = 1,
            ServiceType = Core.Enums.ServiceType.Talep,
            StaffId = 2,
            Point = 0,
            Price= 0,
            Description = "Sunucularımızda ısınma sorunu var.",
            UpdatedDate = DateTime.Now
          }
      );
      modelBuilder.Entity<ServiceStep>().HasData(
          new ServiceStep
          {
            Id = 2,
            ServiceId = 1,
            ServiceType = Core.Enums.ServiceType.Uzaktan,
            StaffId = 1,
            Point = 4,
            Price = 100,
            Description = "Sunuculara yazılım güncellemesi yapıldı.",
            UpdatedDate = DateTime.Now
          },
          new ServiceStep
          {
            Id = 3,
            ServiceId = 1,
            ServiceType = Core.Enums.ServiceType.Yerinde,
            StaffId = 3,
            Point = 5,
            Price = 6000,
            Description = "Sunucuların işlemcisi değiştirildi.",
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
