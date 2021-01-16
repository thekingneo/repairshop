using System.Collections.Generic;
namespace RepairShop.Shared.Models
{
    public class CustomerData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TvBrand { get; set; }
        public int TvInch { get; set; }
        public IEnumerable<TvCheckIn> TvCheckIns { get; set; }

    }
}