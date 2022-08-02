using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SavuDiary.Server.Migrations
{
    public partial class addedfieldsforstocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_TaxRecordDetail_TaxRecordDetailEntityId",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_TaxRecordDetailEntityId",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "TaxRecordDetailEntityId",
                table: "PurchaseDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseDetailEntityId",
                table: "TaxRecordDetail",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecordDetailId",
                table: "TaxRecordDetail",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "InQuantity",
                table: "StockMangement",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OutQuantity",
                table: "StockMangement",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "StockMangement",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RecordDetailId",
                table: "StockMangement",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecordId",
                table: "StockMangement",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RecordDetailId",
                table: "TaxRecordDetail");

            migrationBuilder.DropColumn(
                name: "InQuantity",
                table: "StockMangement");

            migrationBuilder.DropColumn(
                name: "OutQuantity",
                table: "StockMangement");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "StockMangement");

            migrationBuilder.DropColumn(
                name: "RecordDetailId",
                table: "StockMangement");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "StockMangement");

            migrationBuilder.AddColumn<Guid>(
                name: "TaxRecordDetailEntityId",
                table: "PurchaseDetails",
                type: "uuid",
                nullable: true);

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
    }
}
