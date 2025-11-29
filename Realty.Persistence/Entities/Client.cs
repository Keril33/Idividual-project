
using System;

namespace RealtyManagementSystem.Persistence.Entities
{
    public class Client : RealtyBaseEntity
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
    }
}