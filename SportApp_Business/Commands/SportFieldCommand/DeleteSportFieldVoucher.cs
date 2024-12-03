using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportFieldCommand
{
    public class DeleteSportFieldVoucher : ICommand<bool>
    {
        public Guid SportFieldId { get; set; }
        public Guid VoucherId { get; set; }
        public class DeleteSportFieldVoucherHandler : ICommandHandler<DeleteSportFieldVoucher,bool>
        {
            private readonly SportAppDbContext _context;
            public DeleteSportFieldVoucherHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(DeleteSportFieldVoucher request, CancellationToken cancellationToken)
            {
                var sportFieldVoucher = await _context.SportFieldVouchers.FirstOrDefaultAsync(sv=>sv.SportFieldId==request.SportFieldId&& sv.VoucherId==request.VoucherId);
                if (sportFieldVoucher == null) throw new AppException("Voucher của sân không tồn tại");
                _context.SportFieldVouchers.Remove(sportFieldVoucher);
                return await Task.FromResult(true);
            }
        }
    }
}
