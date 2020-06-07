using System.IO;
using DocManager.Services.XML;

namespace DocManager.ViewModel
{
    public class ObjectDataProvider
    {
        public static ObjectDataViewModel GetObjectData()
        {
            var startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,"abc.xml");

            var objectData = new ObjectDataViewModel(XmlReader.ReadObjectInfo(startupPath));

            return objectData;
        }
    }
}