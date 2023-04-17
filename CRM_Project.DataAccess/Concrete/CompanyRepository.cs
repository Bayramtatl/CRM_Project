using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CRM_Project.DataAccess.Concrete
{
  public class CompanyRepository : ICompanyRepository
  {

    public Company Add(Company model)
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
        var company = GetById(id);
        _dataContext.Companies.Remove(company);
        _dataContext.SaveChanges();
      }
    }

    public List<Company> GetAll()
    {
      using (var _dataContext = new DataContext())
      {
        return _dataContext.Companies.ToList();
      }
    }

    public Company GetById(int id)
    {
      using (var _dataContext = new DataContext())
      {
        Company company = _dataContext.Companies.Find(id);
        return company;
      }
    }

    public Company Update(Company model)
    {
      using (var _dataContext = new DataContext())
      {
        _dataContext.Companies.Update(model);
        _dataContext.SaveChanges();
        return model;
      }
    }
    public Company LoginCheck(Company model)
    {
      using (var _dataContext = new DataContext())
      {
        Company c = _dataContext.Companies.FirstOrDefault(i => i.Email == model.Email && i.Password == model.Password);
        return c;
      }
    }
  }
}
