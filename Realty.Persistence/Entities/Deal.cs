
using System;

namespace RealtyManagementSystem.Persistence.Entities
{
    public class Deal : RealtyBaseEntity
    {
        public Guid PropertyId { get; set; }
        public Guid ClientId { get; set; }
        public Guid RealtorId { get; set; } 

        public DateTime DateOpened { get; set; } = DateTime.Now;
        public DateTime? DateClosed { get; set; }

        public string Status { get; set; } = "Draft"; 

        public decimal FinalPrice { get; set; }
        public decimal CommissionAmount { get; set; }
    }
}