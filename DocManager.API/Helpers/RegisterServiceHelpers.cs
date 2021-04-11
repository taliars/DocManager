using Microsoft.Extensions.DependencyInjection;
using DocManager.Services.Contract.Interfaces;
using DocManager.Services.Implementations;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DocManager.API.Models;
using Microsoft.Extensions.Configuration;

namespace DocManager.API.Helpers
{
    public static class RegisterServiceHelper
    {
        public static void RegisterJwt(
            this IServiceCollection services, 
            IConfigurationSection authOptionsSection)
        {
            services.Configure<AuthOptions>(authOptionsSection);

            // configure jwt authentication
            var authOptions = authOptionsSection.Get<AuthOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = authOptions.SymmetricSecurityKey,
                        ValidateIssuerSigningKey = true,
                    };
                });
        }

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

        public static void RegisterSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "DocManager.API",
                        Version = "v1"
                    });
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please insert JWT with Bearer into field",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });
        }
    }
}
