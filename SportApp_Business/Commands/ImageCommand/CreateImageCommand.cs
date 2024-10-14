using AutoMapper;
using Microsoft.AspNetCore.Http;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.ImageModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.ImageCommand
{
    public class CreateImageCommand : ICommand<bool>
    {
        public Guid SportFieldId { get; set; }
        public IFormFile UploadPicture { get; set; }
        public class CreateImageHandler : ICommandHandler<CreateImageCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly ImageService _imageService;
            public CreateImageHandler(IUnitOfWork unitOfWork,IMapper mapper,ImageService imageService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _imageService = imageService;
            }

            public async Task<bool> Handle(CreateImageCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var imageResult = await _imageService.AddImageAsync(request.UploadPicture);
                    var createImage = new CreateImageModel
                    {
                        PictureUrl = imageResult.SecureUrl.ToString(),
                        PublicId = imageResult.PublicId,
                        SportFieldId = request.SportFieldId,
                    };
                    var result = await _unitOfWork.Images.Add(createImage);
                    return await Task.FromResult(result);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
