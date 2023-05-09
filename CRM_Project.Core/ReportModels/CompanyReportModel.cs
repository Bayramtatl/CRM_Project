using CRM_Project.Core.Entities;

namespace CRM_Project.Core.ReportModels
{
  public class CompanyReportModel
  {
    public CompanyReportModel()
    {
      Services = new List<Service>();
    }
    public Company Company { get; set; }
    public List<Service> Services { get; set; }
    public decimal AmountSpent { get; set; }
  }
}
