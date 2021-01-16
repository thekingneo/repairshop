using System;

namespace RepairShop.Shared.DTOs
{
    public class DisplayTvCheckInDto
    {
        public DateTime DateIn { get; set; }
        public string Failure { get; set; }
        public bool Returned { get; set; }
    }
    
}