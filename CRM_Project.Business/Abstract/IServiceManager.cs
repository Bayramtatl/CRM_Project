using CRM_Project.Core.Entities;

namespace CRM_Project.Business.Abstract
{
  public interface IServiceManager
  {
    public void CreateService(Service s);
    public List<Service> GetNewServices();
    public List<Service> GetOngoingServices();
    public List<Service> GetOutgoingServices();
    public void UpdateService(Service s);
    public Service GetById(int id);
    public void Activate(int id);
    public void Deactivate(int id);
    public IEnumerable<Service> GetByServiceId(int id);
  }
}
