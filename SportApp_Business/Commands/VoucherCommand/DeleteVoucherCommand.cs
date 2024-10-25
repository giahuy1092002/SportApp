using AutoMapper.Execution;
using MimeKit.Encodings;
using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.VoucherCommand
{
    public class DeleteVoucherCommand : ICommand<bool>
    {
        public Guid VoucherId { get; set; }
        public class DeleteVoucherHandler : ICommandHandler<DeleteVoucherCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteVoucherHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteVoucherCommand request, CancellationToken cancellationToken)
            {
                
                try
                {
                    var voucher = await _unitOfWork.Vouchers.GetById(request.VoucherId);
                    if (voucher == null) throw new Exception("Voucher is not exist");
                    await _unitOfWork.Vouchers.Delete(voucher);
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
