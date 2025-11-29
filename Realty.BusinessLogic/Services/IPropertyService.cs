
using System;
using System.Collections.Generic;
using RealtyManagementSystem.Persistence.Entities;

namespace RealtyManagementSystem.BusinessLogic.Services
{
    public interface IPropertyService
    {
        void AddProperty(Property property);
        Property GetPropertyById(Guid id);
        List<Property> GetAllProperties();
        void UpdateProperty(Property property);
        void DeleteProperty(Guid id);
    }
}