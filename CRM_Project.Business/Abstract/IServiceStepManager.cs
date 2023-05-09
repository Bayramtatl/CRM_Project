using CRM_Project.Core.Entities;

namespace CRM_Project.Business.Abstract
{
  public interface IServiceStepManager
  {
    public void CreateServiceStepByAdmin(ServiceStep s);
    public List<ServiceStep> GetByServiceId(int id);
    public ServiceStep RateIt(int id, int point);
    public int GetServiceId(int id);
    public List<ServiceStep> GetServiceStepsByStaffAndDate(DateTime d1, DateTime d2,int StaffId);
  }
}
