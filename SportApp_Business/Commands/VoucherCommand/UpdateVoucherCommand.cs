using AutoMapper;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.VoucherModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.VoucherCommand
{
    public class UpdateVoucherCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Quantity { get; set; }
        public long MinPrice { get; set; }
        public int PercentSale { get; set; }
        public long MaxSale { get; set; }
        public Guid VoucherId { get; set; }
        public class UpdateVoucherHandler : ICommandHandler<UpdateVoucherCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateVoucherHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;   
            }

            public async Task<bool> Handle(UpdateVoucherCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction(); 
                    var updateVoucher = _mapper.Map<UpdateVoucherModel>(request);
                    var result = await _unitOfWork.Vouchers.Update(updateVoucher);
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
