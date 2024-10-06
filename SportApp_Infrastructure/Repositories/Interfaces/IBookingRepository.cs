﻿using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.BookingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<Guid> Create(CreateBookingModel request);
    }
}
