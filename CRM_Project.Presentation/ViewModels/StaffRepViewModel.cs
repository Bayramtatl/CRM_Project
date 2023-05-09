using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM_Project.Presentation.ViewModels
{
  public class StaffRepViewModel
  {
    public int StaffId { get; set; }
    public List<SelectListItem> Staffs { get; set; }

    public ReportType ReportType { get; set; }
    public List<SelectListItem> Report { get; set; }
  }
}
