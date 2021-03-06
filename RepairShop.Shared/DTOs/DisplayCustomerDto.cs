using System;
using System.Collections.Generic;

namespace RepairShop.Shared.DTOs
{
    public class DisplayCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TvBrand { get; set; }
        public int TvInch { get; set; }
        
        public DateTime DateIn { get; set; }
        public string Failure { get; set; }
        public bool Returned { get; set; }
    }
}