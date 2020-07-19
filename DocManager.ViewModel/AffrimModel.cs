using System;
using System.Threading.Tasks;

namespace DocManager.ViewModel
{
   public class SenderModel
    {
        public Func<string, string, bool, Task<bool>> Action { get; set; }
        public Func<string, string, Task<string>> Input { get; set; }
        public Func<string, string, string> Move { get; set; }
    }
}
