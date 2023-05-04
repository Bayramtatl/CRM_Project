using CRM_Project.Core.Enums;
using System.ComponentModel;

namespace CRM_Project.Core.Entities
{
  public class ServiceStep : BaseObject
  {
    [DisplayName("Hizmet Türü")]
    public ServiceType ServiceType { get; set; }
    [DisplayName("Hizmet Açıklama")]
    public string Description { get; set; }
    [DisplayName("Gider")]
    public int Point { get; set; }
    public decimal? Price { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    public int StaffId { get; set; }
    public Staff? Staff { get; set; }

  }
}
