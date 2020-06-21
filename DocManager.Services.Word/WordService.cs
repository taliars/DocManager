using DocManager.Core;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;

namespace DocManager.Services
{
    public enum TemplateType
    {
        Noise,
        NoiseRailway,
        NoiseAvia,
        Emi,
        Radiation,
        Infrasound,
        Vibration,
    }

    public static class WordService
    {
        private static readonly string commonPath = @"D:\m\DocManager\норд\формы протоколов\";

        private static readonly string finalPath = @"D:\m\DocManager\норд\final\";

        private static readonly Dictionary<string, string> templateProtocolPaths = new Dictionary<string, string>
        {
            ["шум"] = "шум.docx",
            ["шум авиа"] = @"шум авиа.docx",
            ["шум жд"] = @"шум жд.docx",
            ["эми"] = @"эми.docx",
            ["радиация"] = @"радиация.docx",
            ["инфразвук"] = @"инфразвук.docx",
            ["вибрация"] = @"вибрация.docx",
        };

        public static void WriteWord(OrderData orderData, Document document, string type)
        {
            var wordApp = new Word.Application();
            string templateFilePath = $"{commonPath}{templateProtocolPaths[type.ToLower()]}";

            // TODO:  Try
            var wordDoc = wordApp.Documents.Open(templateFilePath);
            var objectData = orderData.ObjectData;

            string finalFilePath = $"{finalPath}{Protocol.GetName(type.ToLower(), objectData.Order)}";
            document.Path = $"{finalFilePath}.docx";

            wordDoc.Variables[nameof(Document.Name)].Value = document.Name;
            wordDoc.Variables[nameof(Document.Date)].Value = document.Date.Value.ToShortDateString();
            wordDoc.Variables[nameof(ObjectData.ObjectName)].Value = objectData.ObjectName.GetOrEmpty();
            wordDoc.Variables[nameof(ObjectData.ObjectAddress)].Value = objectData.ObjectAddress.GetOrEmpty();
            wordDoc.Variables[nameof(ObjectData.CustomerName)].Value = objectData.CustomerName.GetOrEmpty();
            wordDoc.Variables[nameof(ObjectData.CustomerAddress)].Value = objectData.CustomerAddress.GetOrEmpty();
            wordDoc.Variables[nameof(ObjectData.Purpose)].Value = objectData.Purpose.GetOrEmpty();
            wordDoc.Variables[nameof(ObjectData.Order)].Value = objectData.Order.GetOrEmpty();

            wordDoc.Fields.Update();

            wordDoc.SaveAs2(finalFilePath);

            wordDoc.Close();
            wordApp.Quit();
        }

        private static string GetOrEmpty(this string input)
             => string.IsNullOrEmpty(input) ? " " : input;

    }
}