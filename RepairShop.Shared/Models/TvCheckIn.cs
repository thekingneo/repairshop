using System;
namespace RepairShop.Shared.Models
{
    public class TvCheckIn
    {
        public int Id { get; set; }
        public int CustomerDataId { get; set; }
        public CustomerData CustomerData { get; set; }

        public DateTime DateIn { get; set; }
        public string Failure { get; set; }
        public bool Returned { get; set; }
        public TvCheckOut TvCheckOut { get; set; }
    }
}