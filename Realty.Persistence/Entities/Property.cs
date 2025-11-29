
using System;

namespace RealtyManagementSystem.Persistence.Entities
{
    public class Property : RealtyBaseEntity
    {
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string PropertyType { get; set; } 
        public double Area { get; set; } 
        public string Status { get; set; } = "Available"; 

        
        public string District { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
        public Guid? AssignedRealtorId { get; set; } 
    }
}