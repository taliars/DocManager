using DocManager.Core;
using System.IO;

namespace DocManager.Data.DataProviders
{
    // TODO: Rework this class
    public abstract class DataProviderBase
    {
        private readonly string folderPath;

        protected string objectDataPath;

        protected string devicePath;

        protected string WorkingFolderPath(string docName) => Path.Combine(folderPath, docName);

        public OrderData OrderData { get; protected set; }

        protected DataProviderBase()
        {
            folderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
