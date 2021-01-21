using System;

namespace RepairShop.Shared.DTOs
{
    public class AddCheckInToCustomerDto
    {
        public int CustomerDataId { get; set; }
        public DateTime DateIn { get; set; }
        public string Failure { get; set; }
        public bool Returned { get; set; }
    }
}