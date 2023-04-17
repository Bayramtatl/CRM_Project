using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;

namespace CRM_Project.Business.Concrete
{
  public class ServiceManager : IServiceManager
  {
    private IServiceRepository _serviceRepository;
    public ServiceManager(IServiceRepository serviceRepository)
    {
      _serviceRepository = serviceRepository;
    }

    public void CreateService(Service s)
    {
      s.ServiceStatus = Core.Enums.ServiceStatus.Yeni_Gelen;
      s.UpdatedDate = DateTime.Now;
      s.ServiceSteps.Add(new() { Service = s, Description = s.Request, UpdatedDate = DateTime.Now, ServiceType = Core.Enums.ServiceType.Talep,StaffId=2 });
      _serviceRepository.Add(s);
      // Mail gönderimi burada yapılacak.
    }
    public List<Service> GetNewServices()
    {
      List<Service> activeServiceList = new List<Service>();
      var serviceList = _serviceRepository.GetAll().OrderByDescending(i=> i.UpdatedDate);
      foreach(Service s in serviceList)
      {
        if(s.ServiceStatus==Core.Enums.ServiceStatus.Yeni_Gelen)
        {
          activeServiceList.Add(s);
        }
      }
      return activeServiceList;
    }
    public List<Service> GetOngoingServices()
    {
      List<Service> ongoingServiceList = new List<Service>();
      var serviceList = _serviceRepository.GetAll().OrderByDescending(i => i.UpdatedDate);
      foreach (Service s in serviceList)
      {
        if (s.ServiceStatus == Core.Enums.ServiceStatus.Devam_Eden)
        {
          ongoingServiceList.Add(s);
        }
      }
      return ongoingServiceList;
    }
    public List<Service> GetOutgoingServices()
    {
      List<Service> outgoingServiceList = new List<Service>();
      var serviceList = _serviceRepository.GetAll().OrderByDescending(i => i.UpdatedDate);
      foreach (Service s in serviceList)
      {
        if (s.ServiceStatus == Core.Enums.ServiceStatus.Kapatılmış)
        {
          outgoingServiceList.Add(s);
        }
      }
      return outgoingServiceList;
    }
    public void UpdateService(Service s)
    {
      _serviceRepository.Update(s);
    }
    public Service GetById(int id)
    {
      Service service= _serviceRepository.GetById(id);
      return service;
    }
    public void Activate(int id)
    {
      _serviceRepository.Activate(id);
    }
    public void Deactivate(int id)
    {
      _serviceRepository.Deactivate(id);
    }
    public IEnumerable<Service> GetByServiceId(int id)
    {
      var ServiceList = _serviceRepository.GetAll();
      var companyServices = ServiceList.Where(i=> i.CompanyId== id);
      return companyServices;
    }

  }
}
