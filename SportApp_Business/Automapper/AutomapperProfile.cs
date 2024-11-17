using AutoMapper;
using SportApp_Business.Commands.CustomerCommand;
using SportApp_Business.Commands.ImageCommand;
using SportApp_Business.Commands.NotificationCommand;
using SportApp_Business.Commands.SportFieldCommand;
using SportApp_Business.Commands.SportTeamCommand;
using SportApp_Business.Commands.TimeSlotCommand;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Commands.VoucherCommand;
using SportApp_Business.Dtos.BookingDtos;
using SportApp_Business.Dtos.CategoryDtos;
using SportApp_Business.Dtos.CustomerDtos;
using SportApp_Business.Dtos.NotificationDtos;
using SportApp_Business.Dtos.OwnerDtos;
using SportApp_Business.Dtos.RatingDtos;
using SportApp_Business.Dtos.SpecDtos;
using SportApp_Business.Dtos.SportDtos;
using SportApp_Business.Dtos.SportEquipmentDtos;
using SportApp_Business.Dtos.SportFieldDtos;
using SportApp_Business.Dtos.SportProductDtos;
using SportApp_Business.Dtos.SportTeamDtos;
using SportApp_Business.Dtos.TimeSlotDtos;
using SportApp_Business.Dtos.UserDtos;
using SportApp_Business.Dtos.VoucherDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Dto.VoucherDto;
using SportApp_Infrastructure.Model.CustomerModel;
using SportApp_Infrastructure.Model.ImageModel;
using SportApp_Infrastructure.Model.NotificationModel;
using SportApp_Infrastructure.Model.RatingModel;
using SportApp_Infrastructure.Model.SportFieldModel;
using SportApp_Infrastructure.Model.SportTeamModel;
using SportApp_Infrastructure.Model.TimeSlotModel;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Model.VoucherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserLoginDto>();
            CreateMap<User, UserDto>();
            CreateMap<TimeSlot, TimeSlotDto>();
            CreateMap<UpdateUserCommand, UpdateUserModel>();
            CreateMap<UpdateGeoCommand, UpdateGeoModel>();
            // SportField
            CreateMap<SportField, SportFieldDto>()
                .ForMember(dst => dst.Type, src => src.MapFrom(src => src.FieldType.Name))
                .ForMember(dst => dst.Vouchers, src => src.MapFrom(src => src.Owner.Vouchers))
                .ForMember(dst => dst.Ratings, src => src.MapFrom(src => src.Ratings))
                .ForMember(dst => dst.PriceRange, src => src.MapFrom(src =>
                src.TimeSlots.Min(t => t.Price).ToString() + "đ" + "-" +
                src.TimeSlots.Max(t => t.Price).ToString() + "đ"))
                ;
            CreateMap<SportField, SportFieldListDto>()
                .ForMember(dst => dst.NumberOfReviews, src => src.MapFrom(src => src.Ratings.Count))
                .ForMember(dst => dst.PriceRange, src => src.MapFrom(src => 
                src.TimeSlots.Min(t => t.Price).ToString()+"đ" + "-"+
                src.TimeSlots.Max(t => t.Price).ToString() +"đ"))
                .ForMember(dst => dst.PictureUrl, src => src.MapFrom(src => src.Images[0].PictureUrl));
            CreateMap<SportField, SportFieldsOwner>()
                .ForMember(dst => dst.NumberOfReviews, src => src.MapFrom(src => src.Ratings.Count))
                .ForMember(dst => dst.PriceRange, src => src.MapFrom(src =>
                src.TimeSlots.Min(t => t.Price).ToString() + "đ" + "-" +
                src.TimeSlots.Max(t => t.Price).ToString() + "đ"))
                .ForMember(dst => dst.PictureUrl, src => src.MapFrom(src => src.Images[0].PictureUrl));
            CreateMap<UpdateSportFieldCommand, UpdateSportFieldModel>();

            // Image
            CreateMap<CreateImageCommand, CreateImageModel>();

            // Timeslot
            CreateMap<CreateTimeSlotCommand, CreateTimeSlotModel>();
            // Rating
            CreateMap<AddRatingSportFieldCommand,CreateRatingModel>();
            CreateMap<Rating, RatingDto>()
                .ForMember(dst => dst.CustomerName, src => src.MapFrom(src => src.Customer.User.FirstName + " " + src.Customer.User.LastName))
                .ForMember(dst => dst.Avatar, src => src.MapFrom(src => src.Customer.User.Avatar));
            ;
            #region Voucher
            CreateMap<CreateVoucherCommand, CreateVoucherModel>();
            CreateMap<Voucher, VoucherDto>();
            CreateMap<UpdateVoucherCommand, UpdateVoucherModel>();
            CreateMap<Voucher, VoucherDtoList>();
            #endregion

            #region Notification
            CreateMap<UserNotification, UserNotificationDto>()
                .ForMember(dst => dst.Title, src => src.MapFrom(src => src.Notification.Title))
                .ForMember(dst => dst.Content, src => src.MapFrom(src => src.Notification.Content))
                .ForMember(dst => dst.CreatAt, src => src.MapFrom(src => src.Notification.CreateAt))
                .ForMember(dst => dst.RelatedType, src => src.MapFrom(src => src.Notification.RelatedType))
                ;
            CreateMap<CreateNotificationCommand, CreateNotificationModel>();
            #endregion

            #region Customer
            CreateMap<Customer,CustomerDto>()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Gender, src => src.MapFrom(src => src.User.Gender))
                .ForMember(dst => dst.DateOfBirth, src => src.MapFrom(src => src.User.DateOfBirth))
                .ForMember(dst => dst.Email, src => src.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.Avatar, src => src.MapFrom(src => src.User.Avatar))
                ;
            CreateMap<Customer, CustomerDtoDetail>();
                ;
            CreateMap<UpdateCustomer, UpdateCustomerModel>();
            #endregion
            #region Owner
            CreateMap<Owner, OwnerDto>()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Gender, src => src.MapFrom(src => src.User.Gender))
                .ForMember(dst => dst.DateOfBirth, src => src.MapFrom(src => src.User.DateOfBirth))
                .ForMember(dst => dst.Email, src => src.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.RegistrationDate, src => src.MapFrom(src => src.User.RegistrationDate))
                ;
            #endregion
            #region Spec
            CreateMap<Spec, SpecDto>()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Gender, src => src.MapFrom(src => src.User.Gender))
                .ForMember(dst => dst.DateOfBirth, src => src.MapFrom(src => src.User.DateOfBirth))
                .ForMember(dst => dst.Email, src => src.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.RegistrationDate, src => src.MapFrom(src => src.User.RegistrationDate))
                ;
            #endregion
            #region SportTeam
            CreateMap<CreateSportTeamCommand, CreateSportTeamModel>();
            CreateMap<UpdateSportTeamCommand,UpdateSportTeamModel>();
            CreateMap<SportTeam, SportTeamDto>();
            CreateMap<UserSportTeam, SportTeamDto>()
                .ForMember(dst => dst.Name, src => src.MapFrom(src => src.SportTeam.Name))
                .ForMember(dst => dst.Address, src => src.MapFrom(src => src.SportTeam.Address))
                .ForMember(dst => dst.CurrentMember, src => src.MapFrom(src => src.SportTeam.CurrentMember))
                .ForMember(dst => dst.LimitMember, src => src.MapFrom(src => src.SportTeam.LimitMember))
                .ForMember(dst => dst.Sport, src => src.MapFrom(src => src.SportTeam.Sport))
                .ForMember(dst => dst.Endpoint, src => src.MapFrom(src => src.SportTeam.Endpoint))
                .ForMember(dst => dst.Avatar, src => src.MapFrom(src => src.SportTeam.Avatar))
                .ForMember(dst => dst.Id, src => src.MapFrom(src => src.SportTeam.Id));
                ;
            CreateMap<SportTeam, SportTeamDetail>();
            CreateMap<UserSportTeam, MemberDto>()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.Customer.User.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.Customer.User.LastName))
                .ForMember(dst => dst.Role, src => src.MapFrom(src => src.Role.ToString()))
                .ForMember(dst => dst.JoinDate, src => src.MapFrom(src => src.JoinDate))
                .ForMember(dst => dst.CustomerId, src => src.MapFrom(src => src.CustomerId))
                .ForMember(dst => dst.SportTeamId, src => src.MapFrom(src => src.SportTeamId));
            CreateMap<UserSportTeam, RequestSportTeam>()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.Customer.User.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.Customer.User.LastName))
                .ForMember(dst => dst.Avatar, src => src.MapFrom(src => src.Customer.User.Avatar))
                .ForMember(dst => dst.CustomerId, src => src.MapFrom(src => src.CustomerId));

            #endregion
            #region Sport,Category,SubCategory
            CreateMap<Sport, SportDto>();
            CreateMap<Category,CategoryDto>();
            #endregion
            #region Booking
            CreateMap<Booking, BookingDto>()
                .ForMember(dst => dst.SportFieldName, src => src.MapFrom(src => src.SportField.Name))
                .ForMember(dst => dst.Address, src => src.MapFrom(src => src.SportField.Address))
                .ForMember(dst => dst.BookingDate, src => src.MapFrom(src => src.BookingDate))
                .ForMember(dst => dst.TotalPrice, src => src.MapFrom(src => src.TotalPrice))
                .ForMember(dst => dst.Status, src => src.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.TimeSlotBooked, opt => opt.Ignore()) 
                .AfterMap((src, dst) =>
                {
                dst.TimeSlotBooked = src.TimeFrameBooked?.Split(';');
                });
            #endregion
            #region Size
            CreateMap<Size, SizeDto>();
            #endregion

        }
    }
}
