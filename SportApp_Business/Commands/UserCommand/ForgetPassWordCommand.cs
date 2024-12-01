using SportApp_Business.Common;
using SportApp_Infrastructure.Model.Mail;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SportApp_Business.Commands.UserCommand
{
    public class ForgetPassWordCommand : ICommand<bool>
    {
        public string Email { get; set; }
        public class ForgetPasswordHandler : ICommandHandler<ForgetPassWordCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly MailService _mailService;
            public ForgetPasswordHandler(IUnitOfWork unitOfWork,MailService mailService)
            {
                _unitOfWork = unitOfWork;
                _mailService = mailService;
            }

            public async Task<bool> Handle(ForgetPassWordCommand request, CancellationToken cancellationToken)
            {
                var mail = await _unitOfWork.Users.ForgetPassword(request.Email);
                var requestEmail = new MailRequest();
                requestEmail.ToEmail = request.Email;
                requestEmail.Subject = "ForgetPassword";
                requestEmail.Body = "https://sportappdemo.azurewebsites.net" + mail.Link;
                var result = await _mailService.SendEmail(requestEmail);
                return result;
            }
        }
    }
}
