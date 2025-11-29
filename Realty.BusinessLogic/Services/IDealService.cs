
using System;
using System.Collections.Generic;
using RealtyManagementSystem.Persistence.Entities;

namespace RealtyManagementSystem.BusinessLogic.Services
{
    public interface IDealService
    {
        void AddDeal(Deal deal);
        Deal GetDealById(Guid dealId);
        List<Deal> GetAllDeals();
        void CloseDeal(Guid dealId, decimal finalPrice, decimal commissionRate);
    }
}