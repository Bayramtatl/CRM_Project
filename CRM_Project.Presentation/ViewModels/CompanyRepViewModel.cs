using CRM_Project.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CRM_Project.Presentation.ViewModels
{
  public class CompanyRepViewModel
  {
    public int CompanyId { get; set; }
    public List<SelectListItem> Companies { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true)]
    public DateTime FirstDate { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true)]
    public DateTime LastDate { get; set; }

  }
}
