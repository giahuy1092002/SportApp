using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.ImageModel;
using SportApp_Infrastructure.Model.SportTeamModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.SportTeamCommand
{
    public class CreateSportTeamCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public int LimitMember { get; set; }
        public Guid CustomerId { get; set; }
        public IFormFile Avatar { get; set; }
        public class CreateSportTeamHandler : ICommandHandler<CreateSportTeamCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly SportAppDbContext _context;
            private readonly ImageService _imageService;
            private readonly IMapper _mapper;
            public CreateSportTeamHandler(IUnitOfWork unitOfWork,SportAppDbContext context,ImageService imageService,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _context = context;
                _imageService = imageService;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateSportTeamCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var model = _mapper.Map<CreateSportTeamModel>(request);
                    var sportTeam = await _unitOfWork.SportTeams.Create(model);
                    var imageResult = await _imageService.AddImageAsync(request.Avatar);
                    sportTeam.Avatar = imageResult.SecureUrl.ToString();
                    sportTeam.PublicId = imageResult.PublicId;
                    var member = new UserSportTeam
                    {
                        CustomerId = request.CustomerId,
                        SportTeamId = sportTeam.Id,
                        Role = RoleType.Leader,
                        IsAccept = true
                    };
                    sportTeam.CurrentMember = 1;
                    _context.UserSportTeam.Add(member);
                    await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(true);
                }
                catch
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
                
            }
        }
    }
}
