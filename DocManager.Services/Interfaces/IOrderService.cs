using DocManager.Domain.Core.OrderEntities;
using System.Threading.Tasks;

namespace DocManager.Services.Interfaces
{
    public interface IOrderService
    {
        public DbOrder Create();

        public void Delele(int id);

        public DbOrder Update(DbOrder dbOrder);

        public Task<DbOrder> GetByIdAsync(int id);
    }
}
