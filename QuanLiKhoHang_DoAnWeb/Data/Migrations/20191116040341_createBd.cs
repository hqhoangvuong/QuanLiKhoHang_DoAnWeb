using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLiKhoHang_DoAnWeb.Data.Migrations
{
    public partial class createBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchaseOrderDetails_purchaseOrders_PurchaseOrderId",
                table: "purchaseOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchaseOrders",
                table: "purchaseOrders");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId",
                table: "purchaseOrders");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "purchaseOrders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "purchaseOrders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchaseOrders",
                table: "purchaseOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseOrderDetails_purchaseOrders_PurchaseOrderId",
                table: "purchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "purchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchaseOrderDetails_purchaseOrders_PurchaseOrderId",
                table: "purchaseOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchaseOrders",
                table: "purchaseOrders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "purchaseOrders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "purchaseOrders");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderId",
                table: "purchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchaseOrders",
                table: "purchaseOrders",
                column: "PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseOrderDetails_purchaseOrders_PurchaseOrderId",
                table: "purchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "purchaseOrders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }
    }
}
