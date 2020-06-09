using System.IO;
using DocManager.Core;
using DocManager.Services.XML;

namespace DocManager.ViewModel
{
    internal class XmlObjectInfoProvider : IObjectDataProvider
    {
        public InnerObjectDataViewModel GetObjectData { get; }

        public XmlObjectInfoProvider()
        {
            var startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                "abc.xml");
            GetObjectData = XmlReader.ReadObjectInfo(startupPath).ToInnerObjectDataViewModel();
        }
    }
}