
using System;
using System.Collections.Generic;

namespace RealtyManagementSystem.BusinessLogic.Services
{
    public interface IReportingService
    {
        decimal CalculateRevenueByPeriod(DateTime startDate, DateTime endDate);
        int CountDealsByPeriod(DateTime startDate, DateTime endDate);
        Dictionary<string, TimeSpan> CalculateAvgSaleTimeByDistrict();
        Dictionary<string, int> GetDistrictDealCount(DateTime startDate, DateTime endDate);
    }
}