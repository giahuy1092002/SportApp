using AutoMapper;
using SportApp_Business.Commands.ImageCommand;
using SportApp_Business.Commands.SportEquipmentCommand;
using SportApp_Business.Commands.SportFieldCommand;
using SportApp_Business.Commands.TimeSlotCommand;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Commands.VoucherCommand;
using SportApp_Business.Dtos.RatingDtos;
using SportApp_Business.Dtos.SportEquipmentDtos;
using SportApp_Business.Dtos.SportFieldDtos;
using SportApp_Business.Dtos.TimeSlotDtos;
using SportApp_Business.Dtos.UserDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Dto.VoucherDto;
using SportApp_Infrastructure.Model.ImageModel;
using SportApp_Infrastructure.Model.RatingModel;
using SportApp_Infrastructure.Model.SportEquipmentModel;
using SportApp_Infrastructure.Model.SportFieldModel;
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
            // SportField
            CreateMap<SportField, SportFieldDto>()
                .ForMember(dst => dst.Type, src => src.MapFrom(src => src.FieldType.Name))
                .ForMember(dst => dst.Vouchers, src => src.MapFrom(src => src.Owner.Vouchers))
                .ForMember(dst => dst.Ratings, src => src.MapFrom(src => src.Ratings))
                .ForMember(dst => dst.SportEquipments, src => src.MapFrom(src => src.Owner.SportEquipment))
                ;
            CreateMap<SportField, SportFieldListDto>()
                .ForMember(dst => dst.NumberOfReviews, src => src.MapFrom(src => src.Ratings.Count))
                .ForMember(dst => dst.MinPrice, src => src.MapFrom(src => src.TimeSlots.Min(t => t.Price)))
                .ForMember(dst => dst.MaxPrice, src => src.MapFrom(src => src.TimeSlots.Max(t => t.Price)))
                .ForMember(dst => dst.PictureUrl, src => src.MapFrom(src => src.Images[0].PictureUrl))
                ;

            // Image
            CreateMap<CreateImageCommand, CreateImageModel>();

            // Timeslot
            CreateMap<CreateTimeSlotCommand, CreateTimeSlotModel>();
            // Rating
            CreateMap<AddRatingSportFieldCommand,CreateRatingModel>();
            CreateMap<Rating, RatingDto>()
                .ForMember(dst => dst.CustomerName, src => src.MapFrom(src => src.Customer.User.FirstName + " " + src.Customer.User.LastName));
            // SportEquipment
            CreateMap<CreateSportEquipmentCommand, CreateSportEquipmentModel>();
            CreateMap<SportEquipment, SportEquipmentDto>();
            // Voucher
            CreateMap<CreateVoucherCommand, CreateVoucherModel>();
            CreateMap<Voucher, VoucherDto>();
            CreateMap<UpdateVoucherCommand, UpdateVoucherModel>();
        }
    }
}
