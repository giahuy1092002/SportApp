using AutoMapper;
using SportApp_Business.Commands.ImageCommand;
using SportApp_Business.Commands.SportFieldCommand;
using SportApp_Business.Commands.TimeSlotCommand;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Dtos.SportFieldDtos;
using SportApp_Business.Dtos.TimeSlotDtos;
using SportApp_Business.Dtos.UserDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.ImageModel;
using SportApp_Infrastructure.Model.SportFieldModel;
using SportApp_Infrastructure.Model.TimeSlotModel;
using SportApp_Infrastructure.Model.UserModel;
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
                .ForMember(dst => dst.Type, src => src.MapFrom(src => src.FieldType.Name));
           
            // Image
            CreateMap<CreateImageCommand, CreateImageModel>();

            // Timeslot
            CreateMap<CreateTimeSlotCommand, CreateTimeSlotModel>();
        }
    }
}
