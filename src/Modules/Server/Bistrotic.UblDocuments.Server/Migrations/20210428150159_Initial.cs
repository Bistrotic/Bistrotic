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
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PackSizeNumeric = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CatalogueIndicator = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HazardousRiskIndicator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "BillingReferenceLines",
                columns: table => new
                {
                    BillingReferenceLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingReferenceId = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingReferenceLines", x => x.BillingReferenceLineId);
                });

            migrationBuilder.CreateTable(
                name: "BillingReferences",
                columns: table => new
                {
                    BillingReferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDocumentReferenceDocumentReferenceId = table.Column<int>(type: "int", nullable: true),
                    SelfBilledInvoiceDocumentReferenceDocumentReferenceId = table.Column<int>(type: "int", nullable: true),
                    CreditNoteDocumentReferenceDocumentReferenceId = table.Column<int>(type: "int", nullable: true),
                    SelfBilledCreditNoteDocumentReferenceDocumentReferenceId = table.Column<int>(type: "int", nullable: true),
                    DebitNoteDocumentReferenceDocumentReferenceId = table.Column<int>(type: "int", nullable: true),
                    ReminderDocumentReferenceDocumentReferenceId = table.Column<int>(type: "int", nullable: true),
                    AdditionalDocumentReferenceDocumentReferenceId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingReferences", x => x.BillingReferenceId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    OrderReference_DocumentReferenceId = table.Column<int>(type: "int", nullable: true),
                    DespatchDocumentReferenceDocumentReferenceId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentReferences",
                columns: table => new
                {
                    DocumentReferenceId = table.Column<int>(type: "int", nullable: false)
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
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId1 = table.Column<int>(type: "int", nullable: true),
                    InvoiceId2 = table.Column<int>(type: "int", nullable: true),
                    InvoiceId3 = table.Column<int>(type: "int", nullable: true),
                    InvoiceId4 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentReferences", x => x.DocumentReferenceId);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceId1",
                        column: x => x.InvoiceId1,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceId2",
                        column: x => x.InvoiceId2,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceId3",
                        column: x => x.InvoiceId3,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentReferences_Invoices_InvoiceId4",
                        column: x => x.InvoiceId4,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    InvoiceLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    OrderLineReference_Capacity = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Price_PriceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price_BaseQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price_PriceTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price_PriceType = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price_OrderableUnitFactorRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.InvoiceLineId);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferenceLines_BillingReferenceId",
                table: "BillingReferenceLines",
                column: "BillingReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferences_AdditionalDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "AdditionalDocumentReferenceDocumentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferences_CreditNoteDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "CreditNoteDocumentReferenceDocumentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferences_DebitNoteDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "DebitNoteDocumentReferenceDocumentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferences_InvoiceDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "InvoiceDocumentReferenceDocumentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferences_InvoiceId",
                table: "BillingReferences",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferences_ReminderDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "ReminderDocumentReferenceDocumentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferences_SelfBilledCreditNoteDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "SelfBilledCreditNoteDocumentReferenceDocumentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingReferences_SelfBilledInvoiceDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "SelfBilledInvoiceDocumentReferenceDocumentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceId",
                table: "DocumentReferences",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceId1",
                table: "DocumentReferences",
                column: "InvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceId2",
                table: "DocumentReferences",
                column: "InvoiceId2");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceId3",
                table: "DocumentReferences",
                column: "InvoiceId3");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReferences_InvoiceId4",
                table: "DocumentReferences",
                column: "InvoiceId4");

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
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ItemId",
                table: "InvoiceLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DespatchDocumentReferenceDocumentReferenceId",
                table: "Invoices",
                column: "DespatchDocumentReferenceDocumentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderReference_DocumentReferenceId",
                table: "Invoices",
                column: "OrderReference_DocumentReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferenceLines_BillingReferences_BillingReferenceId",
                table: "BillingReferenceLines",
                column: "BillingReferenceId",
                principalTable: "BillingReferences",
                principalColumn: "BillingReferenceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferences_DocumentReferences_AdditionalDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "AdditionalDocumentReferenceDocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferences_DocumentReferences_CreditNoteDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "CreditNoteDocumentReferenceDocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferences_DocumentReferences_DebitNoteDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "DebitNoteDocumentReferenceDocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferences_DocumentReferences_InvoiceDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "InvoiceDocumentReferenceDocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferences_DocumentReferences_ReminderDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "ReminderDocumentReferenceDocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferences_DocumentReferences_SelfBilledCreditNoteDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "SelfBilledCreditNoteDocumentReferenceDocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferences_DocumentReferences_SelfBilledInvoiceDocumentReferenceDocumentReferenceId",
                table: "BillingReferences",
                column: "SelfBilledInvoiceDocumentReferenceDocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingReferences_Invoices_InvoiceId",
                table: "BillingReferences",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_DocumentReferences_DespatchDocumentReferenceDocumentReferenceId",
                table: "Invoices",
                column: "DespatchDocumentReferenceDocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_DocumentReferences_OrderReference_DocumentReferenceId",
                table: "Invoices",
                column: "OrderReference_DocumentReferenceId",
                principalTable: "DocumentReferences",
                principalColumn: "DocumentReferenceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_DocumentReferences_DespatchDocumentReferenceDocumentReferenceId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_DocumentReferences_OrderReference_DocumentReferenceId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "BillingReferenceLines");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Integrations");

            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "BillingReferences");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "DocumentReferences");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
