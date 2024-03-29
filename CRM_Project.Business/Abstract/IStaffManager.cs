﻿using CRM_Project.Core.Entities;

namespace CRM_Project.Business.Abstract
{
  public interface IStaffManager
  {
    public Staff LoginCheck(Staff model);
    public List<Staff> GetStaffList();
    public Staff GetById(int id);
  }
}
