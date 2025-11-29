
using RealtyManagementSystem.BusinessLogic.Services;
using RealtyManagementSystem.Persistence.Entities; 

class Program
{
    
    private static PropertyService _propertyService = new PropertyService();
    private static DealService _dealService = new DealService(_propertyService);

    
    private static IReportingService _reportingService =
        new ReportingService(_dealService, _propertyService);

    static void Main(string[] args)
    {
        
    }

    
}