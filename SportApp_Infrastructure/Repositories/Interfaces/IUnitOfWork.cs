using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ISeedRepository Seeds { get; }
        IOwnerRepository Owners { get; }
        IFieldTypeRepository FieldTypes { get; }
        ISportFieldRepository SportFields { get; }
        ITimeSlotRepository TimeSlots { get; }
        ISpecRepository Specs { get; }
        IBookingRepository Bookings { get; }
        ICustomerRepository Customers { get; }
        IImageRepository Images { get; }
        IRatingRepository Ratings { get; }
        IVoucherRepository Vouchers { get; }
        IBookingTimeSlotRepository BookingTimeSlots { get; }
        INotificationRepository Notifications { get; }
        IAdminRepository Admins { get; }
        ISportRepository Sports { get; }
        ICategoryRepository Categorys { get; }
        ISportTeamRepository SportTeams { get; }
        ISportProductRepository Products { get; }
        ISportProductVariantRepository ProductVariants { get; }
        IColorRepository Colors { get; }
        ICartRepository Carts { get; }
        void CommitTransaction();
        void RollbackTransaction();
        int SaveChanges();
        void BeginTransaction();

        Task<int> SaveChangesAsync();
    }
}
