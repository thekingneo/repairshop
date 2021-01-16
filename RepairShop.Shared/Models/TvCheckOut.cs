using System;
namespace RepairShop.Shared.Models
{
    public class TvCheckOut
    {
        public int Id { get; set; }
        public DateTime OutDate { get; set; }
        public int FeePaid { get; set; }
        public bool Repaired { get; set; }
        public int TvCheckInId { get; set; }
        public TvCheckIn TvCheckIn { get; set; }
      

    }
}