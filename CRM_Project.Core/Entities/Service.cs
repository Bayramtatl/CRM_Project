using CRM_Project.Core.Enums;
using System;
using System.ComponentModel;

namespace CRM_Project.Core.Entities
{
  public class Service : BaseObject
  {
    public Service() {

        ServiceSteps = new List<ServiceStep>();
      
    }
    [DisplayName("Servis Durumu")]
    public ServiceStatus ServiceStatus { get; set; }
    [DisplayName("Talep")]
    public string Request { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public ICollection<ServiceStep> ServiceSteps { get; set; }


  }
}