using AspNetCoreHero.ToastNotification.Abstractions;
using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Project.Presentation.Controllers
{
  public class ServiceStepController : Controller
  {
    private IServiceStepManager _serviceStepManager;
    private IServiceManager _serviceManager;
    private readonly INotyfService _toastNotification;
    public ServiceStepController(IServiceStepManager serviceStepManager, IServiceManager serviceManager, INotyfService toastNotification)
    {
      _serviceStepManager = serviceStepManager;
      _serviceManager = serviceManager;
      _toastNotification = toastNotification;
    }
    [HttpGet]
    public IActionResult CreateByAdmin(int id)
    {
      var service = _serviceManager.GetById(id);
      ViewBag.ServiceId = service.Id;
      return View();
    }
    [HttpPost]
    public IActionResult CreateByAdmin(ServiceStep s)
    {
      if (s.Description != null && s.Price != null)
      {
        var staffSession = HttpContext.Session.GetObjectFromJson<Staff>("Staff");
        //s.Staff = staffSession;
        s.StaffId = staffSession.Id;
        _serviceStepManager.CreateServiceStepByAdmin(s);
        var service = _serviceManager.GetById(s.ServiceId);
        service.ServiceStatus = Core.Enums.ServiceStatus.Devam_Eden;
        _serviceManager.UpdateService(service);
        _toastNotification.Success("Hizmet Adımı Eklendi ✓");
        return RedirectToAction("CreateByAdmin", s.Id);
      }
      else
      {
        _toastNotification.Error("Eksik Bilgi, Adım Başarısız X");
        return RedirectToAction("CreateByAdmin",s.Id);
      }
    }
    public IActionResult List(int id)
    {
      var List = _serviceStepManager.GetByServiceId(id);
      return View(List);
    }

  }
}
