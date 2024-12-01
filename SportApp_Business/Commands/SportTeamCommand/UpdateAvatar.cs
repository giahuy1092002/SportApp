using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.SportTeamCommand
{
    public class UpdateAvatar : ICommand<bool>
    {
        public Guid SportTeamId { get; set; }
        public IFormFile Avatar { get; set; }
        public class UpdateAvatarHandler:ICommandHandler<UpdateAvatar,bool>
        {
            private readonly ImageService _imageService;
            private readonly SportAppDbContext _context;
            public UpdateAvatarHandler(SportAppDbContext context,ImageService imageService)
            {
                _context = context;
                _imageService = imageService;
            }

            public async Task<bool> Handle(UpdateAvatar request, CancellationToken cancellationToken)
            {
                try
                {
                    var sportTeam = await _context.SportTeam.FirstOrDefaultAsync(s => s.Id == request.SportTeamId);
                    var deleteResult = await _imageService.DeleteImageAsync(sportTeam.PublicId);
                    if (deleteResult.Result != "ok")
                    {
                        throw new AppException("Delete image failed");
                    }
                    var imageResult = await _imageService.AddImageAsync(request.Avatar);
                    sportTeam.PublicId = imageResult.PublicId;
                    sportTeam.Avatar = imageResult.SecureUrl.ToString();
                    _context.SportTeam.Update(sportTeam);
                    await _context.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
                catch
                {
                    throw;
                }
                
            }
        }
    }
}
