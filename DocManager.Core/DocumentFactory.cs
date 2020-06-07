namespace DocManager.Core
{
    public abstract class DocumentFactory
    {
        public abstract Document CreateDocument();
    }

    public class ProtocolFactory : DocumentFactory
    {
        public override Document CreateDocument() => new Protocol();
    }

    public class ActFactory : DocumentFactory
    {
        public override Document CreateDocument() => new Protocol();
    }
}