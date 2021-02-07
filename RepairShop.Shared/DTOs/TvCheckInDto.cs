using System;

namespace RepairShop.Shared.DTOs
{
    public class TvCheckInDto
    {
        public DateTime DateIn { get; set; }
        public string Failure { get; set; }
        public bool Returned { get; set; }

        public TvCheckOutDto TvCheckOut { get; set; }
    }
    
}