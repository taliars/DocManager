using System;
using System.Threading.Tasks;

namespace DocManager.Abstractions
{
    public interface IDialogCoordinator
    {
        Func<string, string, bool, Task<bool>> Affirm { get; set; }
        Func<string, string, Task<string>> Input { get; set; }
        Func<string, string, string> Move { get; set; }
    }

}
