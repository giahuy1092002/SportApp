using SportApp_Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Dto.UserDto;
using SportApp_Infrastructure.Services;
using SportApp_Infrastructure.Model.Mail;

namespace SportApp_Business.Commands.UserCommand
{
    public class SignUpCommand : ICommand<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public class SignUpHandler : ICommandHandler<SignUpCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly MailService _mailService;
            public SignUpHandler(IUnitOfWork unitOfWork,MailService mailService)
            {
                _unitOfWork = unitOfWork;
                _mailService = mailService;
            }
            public async Task<bool> Handle(SignUpCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var signUpRequest = new SignUpRequest
                    {
                        Email = request.Email,
                        Password = request.Password,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        ConfirmPassword = request.ConfirmPassword,
                    };
                    var user = await _unitOfWork.Users.SignUp(signUpRequest);
                    var mail = await _unitOfWork.Users.GetConfirmEmail(request.Email);
                    await SendEmailSignUp(mail.Email, mail.Link);
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception("Sign up failed");
                }
            }
            public async Task<bool> SendEmailSignUp(string email, string token)
            {
                var verifLink = "https://sportappdemo.azurewebsites.net" + token;
                //var body = await _getHtmlBodyRepository.GetBody("verify.html");

                //body = body.Replace("[[verilink]]", verifLink);
                var body = verifLink;
                var confirmationMail = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Verified your email",
                    Body = body
                };
                return await _mailService.SendEmail(confirmationMail);
            }

        }
    }
}
