using CRM_Project.Core.Entities;

namespace CRM_Project.DataAccess.Abstract
{
  public interface IStaffRepository
  {
    public Staff Add(Staff model);
    public Staff Update(Staff model);
    public void Delete(int id);
    public List<Staff> GetAll();
    public Staff GetById(int id);
    public Staff LoginCheck(Staff model);
  }
}
