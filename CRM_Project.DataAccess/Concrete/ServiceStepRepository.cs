using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CRM_Project.DataAccess.Concrete
{
  public class ServiceStepRepository : IServiceStepRepository
  {

    public ServiceStep Add(ServiceStep model)
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
        var servicestep = GetById(id);
        _dataContext.ServiceSteps.Remove(servicestep);
        _dataContext.SaveChanges();
      }
    }

    public List<ServiceStep> GetAll()
    {
      using (var _dataContext = new DataContext())
      {
        return _dataContext.ServiceSteps.ToList();
      }
    }

    public ServiceStep GetById(int id)
    {
      using (var _dataContext = new DataContext())
      {
       // ServiceStep serviceStep = _dataContext.ServiceSteps.FirstOrDefault(i=> i.Id == id);
        var serviceStep= _dataContext.ServiceSteps.Include(i => i.Service).ThenInclude(j=> j.Company).FirstOrDefault(i => i.Id == id);
        return serviceStep;
      }
    }

    public ServiceStep Update(ServiceStep model)
    {
      using (var _dataContext = new DataContext())
      {
        _dataContext.ServiceSteps.Update(model);
        _dataContext.SaveChanges();
        return model;
      }
    }
  }
}
