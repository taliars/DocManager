using DocManager.Core;
using DocManager.Data.Xml;

namespace DocManager.Data.DataProviders
{
    public class XmlObjectInfoProvider : DataProviderBase, IObjectDataProvider
    {
        public ObjectData ObjectData { get; }

        public XmlObjectInfoProvider()
        {
            ObjectData = XmlReader.ReadObjectInfo(WorkingFolderPath("abc.xml"));
        }

        public void Save(ObjectData objectData)
        {
            throw new System.NotImplementedException();
        }
    }
}
