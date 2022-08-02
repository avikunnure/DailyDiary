using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SavuDiary.Server.Migrations
{
    public partial class TaxTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RuleName = table.Column<string>(type: "text", nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxType = table.Column<string>(type: "text", nullable: false),
                    Descriptions = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRuleDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxRuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerticularNames = table.Column<string>(type: "text", nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    Descriptions = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRuleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRuleDetails_TaxRules_TaxRuleId",
                        column: x => x.TaxRuleId,
                        principalTable: "TaxRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaxRules",
                columns: new[] { "Id", "Descriptions", "IsActive", "RuleName", "TaxPercentage", "TaxType" },
                values: new object[,]
                {
                    { new Guid("260c617b-822d-4c87-a079-82e5cc30e899"), "28", true, "28", 28m, "28" },
                    { new Guid("29869748-e7be-4570-9baf-28281fdcedd9"), "18", true, "18", 18m, "18" },
                    { new Guid("b53d0455-197e-465e-aa18-d20eeaae8415"), "12", true, "12", 12m, "12" },
                    { new Guid("bcef795a-159f-40dc-a906-bd022c7a3070"), "TaxFree", true, "FREE", 0m, "0" },
                    { new Guid("e5b7ff14-7cb1-4956-9e0e-b98e74fc593c"), "5", true, "5", 5m, "5" }
                });

            migrationBuilder.InsertData(
                table: "TaxRuleDetails",
                columns: new[] { "Id", "Descriptions", "IsActive", "PerticularNames", "TaxPercentage", "TaxRuleId" },
                values: new object[,]
                {
                    { new Guid("046d1252-e445-4a54-95a5-6509e16be04e"), "CGST", true, "CGST", 2.5m, new Guid("e5b7ff14-7cb1-4956-9e0e-b98e74fc593c") },
                    { new Guid("2f3cf2c9-ea9f-4ea9-b118-c28bb1896afd"), "CGST", true, "CGST", 9m, new Guid("29869748-e7be-4570-9baf-28281fdcedd9") },
                    { new Guid("49db3a14-b001-40c7-9935-7bee1d59f856"), "CGST", true, "CGST", 6m, new Guid("b53d0455-197e-465e-aa18-d20eeaae8415") },
                    { new Guid("7a62a5e0-3d03-4265-9d83-15c93b275cbd"), "IGST", true, "IGST", 2.5m, new Guid("e5b7ff14-7cb1-4956-9e0e-b98e74fc593c") },
                    { new Guid("882ad2e7-7e86-471f-8f96-ac795fb7e677"), "IGST", true, "IGST", 9m, new Guid("29869748-e7be-4570-9baf-28281fdcedd9") },
                    { new Guid("9ff082b3-5c51-43fb-8eba-ec9b61734a2f"), "SGST", true, "SGST", 6m, new Guid("b53d0455-197e-465e-aa18-d20eeaae8415") },
                    { new Guid("a36c3222-3580-4970-adfb-64272e00145c"), "SGST", true, "SGST", 9m, new Guid("29869748-e7be-4570-9baf-28281fdcedd9") },
                    { new Guid("dd1b0a98-13e3-4bad-953c-06eccfb8dab4"), "CGST", true, "CGST", 14m, new Guid("260c617b-822d-4c87-a079-82e5cc30e899") },
                    { new Guid("e9786033-56df-4343-8d1b-82996b3b8c88"), "SGST", true, "SGST", 14m, new Guid("260c617b-822d-4c87-a079-82e5cc30e899") },
                    { new Guid("f253ba7c-e982-4537-9cd8-ce6791c4f13d"), "IGST", true, "IGST", 6m, new Guid("b53d0455-197e-465e-aa18-d20eeaae8415") },
                    { new Guid("fac7957f-f490-4e21-9889-0892664b8e5d"), "IGST", true, "IGST", 14m, new Guid("260c617b-822d-4c87-a079-82e5cc30e899") },
                    { new Guid("ff4061c1-6789-4608-a5a7-231e85750342"), "SGST", true, "SGST", 2.5m, new Guid("e5b7ff14-7cb1-4956-9e0e-b98e74fc593c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxRuleDetails_TaxRuleId",
                table: "TaxRuleDetails",
                column: "TaxRuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxRuleDetails");

            migrationBuilder.DropTable(
                name: "TaxRules");
        }
    }
}
