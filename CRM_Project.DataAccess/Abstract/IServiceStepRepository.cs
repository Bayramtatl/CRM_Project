using CRM_Project.Core.Entities;

namespace CRM_Project.DataAccess.Abstract
{
  public interface IServiceStepRepository
  {
    public ServiceStep Add(ServiceStep model);
    public ServiceStep Update(ServiceStep model);
    public void Delete(int id);
    public List<ServiceStep> GetAll();
    public ServiceStep GetById(int id);
  }
}
