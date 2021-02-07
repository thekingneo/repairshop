using System.Linq;
using RepairShop.Shared.DTOs;
using RepairShop.Shared.Models;

namespace RepairShop.Shared.Extensions
{
    public static class DtoExtensions
    {
        public static DisplayCustomerDto ToDto( this CustomerData customerData )
        {
            var tvchickin = customerData.TvCheckIns.FirstOrDefault(x => x.DateIn == customerData.TvCheckIns.Max(t => t.DateIn));
            if (tvchickin != null)
            {
                return new DisplayCustomerDto()
                {
                    Name = customerData.Name,
                    PhoneNumber = customerData.PhoneNumber,
                    TvBrand = customerData.TvBrand,
                    Id = customerData.Id,
                    Failure = tvchickin.Failure,
                    DateIn = tvchickin.DateIn,
                    Returned = tvchickin.Returned,
                    TvInch = customerData.TvInch
                };
            }

            return null;
        }
        
        /*public static DisplayTvCheckInDto ToDto( this TvCheckIn tvCheckIn )
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
        }*/
    }
}