using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountAPI.Infrasturcture.Migrations
{
    public partial class InvoiceProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Invoices_InvoiceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_InvoiceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "InvoiceProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(1840), new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(1860), new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(1860) });

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(1860), new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(1860) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 471, DateTimeKind.Local).AddTicks(6550), new DateTime(2021, 12, 14, 6, 37, 56, 471, DateTimeKind.Local).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 471, DateTimeKind.Local).AddTicks(6580), new DateTime(2021, 12, 14, 6, 37, 56, 471, DateTimeKind.Local).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 471, DateTimeKind.Local).AddTicks(6590), new DateTime(2021, 12, 14, 6, 37, 56, 471, DateTimeKind.Local).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(6560), new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(5780) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(6580), new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(6580), new DateTime(2021, 12, 14, 6, 37, 56, 472, DateTimeKind.Local).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 469, DateTimeKind.Local).AddTicks(6850), new DateTime(2021, 12, 14, 6, 37, 56, 469, DateTimeKind.Local).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 469, DateTimeKind.Local).AddTicks(7600), new DateTime(2021, 12, 14, 6, 37, 56, 469, DateTimeKind.Local).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 37, 56, 469, DateTimeKind.Local).AddTicks(7610), new DateTime(2021, 12, 14, 6, 37, 56, 469, DateTimeKind.Local).AddTicks(7610) });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_InvoiceId",
                table: "InvoiceProducts",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceProducts");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8800), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8810), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8820), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4570), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4590), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4590), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2850), new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2860), new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2870), new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(6600), new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(7310), new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(7320), new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(7320) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_InvoiceId",
                table: "Products",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Invoices_InvoiceId",
                table: "Products",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
