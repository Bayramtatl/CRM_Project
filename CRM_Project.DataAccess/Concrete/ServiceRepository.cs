using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CRM_Project.DataAccess.Concrete
{
  public class ServiceRepository : IServiceRepository
  {

    public Service Add(Service model)
    {
      using (var _dataContext = new DataContext())
      {
        _dataContext.Add(model);
        _dataContext.SaveChanges();
        return model;
      }
    }

    public void Delete(int id)
    {
      using (var _dataContext = new DataContext())
      {
        var service = GetById(id);
        _dataContext.Services.Remove(service);
        _dataContext.SaveChanges();
      }
    }

    public List<Service> GetAll()
    {
      using (var _dataContext = new DataContext())
      {
        return _dataContext.Services.Include(i => i.Company).ToList();
      }
    }

    public Service GetById(int id)
    {
      using (var _dataContext = new DataContext())
      {
        Service service = _dataContext.Services.Include(i=> i.ServiceSteps).ThenInclude(j=> j.Staff).FirstOrDefault(i=> i.Id==id);
        return service;
      }
    }

    public Service Update(Service model)
    {
      using (var _dataContext = new DataContext())
      {
        _dataContext.Services.Update(model);
        _dataContext.SaveChanges();
        return model;
      }
    }
    public void Activate(int id)
    {
      using (var _dataContext = new DataContext())
      {
        Service s = _dataContext.Services.Find(id);
        s.ServiceStatus = Core.Enums.ServiceStatus.Devam_Eden;
        _dataContext.Update(s);
        _dataContext.SaveChanges();
      }
    }
    public void Deactivate(int id)
    {
      using (var _dataContext = new DataContext())
      {
        Service s = _dataContext.Services.Find(id);
        s.ServiceStatus = Core.Enums.ServiceStatus.Kapatılmış;
        _dataContext.Update(s);
        _dataContext.SaveChanges();
      }
    }

  }
}
