using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportAppDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly ISeedRepository _seedRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly ISportFieldRepository _sportFieldRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly ISpecRepository _specRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IBookingTimeSlotRepository _bookingTimeSlotRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly ISportRepository _sportRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISportTeamRepository _sportTeamRepository;
        private readonly ISportProductRepository _sportProductRepository;
        private readonly ISportProductVariantRepository _sportProductVariantRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ICartRepository _cartRepository;
        private IDbContextTransaction? _transaction = null;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUrlHelper _urlHelper;
        public UnitOfWork(SportAppDbContext dbContext,UserManager<User> userManager,RoleManager<Role> roleManager,IUrlHelper urlHelper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _urlHelper = urlHelper;
            _userRepository = new UserRepository(_dbContext,_userManager,this,_urlHelper);
            _seedRepository = new SeedRepository(_userManager, _roleManager);
            _ownerRepository = new OwnerRepository(_dbContext,this);
            _fieldTypeRepository = new FieldTypeRepository(_dbContext, this);
            _sportFieldRepository = new SportFieldRepository(_dbContext, this);
            _timeSlotRepository = new TimeSlotRepository(_dbContext, this);
            _specRepository = new SpecRepository(_dbContext, this);
            _bookingRepository = new BookingRepository(_dbContext, this);
            _customerRepository = new CustomerRepository(_dbContext, this);
            _imageRepository = new ImageRepository(_dbContext, this);
            _ratingRepository = new RatingRepository(_dbContext, this);
            _voucherRepository = new VoucherRepository(dbContext, this);
            _bookingTimeSlotRepository = new BookingTimeSlotRepository(this,_dbContext);
            _notificationRepository = new NotificationRepository(_dbContext, this);
            _adminRepository = new AdminRepository(_dbContext, this);
            _sportRepository = new SportRepository(_dbContext,this);
            _categoryRepository = new CategoryRepository(_dbContext,this);
            _sportTeamRepository = new SportTeamRepository(_dbContext, this);
            _sportProductRepository = new SportProductRepository(_dbContext, this);
            _sportProductVariantRepository = new SportProductVariantRepository(_dbContext, this);
            _colorRepository = new ColorRepository(_dbContext, this);
            _cartRepository = new CartRepository(_dbContext, this);
        }
        public IUserRepository Users => new UserRepository(_dbContext, _userManager, this,_urlHelper);

        public ISeedRepository Seeds => new SeedRepository(_userManager,_roleManager);
        public IOwnerRepository Owners => new OwnerRepository(_dbContext,this);
        public IFieldTypeRepository FieldTypes => new FieldTypeRepository(_dbContext,this);
        public ISportFieldRepository SportFields => new SportFieldRepository(_dbContext, this);
        public ITimeSlotRepository TimeSlots => new TimeSlotRepository(_dbContext, this);

        public ISpecRepository Specs => new SpecRepository(_dbContext, this);
        public IBookingRepository Bookings => new BookingRepository(_dbContext, this);
        public ICustomerRepository Customers => new CustomerRepository(_dbContext, this);  
        public IImageRepository Images => new ImageRepository(_dbContext, this);
        public IRatingRepository Ratings => new RatingRepository(_dbContext, this);
        public IVoucherRepository Vouchers => new VoucherRepository(_dbContext, this);

        public IBookingTimeSlotRepository BookingTimeSlots => new BookingTimeSlotRepository(this,_dbContext);
        public INotificationRepository Notifications => new NotificationRepository(_dbContext, this);
        public IAdminRepository Admins => new AdminRepository(_dbContext, this);
        public ISportRepository Sports => new SportRepository(_dbContext,this);
        public ICategoryRepository Categorys => new CategoryRepository(_dbContext, this);
        public ISportTeamRepository SportTeams => new SportTeamRepository(_dbContext, this);
        public ISportProductRepository Products => new SportProductRepository(_dbContext, this);
        public ISportProductVariantRepository ProductVariants => new SportProductVariantRepository(_dbContext, this);
        public IColorRepository Colors => new ColorRepository(_dbContext, this);
        public ICartRepository Carts => new CartRepository(_dbContext, this);
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
