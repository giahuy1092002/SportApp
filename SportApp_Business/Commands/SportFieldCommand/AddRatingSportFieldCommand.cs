using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.RatingModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportFieldCommand
{
    public class AddRatingSportFieldCommand:ICommand<bool>
    {
        public Guid SportFieldId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BookingId { get; set; }
        public int NumberOfStar { get; set; }
        public string? Comment { get; set; }
        public class AddRatingSportFieldHandler : ICommandHandler<AddRatingSportFieldCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly SportAppDbContext _context;
            public AddRatingSportFieldHandler(IUnitOfWork unitOfWork,IMapper mapper,SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _context = context;
            }
            public async Task<bool> Handle(AddRatingSportFieldCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var booking = await _context.Booking.FirstOrDefaultAsync(b=>b.Id==request.BookingId);
                    if (booking == null) throw new AppException("Đơn đặt sân không tồn tại");
                    var sportField = await _unitOfWork.SportFields.GetById(request.SportFieldId);
                    if (sportField == null)
                    {
                        throw new AppException(ErrorMessage.SportFieldNotExist);
                    } 
                    var rating = _mapper.Map<CreateRatingModel>(request);
                    var result = await _unitOfWork.Ratings.Create(rating);
                    booking.IsRating = true;
                    _context.Booking.Update(booking);
                    await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(result);
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
