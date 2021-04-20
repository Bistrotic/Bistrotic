﻿namespace Bistrotic.Application.UblDocument.Tests.Fixtures
{
    using System.IO;
    using System.Xml.Linq;

    public static class UblTextDocument
    {
        public const string Invoice2EmbeddedFile = "./TestFiles/UBL-Invoice-2.1-Example-Embedded.xml";
        public const string Invoice2FromEmbeddedFile = "./TestFiles/UBL-Invoice-2.1-From-Embedded.xml";
        public const string Invoice2File = "./TestFiles/UBL-Invoice-2.1-Example.xml";
        public const string Invoice2TrivialFile = "./TestFiles/UBL-Invoice-2.1-Example-Trivial.xml";
        public static XDocument GetInvoice2_1ExampleDocument()
            => XDocument.Load(Invoice2File);

        public static string GetInvoice2_1ExampleString()
            => File.ReadAllText(Invoice2File);

        public static XDocument GetInvoice2_1TrivialExampleDocument()
            => XDocument.Load(Invoice2TrivialFile);

        public static string GetInvoice2_1TrivialExampleString()
            => File.ReadAllText(Invoice2TrivialFile);
    }
}