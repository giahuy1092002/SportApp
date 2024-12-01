using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using SportApp_Business.Common;
using SportApp_Business.Hubs;
using SportApp_Domain.Entities;
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
            private readonly IHubContext<ImageHub> _hubContext;
            public CreateImageHandler(IUnitOfWork unitOfWork,IMapper mapper,ImageService imageService,IHubContext<ImageHub> hubContext)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _imageService = imageService;
                _hubContext = hubContext;
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
                    var image = await _unitOfWork.Images.Add(createImage);
                    await _hubContext.Clients.All.SendAsync("AddSportFieldImage", image);
                    return await Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
