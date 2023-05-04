using CRM_Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Project.Business.Abstract
{
  public interface IMailServiceManager
  {
    void SendEmail(MailRequest mailRequest);
  }
}
