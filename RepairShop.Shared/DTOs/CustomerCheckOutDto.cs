using System;

namespace RepairShop.Shared.DTOs
{
    public class CustomerCheckOutDto
    {
        public int CustomerId { get; set; }
        public DateTime OutDate { get; set; }
        public int FeePaid { get; set; }
        public bool Repaired { get; set; }
        public int TvCheckInId { get; set; }
    }
}