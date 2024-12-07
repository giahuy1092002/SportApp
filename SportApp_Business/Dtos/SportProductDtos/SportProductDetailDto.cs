using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportProductDtos
{
    public class SportProductDetailDto
    {
        public Guid SportProductId { get; set; }
        public string CategoryName { get; set; }
        public string Sport {  get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public List<ImageEndPoint> ImageEndPoints { get; set; }
        public List<SizeDto> Sizes { get; set; }
        public List<SportProductRatingDto> Ratings { get; set; }
    }
    public class ImageEndPoint
    {
        public string PictureUrl { get; set; }
        public string EndPoint { get; set; }
        public bool IsSelected { get; set; }
    }
    public class SizeDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int QuantityInStock { get; set; }
    }
    public class SportProductRatingDto
    {
        public string SportProductVariantName { get; set; }
        public string SizeValue { get; set; }
        public string ColorName { get; set; }
        public int StartRating { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
