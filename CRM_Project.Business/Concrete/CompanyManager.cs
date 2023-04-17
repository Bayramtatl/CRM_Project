using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;
using CRM_Project.DataAccess.Concrete;

namespace CRM_Project.Business.Concrete
{
  public class CompanyManager : ICompanyManager
  {
    private ICompanyRepository _companyRepository;
    public CompanyManager(ICompanyRepository companyRepository)
    {
      _companyRepository = companyRepository;
    }
    public Company Register(Company model)
    {
      var CompanyList = _companyRepository.GetAll();
      if (CompanyList.Exists(i => i.CompanyName == model.CompanyName))
      {
        return null;
      }
      else
      {
        _companyRepository.Add(model);
        return model;
      }
    }
    public Company LoginCheck(Company model)
    {
      return _companyRepository.LoginCheck(model);
    }
    public List<Company> GetAll()
    {
      return _companyRepository.GetAll();
    }
    public Company GetById(int id)
    {
      return _companyRepository.GetById(id);
    }
    public Company Update(Company c)
    {
      return _companyRepository.Update(c);
    }
  }
}
