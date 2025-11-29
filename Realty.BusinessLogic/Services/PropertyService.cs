
using System;
using System.Collections.Generic;
using System.Linq;
using RealtyManagementSystem.Persistence.Entities;
using RealtyManagementSystem.Persistence.Repositories;

namespace RealtyManagementSystem.BusinessLogic.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly JsonFileRepository<Property> _repository =
            new JsonFileRepository<Property>("properties.json");

        private void SaveAllProperties(List<Property> properties) => _repository.Save(properties);
        public List<Property> GetAllProperties() => _repository.Load();

        public void AddProperty(Property property)
        {
            var properties = GetAllProperties();

            
            if (property.Price <= 0 || string.IsNullOrWhiteSpace(property.Address))
                throw new ArgumentException("Address and Price must be valid.");

            properties.Add(property);
            SaveAllProperties(properties);
        }

        public Property GetPropertyById(Guid id) => GetAllProperties().FirstOrDefault(p => p.Id == id);

        public void UpdateProperty(Property updatedProperty)
        {
            var properties = GetAllProperties();
            var existing = properties.FirstOrDefault(p => p.Id == updatedProperty.Id);

            if (existing == null) throw new KeyNotFoundException($"Property ID {updatedProperty.Id} not found.");

            
            existing.Address = updatedProperty.Address;
            existing.Price = updatedProperty.Price;
            existing.Status = updatedProperty.Status;
            existing.District = updatedProperty.District; 
            

            SaveAllProperties(properties);
        }

        public void DeleteProperty(Guid id)
        {
            var properties = GetAllProperties();
            var propertyToRemove = properties.FirstOrDefault(p => p.Id == id);

            if (propertyToRemove != null)
            {
                properties.Remove(propertyToRemove);
                SaveAllProperties(properties);
            }
        }
    }
}