using Microsoft.Identity.Client;
using SportApp_Business.Dtos.RatingDtos;
using SportApp_Business.Dtos.SportEquipmentDtos;
using SportApp_Business.Dtos.TimeSlotDtos;
using SportApp_Business.Dtos.VoucherDtos;
using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportFieldDtos
{
    public class SportFieldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EndPoint { get; set; }
        public string Sport { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string PriceRange { get; set; }
        public decimal Stars { get; set; }
        public decimal RatioAccept {  get; set; }
        public int NumberOfBooking { get; set; }
        public List<Image> Images { get; set; }
        public List<RatingDto> Ratings { get; set; }
        public List<VoucherDto> Vouchers { get; set; }
        public int NumberOfReviews {  get; set; }
        public string OwnerFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Duration { get; set; } = "Chưa xác định";
        public string Distance { get; set; } = "Chưa xác định";
    }
}
