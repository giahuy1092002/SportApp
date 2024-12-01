using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.NotificationModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class NotificationRepository : Repository<Notification>,INotificationRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationRepository(SportAppDbContext context,IUnitOfWork unitOfWork):base(context)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(CreateNotificationModel request)
        {
            try
            {
                var utcNow = DateTime.UtcNow;
                var vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                var vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);
                var notification = new Notification
                {
                    Title = request.Title,
                    Content = request.Content,
                    CreateAt = vietnamTime,
                    RelatedId = request.RelatedId,
                    RelatedType = request.RelatedType,
                };
                Entities.Add(notification);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
            
        }
    }
}
