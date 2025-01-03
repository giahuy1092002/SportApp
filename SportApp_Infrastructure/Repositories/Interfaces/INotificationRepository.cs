﻿using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.NotificationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<bool> Create(CreateNotificationModel request);
    }
}
