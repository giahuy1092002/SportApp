using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.ReportRequestCommand
{
    public class CreateRequest:ICommand<bool>
    {
        public string Email { get; set; }
        public string Reason { get; set; }
        public class CreateRequestHandler : ICommandHandler<CreateRequest,bool>
        {
            private readonly SportAppDbContext _context;
            public CreateRequestHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(CreateRequest request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = await _context.Customer
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.User.Email == request.Email);
                    if (customer == null) throw new AppException("Tài khoản không tồn tại");
                    var report = new ReportRequest
                    {
                        Reason = request.Reason,
                        CustomerId = customer.Id
                    };
                    _context.ReportRequest.Add(report);
                    _context.SaveChanges();
                    return await Task.FromResult(true);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
