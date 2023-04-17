using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Project.Core.Entities
{
  public class BaseObject
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [DisplayName("Güncelleme Tarihi")]
    [DisplayFormat(ApplyFormatInEditMode = true)]
    public DateTime UpdatedDate { get; set; }

  }
}
