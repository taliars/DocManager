using DocManager.Core.OrderEntities;
using System.Threading.Tasks;

namespace DocManager.Services.Contract.Interfaces
{
    public interface IOrderService
    {
        DbOrder Create();

        void Delele(int id);

        DbOrder Update(DbOrder dbOrder);

        Task<DbOrder> GetByIdAsync(int id);

        Task<string[]> GetAllOrdersNames(int id);
    }
}
