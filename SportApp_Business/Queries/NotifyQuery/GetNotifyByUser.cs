using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.NotificationDtos;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.NotifyQuery
{
    public class GetNotifyByUser : IQuery<ListUserNotitication>
    {
        public Guid UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public class GetNotityByUserHandler : IQueryHandler<GetNotifyByUser, ListUserNotitication>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly SportAppDbContext _context;
            public GetNotityByUserHandler(IUnitOfWork unitOfWork,IMapper mapper, SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;   
                _mapper = mapper;
                _context = context;
            }
            public async Task<ListUserNotitication> Handle(GetNotifyByUser request, CancellationToken cancellationToken)
            {
                var list = await _context.UserNotifications
                    .Include(u => u.Notification)
                    .Where(n => n.UserId == request.UserId)
                    .ToListAsync();
                var listNotRead = await _context.UserNotifications
                    .Include(u => u.Notification)
                    .Where(n => n.UserId == request.UserId && n.IsRead==false)
                    .ToListAsync();
                int count = list.Count;
                foreach (var item in listNotRead)
                {
                    item.IsRead = true;
                    await _unitOfWork.SaveChangesAsync();
                }
                list = list.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();   
                var listNotify =  _mapper.Map<List<UserNotificationDto>>(list);
                return new ListUserNotitication
                {
                    Notifications = listNotify,
                    Count = count
                };
            }
        }
    }
}
