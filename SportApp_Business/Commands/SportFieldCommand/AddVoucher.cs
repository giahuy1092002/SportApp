using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportFieldCommand
{
    public class AddVoucher : ICommand<bool>
    {
        public Guid SportFieldId { get; set; }
        public List<Guid> VoucherIds { get; set; }
        public class AddVoucherHandler : ICommandHandler<AddVoucher, bool>
        {
            private readonly SportAppDbContext _context;
            private readonly IUnitOfWork _unitOfWork;
            public AddVoucherHandler(SportAppDbContext context, IUnitOfWork unitOfWork)
            {
                _context = context;
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(AddVoucher request, CancellationToken cancellationToken)
            {
                var sportField = await _context.SportField.FirstOrDefaultAsync(s => s.Id == request.SportFieldId);
                if (sportField == null) throw new AppException(ErrorMessage.SportFieldNotExist);
                foreach (var id in request.VoucherIds)
                {
                    var voucher = await _context.Vouchers.FirstOrDefaultAsync(v => v.Id == id);
                    if (voucher == null) throw new AppException(ErrorMessage.VoucherNotExist);
                    var obj = new SportFieldVoucher
                    {
                        SportFieldId = request.SportFieldId,
                        VoucherId = id
                    };
                    _context.SportFieldVouchers.Add(obj);
                    await _unitOfWork.SaveChangesAsync();
                }
                return await Task.FromResult(true);
            }
        }
    }
}
