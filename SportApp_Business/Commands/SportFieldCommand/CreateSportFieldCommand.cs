﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.ImageModel;
using SportApp_Infrastructure.Model.SportFieldModel;
using SportApp_Infrastructure.Model.TimeSlotModel;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SportApp_Business.Commands.SportFieldCommand
{
    public class CreateSportFieldCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Guid FieldTypeId { get; set; }
        public Guid OwnerId { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Prices { get; set; }
        public class CreateSportFieldHandler : ICommandHandler<CreateSportFieldCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ImageService _imageService;

            public CreateSportFieldHandler(IUnitOfWork unitOfWork,ImageService imageService)
            {
                _unitOfWork = unitOfWork;
                _imageService = imageService;
            }
            public async Task<bool> Handle(CreateSportFieldCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var owner = await _unitOfWork.Owners.GetById(request.OwnerId);
                    if (owner == null) throw new AppException(ErrorMessage.OwnerNotExist);
                    var fieldType = await _unitOfWork.FieldTypes.GetById(request.FieldTypeId);
                    if (fieldType == null) throw new AppException("Loại sân không tồn tại");
                    var prices = JsonConvert.DeserializeObject<List<TimeFramePrice>>(request.Prices);
                    if (IsTimeSlotOverlap(prices))
                    {
                        throw new AppException("Khung giờ bị trùng nhau");
                    }
                    var sportField = new CreateSportFieldModel
                    {
                        Name = request.Name,
                        Sport = request.Sport,
                        Address = request.Address,
                        Description = request.Description,
                        FieldTypeId = request.FieldTypeId,
                        OwnerId = request.OwnerId
                    };
                    var result = await _unitOfWork.SportFields.Create(sportField);

                    if(result!=null)
                    { 
                        foreach (var timePrice in prices)
                        {
                            var start = int.Parse(timePrice.StartTime.Split(':')[0]);
                            var end = int.Parse(timePrice.EndTime.Split(':')[0]);   
                            string minute = timePrice.StartTime.Split(':')[1];

                            for (var i = start; i < end; i++)
                            {
                                var obj = new CreateTimeSlotModel
                                {
                                    StartTime = i > 9 ? i.ToString()  + ":" + minute : "0" + i.ToString() + ":" + minute,
                                    EndTime = (i + 1) > 9 ? (i + 1).ToString() + ":" + minute : "0" + (i + 1).ToString() + ":" + minute,
                                    SportFieldId = result.Id,
                                    Price = timePrice.Price
                                };
                                await _unitOfWork.TimeSlots.Create(obj);
                            }
                        }
                        for (int i = 0; i < request.Images.Count; i++)
                        {
                            if (request.Images[i] != null)
                            {
                                var imageResult = await _imageService.AddImageAsync(request.Images[0]);
                                var image = new CreateImageModel
                                {
                                    SportFieldId = result.Id,
                                    PictureUrl = imageResult.SecureUrl.ToString(),
                                    PublicId = imageResult.PublicId
                                };
                                await _unitOfWork.Images.Add(image);
                            }
                        }
                    }
                    _unitOfWork.CommitTransaction();
                    return true;
                }
                catch
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }
            private bool IsTimeSlotOverlap(List<TimeFramePrice> prices)
            {
                var sortedPrices = prices.OrderBy(p => DateTime.ParseExact(p.StartTime, "HH:mm", null)).ToList();

                for (int i = 0; i < sortedPrices.Count - 1; i++)
                {
                    var currentStart = DateTime.ParseExact(sortedPrices[i].StartTime, "HH:mm", null);
                    var currentEnd = DateTime.ParseExact(sortedPrices[i].EndTime, "HH:mm", null);

                    var nextStart = DateTime.ParseExact(sortedPrices[i + 1].StartTime, "HH:mm", null);
                    var nextEnd = DateTime.ParseExact(sortedPrices[i + 1].EndTime, "HH:mm", null);
                    if (currentEnd > nextStart)
                    {
                        return true;
                    }
                }
                return false;
            }

        }
    }
}
