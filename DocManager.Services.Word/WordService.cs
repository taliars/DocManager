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

    public class WordService
    {
        private static readonly string commonPath = @"D:\m\DocManager\норд\формы протоколов\";

        private static readonly string finalPath = @"D:\m\DocManager\норд\final\";

        private static readonly Dictionary<TemplateType, string> templateProtocolPaths = new Dictionary<TemplateType, string>
        {
            [TemplateType.Noise] = "шум.docx",
            [TemplateType.NoiseAvia] = @"шум авиа.docx",
            [TemplateType.Radiation] = @"шум жд.docx",
            [TemplateType.Emi] = @"эми.docx",
            [TemplateType.Radiation] = @"радиация.docx",
            [TemplateType.Infrasound] = @"инфразвук.docx",
            [TemplateType.Vibration] = @"вибрация.docx",
        };

        public static void WriteWord(OrderData orderData, TemplateType template)
        {
            var wordApp = new Word.Application();
            string templateFilePath = $"{commonPath}{templateProtocolPaths[template]}";
            string finalFilePath = $"{finalPath}{templateProtocolPaths[template]}";

            var wordDoc = wordApp.Documents.Open(templateFilePath);
            var objectData = orderData.ObjectData;

            wordDoc.Variables["ObjectName"].Value = objectData.ObjectName;
            wordDoc.Variables["ObjectAddress"].Value = objectData.ObjectAddress;
            wordDoc.Variables["CustomerName"].Value = objectData.CustomerName;
            wordDoc.Variables["CustomerAddress"].Value = objectData.CustomerAddress;
            wordDoc.Variables["Purpose"].Value = objectData.Purpose;
            wordDoc.Variables["Order"].Value = objectData.Order;

            wordDoc.Fields.Update();

            wordDoc.SaveAs2(finalFilePath);

            wordDoc.Close();
            wordApp.Quit();
        }
    }
}