using System.IO;
using DocManager.Core;
using DocManager.Services.XML;

namespace DocManager.ViewModel
{
    public class XmlObjectInfoProvider : IObjectInfoProvider
    {
        public ObjectInfo GetObjectInfo { get; }

        public XmlObjectInfoProvider()
        {
            var startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                "abc.xml");
            GetObjectInfo = XmlReader.ReadObjectInfo(startupPath);
        }
    }
}