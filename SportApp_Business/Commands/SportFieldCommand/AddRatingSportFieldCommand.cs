using AutoMapper;
using SportApp_Business.Common;
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
        public int NumberOfStar { get; set; }
        public string? Comment { get; set; }
        public class AddRatingSportFieldHandler : ICommandHandler<AddRatingSportFieldCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public AddRatingSportFieldHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<bool> Handle(AddRatingSportFieldCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var sportField = await _unitOfWork.SportFields.GetById(request.SportFieldId);
                    if (sportField == null)
                    {
                        throw new Exception("Sport filed is not exist");
                    } 
                    var rating = _mapper.Map<CreateRatingModel>(request);
                    var result = await _unitOfWork.Ratings.Create(rating);
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
