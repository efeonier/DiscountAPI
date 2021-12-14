using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountAPI.Infrasturcture.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountedTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsGroceries = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsDeleted", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8800), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8370), false, "Employee" },
                    { 2, new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8810), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8810), false, "Affiliate" },
                    { 3, new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8820), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(8820), false, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "DateModified", "InvoiceId", "IsDeleted", "IsGroceries", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(6600), new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(4230), null, false, false, 20m, "Tshirt", 5 },
                    { 2, new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(7310), new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(7310), null, false, false, 200m, "Nike Ayakkabı", 50 },
                    { 3, new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(7320), new DateTime(2021, 12, 14, 6, 24, 55, 611, DateTimeKind.Local).AddTicks(7320), null, false, true, 20m, "Elma", 500 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerTypeId", "DateCreated", "DateModified", "Email", "FirstName", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4570), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(2980), "efe_onier@windowslive.com", "Efe", false, "Önier" },
                    { 2, 2, new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4590), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4590), "obefemi@martins.com", "Obefemi", false, "Martins" },
                    { 3, 3, new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4590), new DateTime(2021, 12, 14, 6, 24, 55, 613, DateTimeKind.Local).AddTicks(4590), "ricky_jade@jones.com", "Ricky Jade", false, "Jones" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CustomerTypeId", "DateCreated", "DateModified", "IsDeleted", "Percentage" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2850), new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2090), false, 30m },
                    { 2, 2, new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2860), new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2860), false, 10m },
                    { 3, 3, new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2870), new DateTime(2021, 12, 14, 6, 24, 55, 614, DateTimeKind.Local).AddTicks(2870), false, 5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CustomerTypeId",
                table: "Discounts",
                column: "CustomerTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InvoiceId",
                table: "Products",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
