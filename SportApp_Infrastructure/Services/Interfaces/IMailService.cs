using SportApp_Infrastructure.Model.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Services.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendEmail(MailRequest request);
    }
}
