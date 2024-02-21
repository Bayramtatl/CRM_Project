using AspNetCoreHero.ToastNotification.Abstractions;
using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace CRM_Project.Presentation.Controllers
{
  public class ServiceController : Controller
  {
    private readonly INotyfService _toastNotification;
    private IServiceManager _serviceManager;
    public ServiceController(IServiceManager serviceManager, INotyfService toastNotification)
    {
      _toastNotification = toastNotification;
      _serviceManager = serviceManager;
    }
    [HttpGet]
    public IActionResult Create()
    {
      var companySession = HttpContext.Session.GetObjectFromJson<Company>("Company");
      ViewBag.CompanyId = companySession.Id;
      return View();
    }

    [HttpPost]
    public IActionResult Create(Service s)
    {
      if (s.Request != null)
      {
        _serviceManager.CreateService(s);
        _toastNotification.Success("Hizmet Talebi Gönderildi");
        var companySession = HttpContext.Session.GetObjectFromJson<Company>("Company");
        ViewBag.CompanyId = companySession.Id;
        return View();
      }
      else
      {
        _toastNotification.Error("Hizmet Talebi Başarısız");
        var companySession = HttpContext.Session.GetObjectFromJson<Company>("Company");
        ViewBag.CompanyId = companySession.Id;
        return View();
      }
    }
    //[HttpGet]
    //public IActionResult CreateByAdmin()
    //{
    //  ViewData["Companies"] = new SelectList(_context.Companies, "Id", "CompanyName");
    //  return View();
    //}
    //[HttpPost]
    //public IActionResult CreateByAdmin(Service s)
    //{
    //  s.ServiceStatus = "Açık";
    //  s.Date = DateTime.Now;
    //  _context.Services.Add(s);
    //  _context.SaveChanges();
    //  ServiceStep step = new ServiceStep();
    //  step.Service = s;
    //  step.Date = DateTime.Now;
    //  step.Distance = 0;

    //  _context.ServiceSteps.Add(step);
    //  _context.SaveChanges();
    //  return RedirectToAction("ServiceList");
    //}

    //[HttpGet]
    //public IActionResult Update(int id)
    //{
    //  var service = _context.Services.Find(id);
    //  ViewData["Companies"] = new SelectList(_context.Companies, "Id", "CompanyName");
    //  //ViewBag.Companies = _context.Companies;
    //  return View(service);
    //}
    //[HttpPost]
    //public IActionResult Update(Service s)
    //{
    //  _context.Update(s);
    //  _context.SaveChanges();
    //  return RedirectToAction("ServiceList");
    //}

    [HttpGet]
    public IActionResult NewServices()
    {
      var serviceList = _serviceManager.GetNewServices();
            //var services = _context.Services.Where(i => i.ServiceStatus == "Açık").OrderByDescending(i => i.Date).Include(i => i.Company);
            return View(serviceList);
    }
    public IActionResult Details(int id) {
      var s = _serviceManager.GetById(id);
      return View(s);

    }
    public IActionResult OngoingServices()
    {
      var serviceList = _serviceManager.GetOngoingServices();
      return View(serviceList);
    }
    public IActionResult OutgoingServices()
    {
      var serviceList = _serviceManager.GetOutgoingServices();
      return View(serviceList);
    }
    public IActionResult CompletedServices()
    {
      var serviceList = _serviceManager.GetOutgoingServices();
      return View(serviceList);
    }
    public IActionResult ActivateService(int id)
    {
      _serviceManager.Activate(id);
      _toastNotification.Success("Hizmet Tekrar Açıldı");
      return RedirectToAction("OutgoingServices");

    }

    public IActionResult DeactivateService(int id)
    {
      _serviceManager.Deactivate(id);
      _toastNotification.Success("Hizmet Kapatıldı");
      return RedirectToAction("OngoingServices");
    }

    // Müşteri Sayfasından Erişim
    [HttpGet]
    public IActionResult MyOpenServices()
    {
      var companySession = HttpContext.Session.GetObjectFromJson<Company>("Company");
      var serviceList = _serviceManager.GetByServiceId(companySession.Id);
      return View(serviceList);
    }
    [HttpGet]
    public IActionResult Info(int id)
    {
      var s = _serviceManager.GetById(id);
      return View(s);
    }
  }
}
