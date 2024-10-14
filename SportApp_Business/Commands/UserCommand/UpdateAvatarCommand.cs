using Microsoft.AspNetCore.Http;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.UserCommand
{
    public class UpdateAvatarCommand : ICommand<bool>
    {
        public IFormFile AvatarUpdate {  get; set; }
        public Guid UserId { get; set; }
        public class UpdateAvaterHanlder : ICommandHandler<UpdateAvatarCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ImageService _imageService;
            public UpdateAvaterHanlder(IUnitOfWork unitOfWork,ImageService imageService)
            {
                _imageService = imageService;
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(UpdateAvatarCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var user = await _unitOfWork.Users.GetById(request.UserId);
                    if(user==null)
                    {
                        throw new Exception("User is not exist");
                    }    
                    var result = false;
                    if(user.Avatar!=null)
                    {
                        var deleteResult = await _imageService.DeleteImageAsync(user.PublicId);
                        if(deleteResult.Result != "ok")
                        {
                            throw new Exception("Delete image failed");
                        }
                        var imageResult = await _imageService.AddImageAsync(request.AvatarUpdate);
                        user.PublicId = imageResult.PublicId;
                        var updateAvatar = new UpdateAvatarModel
                        {
                            UserId = request.UserId,
                            Avatar = imageResult.SecureUrl.ToString()
                        };
                        result = await _unitOfWork.Users.UpdateAvatar(updateAvatar);
                    }
                    else
                    {
                        var imageResult = await _imageService.AddImageAsync(request.AvatarUpdate);
                        user.PublicId = imageResult.PublicId;
                        var updateAvatar = new UpdateAvatarModel
                        {
                            UserId = request.UserId,
                            Avatar = imageResult.SecureUrl.ToString()
                        };
                        result = await _unitOfWork.Users.UpdateAvatar(updateAvatar);
                    }
                    _unitOfWork.SaveChanges();  
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(result);
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
