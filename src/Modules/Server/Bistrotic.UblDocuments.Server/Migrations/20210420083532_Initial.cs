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
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UBLExtensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UBLVersionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomizationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileExecutionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyIndicator = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricingCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAlternativeCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingCostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineCountNumeric = table.Column<int>(type: "int", nullable: false),
                    BuyerReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricingExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentAlternativeExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Key);
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
                    AccountingCostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPurposeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeOfChargeIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Integrations");

            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
