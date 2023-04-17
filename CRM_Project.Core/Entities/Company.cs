using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_Project.Core.Entities
{
  public class Company : BaseObject
  {
    [DisplayName("Şirket Adı")]
    public string CompanyName { get; set; }
    [DisplayName("Şirket Mail Adresi")]
    public string Email { get; set; }
    [DisplayName("Şirket Şifresi")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DisplayName("Şirket Telefon Numarası")]
    [DataType(DataType.PhoneNumber)]
    public string? Number { get; set; }

  }
}
