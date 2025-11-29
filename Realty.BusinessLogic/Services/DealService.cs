
using System;
using System.Collections.Generic;
using System.Linq;
using RealtyManagementSystem.Persistence.Entities;
using RealtyManagementSystem.Persistence.Repositories;

namespace RealtyManagementSystem.BusinessLogic.Services
{
    public class DealService : IDealService
    {
        private readonly JsonFileRepository<Deal> _repository = new JsonFileRepository<Deal>("deals.json");
        private readonly IPropertyService _propertyService;

        public DealService(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        private void SaveAllDeals(List<Deal> deals) => _repository.Save(deals);
        public List<Deal> GetAllDeals() => _repository.Load();

        public void AddDeal(Deal deal)
        {
            var deals = GetAllDeals();
            deals.Add(deal);
            SaveAllDeals(deals);
        }

        public Deal GetDealById(Guid dealId) => GetAllDeals().FirstOrDefault(d => d.Id == dealId);

        public void CloseDeal(Guid dealId, decimal finalPrice, decimal commissionRate)
        {
            var deals = GetAllDeals();
            var deal = deals.FirstOrDefault(d => d.Id == dealId);

            if (deal == null) throw new KeyNotFoundException("Deal not found.");
            if (deal.Status != "Draft") throw new InvalidOperationException("Deal is already closed or canceled.");

            
            deal.FinalPrice = finalPrice;
            deal.CommissionAmount = finalPrice * commissionRate;

            
            deal.Status = "Success";
            deal.DateClosed = DateTime.Now;

            
            var property = _propertyService.GetPropertyById(deal.PropertyId);
            if (property != null)
            {
                property.Status = "Sold";
                _propertyService.UpdateProperty(property);
            }

            SaveAllDeals(deals);
        }
    }
}