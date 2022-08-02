using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SavuDiary.Server.Migrations
{
    public partial class AddedTaxTopurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TaxRecordDetailEntityId",
                table: "PurchaseDetails",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaxRecordDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxName = table.Column<string>(type: "text", nullable: false),
                    Dated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TaxPercenatage = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordNo = table.Column<long>(type: "bigint", nullable: false),
                    RecordDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordTypeName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRecordDetail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_TaxRecordDetailEntityId",
                table: "PurchaseDetails",
                column: "TaxRecordDetailEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_TaxRecordDetail_TaxRecordDetailEntityId",
                table: "PurchaseDetails",
                column: "TaxRecordDetailEntityId",
                principalTable: "TaxRecordDetail",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_TaxRecordDetail_TaxRecordDetailEntityId",
                table: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "TaxRecordDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_TaxRecordDetailEntityId",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "TaxRecordDetailEntityId",
                table: "PurchaseDetails");
        }
    }
}
