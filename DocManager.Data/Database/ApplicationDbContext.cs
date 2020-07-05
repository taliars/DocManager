using DocManager.Core;
using Microsoft.EntityFrameworkCore;

namespace DocManager.Data.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Act> Acts { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<WeatherDay> WeatherDays { get; set; }
        public DbSet<ObjectData> ObjectDatas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options){ }
    }
}
