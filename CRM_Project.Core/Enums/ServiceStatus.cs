using System.ComponentModel.DataAnnotations;

namespace CRM_Project.Core.Enums
{
  public enum ServiceStatus
  {
    [Display(Name="Yeni Gelen")]
    Yeni_Gelen,
    [Display(Name = "Devam Ediyor")]
    Devam_Eden,
    [Display(Name = "Kapatılmış")]
    Kapatılmış
  }
}
