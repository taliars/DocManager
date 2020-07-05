using System.Diagnostics;
using System.IO;

namespace DocManager.Services
{
    public static class FileService
    {
        private const string FileNotFoundMessage = "Исходный файл перемещен или удален";
        private const string DirectoryNotFoundMessage = "Конечная папка перемещена или удалена";
        private const string FileAlreadyExists = "Файл с таким именем уже существует в конечной папке";

        public static void OpenWithDefaultApp(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(FileNotFoundMessage);
            }

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                Process.Start($"{filePath}");
            }
        }

        public static void Open(string path)
        {
            var defaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            path = path ?? defaultPath;

        }

        public static void Move(string oldPath, string newPath)
        {
            if (!File.Exists(oldPath))
            {
                throw new FileNotFoundException(FileNotFoundMessage);
            }

            if (File.Exists(newPath))
            {
                throw new IOException(FileAlreadyExists);
            }

            var directoryName = Path.GetDirectoryName(newPath);

            if (!Directory.Exists(directoryName))
            {
                throw new DirectoryNotFoundException(DirectoryNotFoundMessage);
            }

            File.Move(oldPath, newPath);
        }

        public static bool Delete(string path)
        {
            File.Delete(path);
            return true;
        }

        public static string ToFullPath(this string folderPath, string docName)
        {
            return $"{Path.Combine(folderPath, docName)}.json";
        }

        public static string ToFullPath(this string folderPath, int docName)
        {
            return $"{Path.Combine(folderPath, docName.ToString())}.json";
        }
    }
}
