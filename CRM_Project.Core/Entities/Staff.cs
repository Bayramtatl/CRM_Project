using CRM_Project.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Project.Core.Entities
{
  public class Staff : BaseObject
  {
    [DisplayName("İsim")]
    public string Name { get; set; }
    [DisplayName("Soyisim")]
    public string Surname { get; set; }
    [DisplayName("Rol")]
    public Role Role { get; set; }
    [DisplayName("Email")]
    public string Email { get; set; }
    [DisplayName("Şifre")]

    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DisplayName("Performans Puanı")]
    public double? AvgPoint { get; set; }
    public ICollection<ServiceStep> ServiceSteps { get; set; }
    [DisplayName("Ad-Soyad")]
    [NotMapped]
    public string FullName
    {
      get { return $"{Name} {Surname}"; }
    }
  }
}
