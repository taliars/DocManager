using System.IO;

namespace DocManager.Data.DataProviders
{
    // TODO: Rework this class
    public abstract class DataProviderBase
    {
        private readonly string folderPath;

        protected string fullPath;

        protected string WorkingFolderPath(string docName) => Path.Combine(folderPath, docName);

        protected DataProviderBase()
        {
            folderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
