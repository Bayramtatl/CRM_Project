using AspNetCoreHero.ToastNotification.Abstractions;
using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Project.Presentation.Controllers
{
  public class StaffController : Controller
  {
    private IStaffManager _staffManager;
    INotyfService _toastNotification;
    public StaffController(IStaffManager staffManager, INotyfService toastNotification)
    {
      _staffManager = staffManager;
      _toastNotification = toastNotification;
    }
    [HttpGet]
    public ActionResult StaffLogin()
    {
      return View();
    }

    [HttpPost]
    public ActionResult StaffLogin(Staff s)
    {
      if (s.Email != null && s.Password != null)
      {
        Staff s1 = _staffManager.LoginCheck(s);
        if (s1 != null)
        {
          HttpContext.Session.SetObjectAsJson("Staff", s1);
          return RedirectToAction("NewServices", "Service");
        }
        else
        {
          _toastNotification.Error("Email veya Şifre Hatalı");
          return View();
        }
      }
      else
      {
        _toastNotification.Error("Eksik Bilgi Girdiniz");
        return View();
      }
    }
    [HttpGet]
    public IActionResult List()
    {
      var staffList = _staffManager.GetStaffList();
      return View(staffList);
    }
    public ActionResult Create()
    {
      return View();
    }

    // POST: StaffController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: StaffController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: StaffController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: StaffController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: StaffController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
