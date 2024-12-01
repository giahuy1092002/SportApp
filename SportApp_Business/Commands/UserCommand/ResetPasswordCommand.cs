using Microsoft.AspNetCore.WebUtilities;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.UserCommand
{
    public class ResetPasswordCommand : ICommand<bool>
    {
        public string Email { get; set; }
        public string DecodedToken { get; set; }
        public string Password { set; get; }
        public class ResetPasswordHandler : ICommandHandler<ResetPasswordCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public ResetPasswordHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
            {
                var decodedBytes = WebEncoders.Base64UrlDecode(request.DecodedToken);
                var decodedToken = Encoding.UTF8.GetString(decodedBytes);
                var model = new ResetPasswordModel
                {
                    Email = request.Email,
                    Token = decodedToken,
                    Password = request.Password
                };
                return await _unitOfWork.Users.ResetPassword(model);
            }
        }
    }
}
