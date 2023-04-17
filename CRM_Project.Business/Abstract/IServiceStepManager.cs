using CRM_Project.Core.Entities;

namespace CRM_Project.Business.Abstract
{
  public interface IServiceStepManager
  {
    public void CreateServiceStepByAdmin(ServiceStep s);
    public List<ServiceStep> GetByServiceId(int id);
  }
}
