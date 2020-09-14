using System;

namespace DocManager.Core
{
    public class Document
    {
        public int Id { get; set; }

        public DocumentType Type { get; set; }

        public string Species { get; set; }

        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public string Dates { get; set; }

        public string Perfomer { get; set; }

        public string Path { get; set; }

        public static string GetName(string toLower, string objectDataOrder)
        {
            throw new NotImplementedException();
        }
    }
}