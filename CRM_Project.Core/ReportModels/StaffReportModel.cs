using CRM_Project.Core.Entities;

namespace CRM_Project.Core.ReportModels
{
  public class StaffReportModel
  {
    public StaffReportModel()
    {
      ServiceSteps = new List<ServiceStep>();
    }
    public Staff Staff { get; set; }
    public List<ServiceStep> ServiceSteps { get; set; }
  }
}
