using MRL.Model;
using word = Microsoft.Office.Interop.Word;

namespace MRL.Service
{
    public static class Word
    {
        //private static word.Application wordApp;
        //private static word.Document wordDoc;
               

        //public static void WriteWord(ObjectInfo objectinfo)
        //{
        //    wordApp = new word.Application();

        //    string FileName = @"C:\Users\El-Dabaa\Desktop\шаблоны\ш новый шаблон от 24.08.17.docx";
        //    wordDoc = wordApp.Documents.Open(FileName);

        //    wordDoc.Variables["ObjectName"].Value = objectinfo.ObjectName;
        //    wordDoc.Variables["ObjectAddress"].Value = objectinfo.ObjectAddress;
        //    wordDoc.Variables["CustomerName"].Value = objectinfo.CustomerName;
        //    wordDoc.Variables["CustomerAddress"].Value = objectinfo.CustomerAddress;
        //    wordDoc.Variables["Measurement"].Value = objectinfo.Measurement;
        //    wordDoc.Variables["Purpose"].Value = objectinfo.Purpose;
        //    wordDoc.Variables["Order"].Value = objectinfo.Order;

        //    wordDoc.Fields.Update();

        //    wordApp.Visible = true;
        //    wordDoc.Save(); 
        //}
    }
}
