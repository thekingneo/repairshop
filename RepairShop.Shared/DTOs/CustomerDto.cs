using System.Collections.Generic;

namespace RepairShop.Shared.DTOs
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TvBrand { get; set; }
        public int TvInch { get; set; }
        public IEnumerable<TvCheckInDto> TvCheckIns { get; set; }
    }
}