namespace Bistrotic.Application.UblDocument.Tests.Fixtures
{
    using System.IO;
    using System.Xml.Linq;

    public static class UblTextDocument
    {
        public static XDocument GetDocument()
            => XDocument.Load("/test/UblDoc.xml");

        public static XDocument GetInvoice2_1ExampleDocument()
            => XDocument.Load("./TestFiles/UBL-Invoice-2.1-Example.xml");

        public static string GetInvoice2_1ExampleString()
                    => File.ReadAllText("./TestFiles/UBL-Invoice-2.1-Example.xml");

        public static XDocument GetInvoice2_1TrivialExampleDocument()
            => XDocument.Load("./TestFiles/UBL-Invoice-2.1-Example-Trivial.xml");

        public static string GetInvoice2_1TrivialExampleString()
                    => File.ReadAllText("./TestFiles/UBL-Invoice-2.1-Example-Trivial.xml");
    }
}