using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.ImageCommand
{
    public class DeleteImageCommand : ICommand<bool>
    {
        public Guid ImageId { get; set; }
        public class DeleteImageHandler : ICommandHandler<DeleteImageCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ImageService _imageService;
            public DeleteImageHandler(IUnitOfWork unitOfWork,ImageService imageService)
            {
                _unitOfWork = unitOfWork;
                _imageService = imageService;
            }

            public async Task<bool> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var image = await _unitOfWork.Images.GetById(request.ImageId);
                    if (image == null) throw new Exception("Image is not exist");
                    var result = await _imageService.DeleteImageAsync(image.PublicId);
                    if (result.Result != "ok") throw new Exception("Delete image failed");
                    await _unitOfWork.Images.Delete(image);
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(true);
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
