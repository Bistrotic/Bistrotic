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
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrations", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Key = table.Column<int>(type: "int", nullable: false),
                    UBLExtensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UBLVersionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomizationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileExecutionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Integrations");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
