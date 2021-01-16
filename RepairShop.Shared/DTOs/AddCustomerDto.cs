using System;

namespace RepairShop.Shared.DTOs
{
    public class AddCustomerDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TvBrand { get; set; }
        public int TvInch { get; set; }
        
        public DateTime DateIn  { get; set; }
        public string Failure { get; set; }
        public bool Returned { get; set; }
    }
}