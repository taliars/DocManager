using System.Threading.Tasks;
using DocManager.Core;

namespace DocManager.Abstractions
{
    public interface IActionHelper
    {
        Task UpdatePropertiesFolder(string name);
    }
}
