using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CRM_Project.DataAccess.Concrete
{
  public class StaffRepository : IStaffRepository
  {
    public Staff Add(Staff model)
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
        var staff = GetById(id);
        _dataContext.Staffs.Remove(staff);
        _dataContext.SaveChanges();
      }
    }

    public List<Staff> GetAll()
    {
      using (var _dataContext = new DataContext())
      {
        return _dataContext.Staffs.Include(i=> i.ServiceSteps).ToList();
      }
    }

    public Staff GetById(int id)
    {
      using (var _dataContext = new DataContext())
      {
        Staff staff = _dataContext.Staffs.Find(id);
        return staff;
      }
    }

    public Staff Update(Staff model)
    {
      using (var _dataContext = new DataContext())
      {
        _dataContext.Staffs.Update(model);
        _dataContext.SaveChanges();
        return model;
      }
    }
    public Staff LoginCheck(Staff model)
    {
      using(var _dataContext = new DataContext())
      {
        Staff s =_dataContext.Staffs.FirstOrDefault(i=> i.Email== model.Email && i.Password== model.Password);
        return s;
      }
    }
  }
}
