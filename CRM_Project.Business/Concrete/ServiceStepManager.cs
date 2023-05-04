﻿using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;

namespace CRM_Project.Business.Concrete
{
    public class ServiceStepManager : IServiceStepManager
  {
    private IServiceStepRepository _stepRepository;
    public ServiceStepManager(IServiceStepRepository stepRepository)
    {
      _stepRepository = stepRepository;
    }
    public void CreateServiceStepByAdmin(ServiceStep s)
    {
      s.UpdatedDate= DateTime.Now;
     _stepRepository.Add(s);
    }
    public List<ServiceStep> GetByServiceId(int id)
    {
      List<ServiceStep> ServiceSteps = new List<ServiceStep>();
      var allSteps = _stepRepository.GetAll();
      foreach(var step in allSteps)
      {
        if(step.ServiceId == id)
        {
          ServiceSteps.Add(step);
        }
      }
      return ServiceSteps;
    }
    public ServiceStep RateIt(int id, int point)
    {
      var serviceStep= _stepRepository.GetById(id);
      serviceStep.Point = point;
      _stepRepository.Update(serviceStep);
      return serviceStep;
    }
    public int GetServiceId(int id)
    {
      var serviceStep = _stepRepository.GetById(id);
      int serviceId = serviceStep.ServiceId;
      return serviceId;
    }
  }
}