using CRM_Project.Core.Entities;

namespace CRM_Project.Business.Abstract
{
  public interface ICompanyManager
    {
    public Company Register(Company model);
    public Company LoginCheck(Company model);
    public List<Company> GetAll();
    public Company GetById(int id);
    public Company Update(Company c);
    }
}
