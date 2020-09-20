using System.Threading.Tasks;

namespace DocManager.Abstractions
{
    public interface IDialogCoordinator
    {
        Task<string> Input(string title, string message);

        string Move(string title, string message);

        Task<bool> Affirm(string title, string message, bool isAffirmOnly);
    }

}
