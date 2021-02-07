using AutoMapper;
using RepairShop.Shared.DTOs;
using RepairShop.Shared.Models;

namespace RepairShop.Server.DataBase
{
    public class DtoAutoMapper : Profile
    {
        public DtoAutoMapper()
        {
            CreateMap<TvCheckOut,TvCheckOutDto>();
            CreateMap<TvCheckIn, TvCheckInDto>();
            CreateMap<CustomerData, CustomerDto>();
        }
    }
}