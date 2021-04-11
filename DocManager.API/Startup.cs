using DocManager.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DocManager.API.Helpers;
using DocManager.API.Models;
using AutoMapper;

namespace DocManager.API
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterJwt(Configuration.GetSection(nameof(AuthOptions)));

            services.AddDbContext<OrderDbContext>(options =>
              options.UseSqlServer(Configuration["ConnectionStrings:DocManagerDbConnection"]));

            var mapperConfig = new MapperConfiguration(
                c => c.AddProfile(new AutoMapperProfile()));
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.RegisterScoped();
            services.AddControllers();
            services.RegisterSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
