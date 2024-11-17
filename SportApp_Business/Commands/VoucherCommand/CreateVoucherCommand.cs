using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.VoucherModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.VoucherCommand
{
    public class CreateVoucherCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Quantity { get; set; }
        public Guid? OwnerId { get; set; } = Guid.Empty;
        public long MinPrice { get; set; }
        public int PercentSale { get; set; }
        public long MaxSale { get; set; }
        public class CreateVoucherHandler : ICommandHandler<CreateVoucherCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CreateVoucherHandler(IUnitOfWork unitOfWork,SportAppDbContext context,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<bool> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var voucher = _mapper.Map<CreateVoucherModel>(request);
                    var result = await _unitOfWork.Vouchers.Create(voucher);
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
