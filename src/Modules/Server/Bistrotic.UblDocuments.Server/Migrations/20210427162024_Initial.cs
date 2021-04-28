using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bistrotic.UblDocuments.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    IdentificationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.IdentificationCode);
                });

            migrationBuilder.CreateTable(
                name: "Integrations",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IntegrationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntegrationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrations", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false),
                    UBLVersionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomizationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileExecutionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyIndicator = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InvoiceTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxPointDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DocumentCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAlternativeCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingCostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineCountNumeric = table.Column<int>(type: "int", nullable: false),
                    BuyerReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicePeriod_StartDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InvoicePeriod_EndDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InvoicePeriod_DurationMeasure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoicePeriod_DescriptionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicePeriod_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderReference_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderReference_SalesOrderID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderReference_CopyIndicator = table.Column<bool>(type: "bit", nullable: false),
                    OrderReference_UUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderReference_IssueDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    OrderReference_CustomerReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderReference_OrderTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderReference_Key = table.Column<int>(type: "int", nullable: true),
                    DeliveryTerms_AllowanceCharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTerms_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryTerms_DeliveryLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTerms_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTerms_LossRiskResponsibilityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricingExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentAlternativeExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_LineExtensionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_TaxExclusiveAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_TaxInclusiveAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_AllowanceTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_ChargeTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_PrepaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_PayableRoundingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_PayableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalMonetaryTotal_PayableAlternativeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "DocumentReferences",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopyIndicator = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DocumentTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocaleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment_EmbeddedDocumentBinaryObject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_CharacterSetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_DocumentHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_EncodingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_ExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Attachment_ExternalReference_ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attachment_ExternalReference_FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_FormatCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_HashAlgorithmMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_MimeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment_ExternalReference_URI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidityPeriod_StartDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ValidityPeriod_EndDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ValidityPeriod_DurationMeasure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValidityPeriod_DescriptionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityPeriod_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceKey = table.Column<int>(type: "int", nullable: true),
                    InvoiceKey1 = table.Column<int>(type: "int", nullable: true),
                    InvoiceKey2 = table.Column<int>(type: "int", nullable: true),
                    InvoiceKey3 = table.Column<int>(type: "int", nullable: true),
                    InvoiceKey4 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentReferences", x => x.Key);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceKey",
                        column: x => x.InvoiceKey,
                        principalTable: "Invoices",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceKey1",
                        column: x => x.InvoiceKey1,
                        principalTable: "Invoices",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceKey2",
                        column: x => x.InvoiceKey2,
                        principalTable: "Invoices",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceKey3",
                        column: x => x.InvoiceKey3,
                        principalTable: "Invoices",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceKey4",
                        column: x => x.InvoiceKey4,
                        principalTable: "Invoices",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceKey = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineExtensionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxPointDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AccountingCostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPurposeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeOfChargeIndicator = table.Column<bool>(type: "bit", nullable: false),
                    InvoicePeriod_StartDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InvoicePeriod_EndDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InvoicePeriod_DurationMeasure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoicePeriod_DescriptionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicePeriod_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderLineReference_Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.Key);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoices_InvoiceKey",
                        column: x => x.InvoiceKey,
                        principalTable: "Invoices",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceKey",
                table: "DocumentReferences",
                column: "InvoiceKey");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceKey1",
                table: "DocumentReferences",
                column: "InvoiceKey1");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceKey2",
                table: "DocumentReferences",
                column: "InvoiceKey2");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceKey3",
                table: "DocumentReferences",
                column: "InvoiceKey3");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceKey4",
                table: "DocumentReferences",
                column: "InvoiceKey4");

            migrationBuilder.CreateIndex(
                name: "IX_Integrations_IntegrationDate",
                table: "Integrations",
                column: "IntegrationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Integrations_MessageId",
                table: "Integrations",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Integrations_ReceivedDate",
                table: "Integrations",
                column: "ReceivedDate");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceKey",
                table: "InvoiceLines",
                column: "InvoiceKey");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderReference_Key",
                table: "Invoices",
                column: "OrderReference_Key");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_DocumentReferences_Key",
                table: "Invoices",
                column: "Key",
                principalTable: "DocumentReferences",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_DocumentReferences_OrderReference_Key",
                table: "Invoices",
                column: "OrderReference_Key",
                principalTable: "DocumentReferences",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentReferences_Invoices_InvoiceKey",
                table: "DocumentReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentReferences_Invoices_InvoiceKey1",
                table: "DocumentReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentReferences_Invoices_InvoiceKey2",
                table: "DocumentReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentReferences_Invoices_InvoiceKey3",
                table: "DocumentReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentReferences_Invoices_InvoiceKey4",
                table: "DocumentReferences");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Integrations");

            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "DocumentReferences");
        }
    }
}
