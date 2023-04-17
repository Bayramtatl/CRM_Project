using CRM_Project.Core.Entities;

namespace CRM_Project.DataAccess.Abstract
{
  public interface ICompanyRepository
  {
    public Company Add(Company model);
    public Company Update(Company model);
    public void Delete(int id);
    public List<Company> GetAll();
    public Company GetById(int id);
    public Company LoginCheck(Company model);
  }
}
