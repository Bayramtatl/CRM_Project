using CRM_Project.Business.Abstract;
using CRM_Project.Core.Entities;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;

namespace CRM_Project.Business.Concrete
{
  public class MailServiceManager //: IMailServiceManager
  {
    private readonly MailSettings _mailSettings;
    public MailServiceManager(IOptions<MailSettings> mailSettings)
    {
      _mailSettings = mailSettings.Value;
    }
    //public void SendEmail(MailRequest mailRequest)
    //{
    //  var email = new MimeMessage();
    //  email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
    //  email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
    //  email.Subject = mailRequest.Subject;
    //  var builder = new BodyBuilder();
    //  builder.HtmlBody = mailRequest.Body;
    //  email.Body = builder.ToMessageBody();
    //  using var smtp = new SmtpClient();
    //  smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
    //  smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
    //  smtp.Send(email);
    //  smtp.Disconnect(true);
    //}
  }
}
