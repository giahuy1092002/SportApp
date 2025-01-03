﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.RatingDtos
{
    public class RatingDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string? Comment { get; set; }
        public int NumberOfStar {  get; set; }
        public string Avatar {  get; set; }
    }
}
