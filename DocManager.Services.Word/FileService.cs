﻿using System.Diagnostics;
using System.IO;

namespace DocManager.Services
{
    public static class FileService
    {
        private const string FileNotFoundMessage = "Файл перемещен или удален";
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
    }
}
