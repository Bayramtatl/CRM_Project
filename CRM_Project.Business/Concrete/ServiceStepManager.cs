using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;
using System.Net.Mail;
using System.Net;

namespace CRM_Project.Business.Concrete
{
    public class ServiceStepManager : IServiceStepManager
    {
        private IServiceStepRepository _stepRepository;
        private IServiceRepository _rep;
        public ServiceStepManager(IServiceStepRepository stepRepository, IServiceRepository rep)
        {
            _stepRepository = stepRepository;
            _rep = rep;
        }
        public void CreateServiceStepByAdmin(ServiceStep s)
        {
            s.UpdatedDate = DateTime.Now;
            var service = _rep.GetById(s.ServiceId);
            service.LastDate = DateTime.Now;
            service.MoneySpent += s.Price;
            _rep.Update(service);
            _stepRepository.Add(s);

        }
        public List<ServiceStep> GetByServiceId(int id)
        {
            List<ServiceStep> ServiceSteps = new List<ServiceStep>();
            var allSteps = _stepRepository.GetAll();
            foreach (var step in allSteps)
            {
                if (step.ServiceId == id)
                {
                    ServiceSteps.Add(step);
                }
            }

            return ServiceSteps;
        }
        public ServiceStep RateIt(int id, int point)
        {
            var serviceStep = _stepRepository.GetById(id);
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
        public List<ServiceStep> GetServiceStepsByStaffAndDate(DateTime d1, DateTime d2, int StaffId)
        {
            List<ServiceStep> serviceSteps = new List<ServiceStep>();
            var allSteps = _stepRepository.GetAll();
            foreach (var step in allSteps)
            {
                if (step.StaffId == StaffId && step.UpdatedDate >= d1 && step.UpdatedDate <= d2)
                {
                    serviceSteps.Add(step);
                }
            }
            return serviceSteps;
        }
        public List<ServiceStep> GetAll()
        {
            return _stepRepository.GetAll();
        }
    }
}
