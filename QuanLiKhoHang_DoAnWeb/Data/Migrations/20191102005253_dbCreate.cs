using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLiKhoHang_DoAnWeb.Data.Migrations
{
    public partial class dbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: false),
                    Sex = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "saleOrders",
                columns: table => new
                {
                    SaleOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<float>(nullable: false),
                    CustomersCustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleOrders", x => x.SaleOrderId);
                    table.ForeignKey(
                        name: "FK_saleOrders_customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    DefaultBuyingPrice = table.Column<float>(nullable: false),
                    DefaultSellingPrice = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductImageUrl = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Deleted = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    ProductTypesProductTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_productTypes_ProductTypesProductTypeId",
                        column: x => x.ProductTypesProductTypeId,
                        principalTable: "productTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchaseOrders",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderName = table.Column<string>(nullable: true),
                    VendorId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    VendorsVendorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseOrders", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_purchaseOrders_vendors_VendorsVendorId",
                        column: x => x.VendorsVendorId,
                        principalTable: "vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "saleOrderDetails",
                columns: table => new
                {
                    ProductIssueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleOrderId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleOrderDetails", x => x.ProductIssueId);
                    table.ForeignKey(
                        name: "FK_saleOrderDetails_saleOrders_SaleOrderId",
                        column: x => x.SaleOrderId,
                        principalTable: "saleOrders",
                        principalColumn: "SaleOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseOrderDetails",
                columns: table => new
                {
                    ProductReceiptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseOrderDetails", x => x.ProductReceiptId);
                    table.ForeignKey(
                        name: "FK_purchaseOrderDetails_purchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "purchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductTypesProductTypeId",
                table: "products",
                column: "ProductTypesProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderDetails_PurchaseOrderId",
                table: "purchaseOrderDetails",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrders_VendorsVendorId",
                table: "purchaseOrders",
                column: "VendorsVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_saleOrderDetails_SaleOrderId",
                table: "saleOrderDetails",
                column: "SaleOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_saleOrders_CustomersCustomerId",
                table: "saleOrders",
                column: "CustomersCustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "purchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "saleOrderDetails");

            migrationBuilder.DropTable(
                name: "productTypes");

            migrationBuilder.DropTable(
                name: "purchaseOrders");

            migrationBuilder.DropTable(
                name: "saleOrders");

            migrationBuilder.DropTable(
                name: "vendors");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
