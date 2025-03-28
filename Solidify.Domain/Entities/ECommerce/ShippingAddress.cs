﻿using Microsoft.EntityFrameworkCore;

namespace Solidify.Domain.Entities.ECommerce
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
