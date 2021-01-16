using System;
namespace RepairShop.Shared.Models
{
    public class CashRegister
    {
        public int Id { get; set; }
        public DateTime DateRegistered { get; set; }
        public int Ammount { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }

    }
}