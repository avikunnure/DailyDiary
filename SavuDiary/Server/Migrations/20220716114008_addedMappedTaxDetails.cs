using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SavuDiary.Server.Migrations
{
    public partial class addedMappedTaxDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxRecordDetail_PurchaseDetails_PurchaseDetailEntityId",
                table: "TaxRecordDetail");

            migrationBuilder.DropIndex(
                name: "IX_TaxRecordDetail_PurchaseDetailEntityId",
                table: "TaxRecordDetail");

            migrationBuilder.DropColumn(
                name: "PurchaseDetailEntityId",
                table: "TaxRecordDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseDetailEntityId",
                table: "TaxRecordDetail",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxRecordDetail_PurchaseDetailEntityId",
                table: "TaxRecordDetail",
                column: "PurchaseDetailEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxRecordDetail_PurchaseDetails_PurchaseDetailEntityId",
                table: "TaxRecordDetail",
                column: "PurchaseDetailEntityId",
                principalTable: "PurchaseDetails",
                principalColumn: "Id");
        }
    }
}
