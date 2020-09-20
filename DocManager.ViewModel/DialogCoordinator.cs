using System;
using System.Threading.Tasks;
using DocManager.Abstractions;

namespace DocManager.ViewModel
{
    public sealed class DialogCoordinator : IDialogCoordinator
    {
        private static DialogCoordinator _instance;
        private static readonly object Padlock = new object();

        private DialogCoordinator()
        {
        }

        public static DialogCoordinator Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new DialogCoordinator());
                }
            }
        }

        public static void Create(
            Func<string, string, bool, Task<bool>> affirm,
            Func<string, string, Task<string>> input, 
            Func<string, string, string> move)
        {
            Affirm = affirm;
            Input = input;
            Move = move;
        }

        private static Func<string, string, bool, Task<bool>> Affirm { get; set; }
        private static Func<string, string, Task<string>> Input { get; set; }
        private static Func<string, string, string> Move { get; set; }

        Task<string> IDialogCoordinator.Input(string title, string message)
        {
            return Input.Invoke(title, message);
        }

        string IDialogCoordinator.Move(string title, string message)
        {
            return Move.Invoke(title, message);
        }

        Task<bool> IDialogCoordinator.Affirm(string title, string message, bool isAffirmOnly)
        {
            return Affirm.Invoke(title, message, isAffirmOnly);
        }
    }
}
