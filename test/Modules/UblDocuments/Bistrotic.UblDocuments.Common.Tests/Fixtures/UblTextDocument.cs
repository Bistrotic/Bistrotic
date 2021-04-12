namespace Bistrotic.Application.UblDocument.Tests.Fixtures
{
    using System.IO;
    using System.Xml.Linq;

    public static class UblTextDocument
    {
        public static XDocument GetDocument()
            => XDocument.Load("/test/UblDoc.xml");

        public static string GetString()
            => File.ReadAllText("/test/UblDoc.xml");
    }
}