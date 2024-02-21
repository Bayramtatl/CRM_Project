using AspNetCoreHero.ToastNotification.Abstractions;
using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.Core.ReportModels;
using CRM_Project.Presentation.AuthClasses;
using CRM_Project.Presentation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM_Project.Presentation.Controllers
{
    public class ReportController : Controller
    {
        private readonly INotyfService _toastNotification;
        private ICompanyManager _companyManager;
        private IServiceManager _serviceManager;
        private IServiceStepManager _serviceStepManager;
        private IStaffManager _staffManager;
        public ReportController(ICompanyManager companyManager, IServiceManager serviceManager, IServiceStepManager serviceStepManager, IStaffManager staffManager, INotyfService notyfService)
        {
            _companyManager = companyManager;
            _serviceManager = serviceManager;
            _serviceStepManager = serviceStepManager;
            _staffManager = staffManager;
            _toastNotification = notyfService;
        }
        [HttpGet]
        [Auth]
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
        [Auth]
        public IActionResult CompanyReport(CompanyRepViewModel model)
        {
            if (model.LastDate == model.FirstDate)
            {
                _toastNotification.Error("Lütfen tarihleri farklı giriniz");
                return RedirectToAction("CompanyList");
            }
            CompanyReportModel report = new CompanyReportModel();
            report.AmountSpent = 0;
            var services = _serviceManager.GetServicesByCompanyAndDate(model.FirstDate, model.LastDate, model.CompanyId);
            foreach (var service in services)
            {
                report.AmountSpent += service.MoneySpent;
            }
            report.Services.AddRange(services);
            report.Company = _companyManager.GetById(model.CompanyId);

            decimal allSpent = 0;
            var allServices = _serviceManager.GetAll();
            foreach (var service in allServices)
            {
                allSpent += service.MoneySpent;
            }
            ViewBag.TotalSpent = allSpent;
            return View(report);
        }

        [HttpGet]
        [Auth]
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
            var SList = _staffManager.GetStaffList();
            var sNames = new List<string>();
            var sJobs = new List<int>();
            foreach (var s in SList)
            {
                sNames.Add(s.Name);
                sJobs.Add(s.ServiceSteps.Count);
            }
            ViewBag.StaffList = sNames;
            ViewBag.StaffJobs = sJobs;
            return View(viewmodel);
        }
        [HttpPost]
        [Auth]
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
            var allserviceSteps = _serviceStepManager.GetAll();
            report.ServiceSteps.AddRange(serviceSteps);
            report.Staff = _staffManager.GetById(model.StaffId); // Business Katmanına lazım
            decimal allSpent = 0;
            decimal staffSpent = 0;
            double point = 0;
            int flag = 0;
            foreach (var step in allserviceSteps)
            {
                allSpent += step.Price;
            }
            foreach (var step in serviceSteps)
            {
                staffSpent += step.Price;
                if (step.Point != 0)
                {
                    point += step.Point;
                    flag++;
                }
            }
            point = point / flag;
            ViewBag.TotalSpent = allSpent;
            ViewBag.StaffSpent = staffSpent;
            ViewBag.TotalSteps = allserviceSteps.Count;
            ViewBag.AvgPoint = point;
            return View(report);
        }
    }
}
