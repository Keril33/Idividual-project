
using RealtyManagementSystem.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealtyManagementSystem.BusinessLogic.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IDealService _dealService;
        private readonly IPropertyService _propertyService;

        
        public ReportingService(IDealService dealService, IPropertyService propertyService)
        {
            _dealService = dealService;
            _propertyService = propertyService;
        }

        private IEnumerable<Deal> GetSuccessfulDeals(DateTime startDate, DateTime endDate)
        {
            return _dealService.GetAllDeals()
                .Where(d => d.Status == "Success" &&
                            d.DateClosed.HasValue &&
                            d.DateClosed.Value.Date >= startDate.Date &&
                            d.DateClosed.Value.Date <= endDate.Date);
        }

        
        public decimal CalculateRevenueByPeriod(DateTime startDate, DateTime endDate)
        {
            return GetSuccessfulDeals(startDate, endDate).Sum(d => d.CommissionAmount);
        }

        public int CountDealsByPeriod(DateTime startDate, DateTime endDate)
        {
            return GetSuccessfulDeals(startDate, endDate).Count();
        }

        
        public Dictionary<string, TimeSpan> CalculateAvgSaleTimeByDistrict()
        {
            var deals = _dealService.GetAllDeals().Where(d => d.Status == "Success").ToList();
            var properties = _propertyService.GetAllProperties();

            
            var query = deals
                .Join(properties,
                      deal => deal.PropertyId,
                      prop => prop.Id,
                      (deal, prop) => new { prop.District, deal.DateClosed, prop.DateAdded })
                .Where(x => x.DateClosed.HasValue)
                .GroupBy(x => x.District)
                .Select(g => new
                {
                    District = g.Key,
                    AverageTime = TimeSpan.FromSeconds(g.Average(x => (x.DateClosed.Value - x.DateAdded).TotalSeconds))
                })
                .ToDictionary(x => x.District, x => x.AverageTime);

            return query;
        }

        public Dictionary<string, int> GetDistrictDealCount(DateTime startDate, DateTime endDate)
        {
            var deals = GetSuccessfulDeals(startDate, endDate).ToList();
            var properties = _propertyService.GetAllProperties();

            
            return deals
                .Join(properties,
                      deal => deal.PropertyId,
                      prop => prop.Id,
                      (deal, prop) => prop.District)
                .GroupBy(district => district)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}