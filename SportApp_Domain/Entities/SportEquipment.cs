﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class SportEquipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sport { get; set; }
        [ForeignKey("OwnerId")]
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public long RentPrice { get; set; }
        public long BuyPrice { get; set; }
        public int QuantityInStock { get; set; }
    }
}
