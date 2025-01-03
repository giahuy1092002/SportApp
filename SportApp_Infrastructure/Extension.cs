﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportApp_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Repositories;
using SportApp_Infrastructure.Services;
using SportApp_Infrastructure.Services.Interfaces;
using Service;


namespace SportApp_Infrastructure
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<SportAppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            })
                .AddDbContextFactory<SportAppDbContext>(lifetime: ServiceLifetime.Scoped);
            services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<SportAppDbContext>()
            .AddDefaultTokenProviders();
            services.AddDataProtection();
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISeedRepository, SeedRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IFieldTypeRepository, FieldTypeRepository>();
            services.AddTransient<ISportFieldRepository, SportFieldRepository>();
            services.AddTransient<ITimeSlotRepository, TimeSlotRepository>();
            services.AddTransient<ISpecRepository, SpecRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IVoucherRepository, VoucherRepository>();
            services.AddTransient<IBookingTimeSlotRepository, BookingTimeSlotRepository>();
            services.AddTransient<INotificationRepository,NotificationRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<ISportRepository,SportRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISportProductRepository, SportProductRepository>();
            services.AddTransient<ISportProductVariantRepository,SportProductVariantRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<MailService>();
            services.AddTransient<IVnPayService,VnPayService>();
            services.AddHostedService<NotifyReminderService>();
            services.AddHostedService<UpdateBookingStatusService>();
            services.AddHostedService<BookingStatusService>();
            return services;
        }
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<SportAppDbContext>()
            .AddDefaultTokenProviders();
            services.AddDataProtection();
            return services;
        }
    }
}
