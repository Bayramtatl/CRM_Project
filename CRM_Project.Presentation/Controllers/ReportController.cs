using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.Core.ReportModels;
using CRM_Project.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM_Project.Presentation.Controllers
{
  public class ReportController : Controller
  {
    private ICompanyManager _companyManager;
    private IServiceManager _serviceManager;
    private IServiceStepManager _serviceStepManager;
    private IStaffManager _staffManager;
    public ReportController(ICompanyManager companyManager, IServiceManager serviceManager, IServiceStepManager serviceStepManager, IStaffManager staffManager)
    {
      _companyManager = companyManager;
      _serviceManager = serviceManager;
      _serviceStepManager = serviceStepManager;
      _staffManager = staffManager;
    }
    [HttpGet]
    public IActionResult CompanyList()
    {
      var viewmodel = new CompanyRepViewModel();
      var a = _companyManager.GetAll();
      viewmodel.Companies = a.Select(i =>
      new SelectListItem()
      {
        Text = i.CompanyName,
        Value = i.Id.ToString()
      }).ToList();
      return View(viewmodel);
    }
    [HttpPost]
    public IActionResult CompanyReport(CompanyRepViewModel model)
    {
      CompanyReportModel report = new CompanyReportModel();
      report.AmountSpent = 0;
      var services= _serviceManager.GetServicesByCompanyAndDate(model.FirstDate, model.LastDate, model.CompanyId);
      foreach(var service in services)
      {
        report.AmountSpent += service.MoneySpent;
      }
      report.Services.AddRange(services);
      report.Company = _companyManager.GetById(model.CompanyId);

      decimal allSpent = 0;
      var allServices = _serviceManager.GetAll();
      foreach (var service in allServices)
      {
        allSpent+= service.MoneySpent;
      }
      ViewBag.TotalSpent = allSpent;
      return View(report);
    }
    [HttpGet]
    public IActionResult StaffList()
    {
      var viewmodel = new StaffRepViewModel();
      var a = _staffManager.GetStaffList();
      viewmodel.Staffs = a.Select(i =>
      new SelectListItem()
      {
        Text = i.FullName,
        Value = i.Id.ToString()
      }).ToList();
      viewmodel.Report = new List<SelectListItem>
      {
        new SelectListItem() { Text = "Haftalık", Value = "0" },
        new SelectListItem() { Text = "Aylık", Value = "1" },
        new SelectListItem() { Text = "Yıllık", Value = "2" }
      };
      return View(viewmodel);
    }
    [HttpPost]
    public IActionResult StaffReport(StaffRepViewModel model)
    {
      StaffReportModel report = new StaffReportModel();
      var serviceSteps = new List<ServiceStep>();
      if (model.ReportType == ReportType.Haftalik)
      {
        serviceSteps = _serviceStepManager.GetServiceStepsByStaffAndDate(DateTime.Now.AddDays(-7), DateTime.Now, model.StaffId);
      }
      else if (model.ReportType == ReportType.Aylik)
      {
        serviceSteps = _serviceStepManager.GetServiceStepsByStaffAndDate(DateTime.Now.AddDays(-30), DateTime.Now, model.StaffId);
      }
      else if (model.ReportType == ReportType.Yillik)
      {
        serviceSteps = _serviceStepManager.GetServiceStepsByStaffAndDate(DateTime.Now.AddDays(-365), DateTime.Now, model.StaffId);
      }

      report.ServiceSteps.AddRange(serviceSteps);
      report.Staff = _staffManager.GetById(model.StaffId); // Business Katmanına lazım
      return View(report);
    }
  }
}
