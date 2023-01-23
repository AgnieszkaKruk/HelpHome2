using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class OffersSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Regularity",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Description", "Name", "PriceOffer", "Regularity", "UpdateDate", "UserId", "offerType" },
                values: new object[] { 1, 1, new DateTime(2023, 1, 22, 9, 34, 43, 433, DateTimeKind.Local).AddTicks(6831), "Oferuję usługi spzątania mieszkań we Wrocławiu", "Sprzątanie", 100, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Description", "Name", "PriceOffer", "Regularity", "UpdateDate", "UserId", "offerType" },
                values: new object[] { 2, 2, new DateTime(2023, 1, 22, 9, 34, 43, 433, DateTimeKind.Local).AddTicks(6923), "Oferuję usługi spzątania biur we Wrocławiu", "Sprzątanie", 150, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Regularity",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
