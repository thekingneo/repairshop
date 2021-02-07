using System;

namespace RepairShop.Shared.DTOs
{
    public class TvCheckOutDto
    {
        public DateTime OutDate { get; set; }
        public int FeePaid { get; set; }
        public bool Repaired { get; set; }
    }
}