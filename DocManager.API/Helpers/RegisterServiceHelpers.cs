using Microsoft.Extensions.DependencyInjection;
using DocManager.Services.Interfaces;
using DocManager.Services.Implementations;

namespace DocManager.API.Helpers
{
    public static class ServiceHelper
    {
        public static void RegisterScoped(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IObjectDataService, ObjectDataService>();
            services.AddScoped<IVerificationInfoService, VerificationInfoService>();
            services.AddScoped<IWeatherDayService, WeatherDayService>();
        }
    }
}
