using AutoMapper;
using SportApp_Business.Common;
using SportApp_Business.Dtos.UserDtos;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.UserQuery
{
    public class GetUserQuery : IQuery<UserDto>
    {
        public Guid UserId { get; set; }
        public class GetUserHandler : IQueryHandler<GetUserQuery,UserDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;   
            public GetUserHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _unitOfWork.Users.GetById(request.UserId);
                    if (user == null) throw new Exception("User is not exist");
                    var userDto = _mapper.Map<UserDto>(user);
                    return userDto;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
