
using System;

namespace RealtyManagementSystem.Persistence.Entities
{
    public abstract class RealtyBaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}