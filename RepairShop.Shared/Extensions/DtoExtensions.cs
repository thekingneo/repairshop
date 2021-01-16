using System.Linq;
using RepairShop.Shared.DTOs;
using RepairShop.Shared.Models;

namespace RepairShop.Shared.Extensions
{
    public static class DtoExtensions
    {
        public static DisplayTvCheckInDto ToDto( this TvCheckIn tvCheckIn )
        {
            return new DisplayTvCheckInDto()
            {
                Failure = tvCheckIn.Failure,
                DateIn = tvCheckIn.DateIn,
                Returned = tvCheckIn.Returned
            };
        }
        
        public static DisplayCustomerDto ToDto( this CustomerData customerData )
        {
            return new DisplayCustomerDto()
            {
                Name = customerData.Name,
                PhoneNumber = customerData.PhoneNumber,
                TvBrand = customerData.TvBrand,
                TvCheckIns = customerData.TvCheckIns
                    .Select( t => t.ToDto()).ToList(),
                TvInch = customerData.TvInch
                     
            };
        }
    }
}