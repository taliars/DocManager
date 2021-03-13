using DocManager.Core.OrderEntities;
using System.Threading.Tasks;

namespace DocManager.Services.Contract.Interfaces
{
    public interface IOrderService
    {
        public DbOrder Create();

        public void Delele(int id);

        public DbOrder Update(DbOrder dbOrder);

        public Task<DbOrder> GetByIdAsync(int id);
    }
}
