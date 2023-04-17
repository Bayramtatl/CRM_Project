using CRM_Project.Core.Entities;

namespace CRM_Project.DataAccess.Abstract
{
    public interface IServiceRepository
    {
    public Service Add(Service model);
    public Service Update(Service model);
    public void Delete(int id);
    public List<Service> GetAll();
    public Service GetById(int id);
    public void Activate(int id);
    public void Deactivate(int id);

  }
}
