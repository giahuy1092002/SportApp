using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.UserQuery
{
    public class GetEmailConfirmQuery : IQuery<bool>
    {
        public string EndcodedToken { get; set; }
        public string Email { get; set; }
        public class GetEmailConfirmHandler : IQueryHandler<GetEmailConfirmQuery, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetEmailConfirmHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(GetEmailConfirmQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await _unitOfWork.Users.ConfirmEmail(request.EndcodedToken, request.Email);
                    return result;
                }
                catch (Exception ex) 
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
