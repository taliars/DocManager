using AutoMapper;
using DocManager.Core.OrderEntities;
using DocManager.Entities;

namespace DocManager.API.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DbOrder, Order>();
            CreateMap<DbCustomer, Customer>();
            CreateMap<DbDevice, Device>();
            CreateMap<DbDocument, Document>();
            CreateMap<DbObjectData, ObjectData>();
            CreateMap<DbVerificationInfo, VerificationInfo>();
            CreateMap<DbWeatherDay, WeatherDay>();
        }
    }
}
