using AspNetCoreHero.ToastNotification.Abstractions;
using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Project.Presentation.Controllers
{
  public class CompanyController : Controller
  {
    private readonly INotyfService _toastNotification;
    private ICompanyManager _companyManager;
    public CompanyController(ICompanyManager companyManager, INotyfService toastNotification)
    {
      _toastNotification = toastNotification;
      _companyManager = companyManager;
    }
    [HttpGet]
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(Company c)
    {
      Company c1 = _companyManager.LoginCheck(c);
      if (c1 != null)
      {
        HttpContext.Session.SetObjectAsJson("Company", c1);
        return RedirectToAction("Create", "Service");
      }
      else
      {
        _toastNotification.Error("Hatalı Email veya Şifre");
        return View();
      }
    }

    // GET: Company/Create
    public ActionResult Register()
    {
      return View();
    }

    // POST: Company/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(Company c)
    {
      if (ModelState.IsValid)
      {
        Company c1 = _companyManager.Register(c);
        if (c1 != null)
        {
          _toastNotification.Success("Kayıt Başarılı Giriş Yapabilirsiniz");
          return RedirectToAction("Login");
        }
        else
        {
          _toastNotification.Error("İlgili kayıt zaten var");
          return View();
        }
      }
      else
      {
        _toastNotification.Error("Bilgileri Eksik Girdiniz");
        return View();
      }
    }

    // GET: Company/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Company/Delete/5
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
    public IActionResult List()
    {
      var companies = _companyManager.GetAll();
      return View(companies);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
      var company = _companyManager.GetById(id);
      return View(company);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Company c)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var company = _companyManager.Update(c);
          _toastNotification.Success("Güncelleme Başarılı");
          return View();
        }
        catch
        {
          _toastNotification.Error("Güncelleme Başarısız");
          return View();
        }
      }
      else
      {
        _toastNotification.Error("Eksik veya Hatalı Bilgi Girişi");
        return View();
      }
    }
    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Company c)
    {
      if (ModelState.IsValid)
      {
        Company c1 = _companyManager.Register(c);
        if (c1 != null)
        {
          _toastNotification.Success("Firma kayıt edildi");
          return RedirectToAction("Login");
        }
        else
        {
          _toastNotification.Error("İlgili kayıt zaten var");
          return View();
        }
      }
      else
      {
        _toastNotification.Error("Firma Bilgilerini Eksik Girdiniz");
        return View();
      }
    }

  }
}

