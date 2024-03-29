﻿using System;

namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Manufacturer = new Manufacturer();
            MeasurementUnit = new MeasurementUnit();
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
        public int QuantityAtWarehouse { get; set; }

    }
}
