using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.SportFieldModel;
using SportApp_Infrastructure.Model.TimeSlotModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportFieldCommand
{
    public class UpdateSportFieldCommand : ICommand<bool>
    {
        public Guid SportFieldId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Sport {  get; set; }
        public string Prices { get; set; }

        public class UpdateSportFieldHandler : ICommandHandler<UpdateSportFieldCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly SportAppDbContext _context;
            public UpdateSportFieldHandler(IUnitOfWork unitOfWork,IMapper mapper,SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _context = context;
            }

            public async Task<bool> Handle(UpdateSportFieldCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var model = _mapper.Map<UpdateSportFieldModel>(request);
                    var prices = JsonConvert.DeserializeObject<List<TimeFramePrice>>(request.Prices);
                    var timeslots = await _context.TimeSlot
                    .Where(t => t.SportFieldId == request.SportFieldId).ToListAsync();
                    foreach( var timeslot in timeslots)
                    {
                       _context.TimeSlot.Remove(timeslot);
                    }
                    await _context.SaveChangesAsync();

                    foreach (var timePrice in prices)
                    {
                        var start = int.Parse(timePrice.StartTime.Split(':')[0]);
                        var end = int.Parse(timePrice.EndTime.Split(':')[0]);
                        string minute = timePrice.StartTime.Split(':')[1];

                        for (var i = start; i < end; i++)
                        {
                            var obj = new CreateTimeSlotModel
                            {
                                StartTime = i.ToString() + ":" + minute,
                                EndTime = (i + 1).ToString() + ":" + minute,
                                SportFieldId = request.SportFieldId,
                                Price = timePrice.Price
                            };
                            await _unitOfWork.TimeSlots.Create(obj);
                        }
                    }
                    var result = await _unitOfWork.SportFields.Update(model);
                    _unitOfWork.CommitTransaction();
                    return result;
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
