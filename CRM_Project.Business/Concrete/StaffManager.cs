using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using CRM_Project.DataAccess.Abstract;

namespace CRM_Project.Business.Concrete
{
  public class StaffManager : IStaffManager 
  {
    private IStaffRepository _staffRepository;
    public StaffManager(IStaffRepository staffRepository)
    {
      _staffRepository = staffRepository;
    }
    public Staff LoginCheck(Staff model)
    {
      return _staffRepository.LoginCheck(model);
    }
  }
}
