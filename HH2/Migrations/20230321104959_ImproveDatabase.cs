﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ImproveDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offers_AddressId",
                table: "Offers");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Events",
                type: "datetime2(5)",
                precision: 5,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Events",
                type: "datetime2(5)",
                precision: 5,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AddressId",
                table: "Offers",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offers_AddressId",
                table: "Offers");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Events",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(5)",
                oldPrecision: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Events",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(5)",
                oldPrecision: 5);

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Description", "Name", "PriceOffer", "Regularity", "UpdateDate", "UserId", "offerType" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7419), "Oferuję usługi spzątania mieszkań we Wrocławiu", "Sprzątanie", 100, null, null, 1, 0 },
                    { 2, 2, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7514), "Oferuję usługi spzątania najlepiej i najtaniej", "Sprzątanie", 150, null, null, 1, 0 },
                    { 3, 3, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7540), "Posprzątam u Ciebie!", "Sprzątanie", 100, null, null, 1, 0 },
                    { 4, 4, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7576), "Oferuję usługi myycia okien", "Mycie okien", 800, null, null, 1, 1 },
                    { 5, 5, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7602), "Myje okna az sie błyszczą", "Mycie okien", 100, null, null, 2, 1 },
                    { 6, 6, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7632), "Najtaniej, najelpiej i najszybciej umyje Ci okna", "Mycie okien", 100, null, null, 2, 1 },
                    { 7, 1, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7656), "Oferuję usługi mycia okien na błysk!", "Mycie okien", 100, null, null, 2, 1 },
                    { 8, 2, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7681), "Oferuję usługi spzątania biur w Twoim miescie", "Sprzątanie", 100, null, null, 3, 0 },
                    { 9, 3, new DateTime(2023, 3, 20, 13, 24, 28, 477, DateTimeKind.Local).AddTicks(7706), "SPRZATANIE NA JUZ", "Sprzątanie", 100, null, null, 4, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AddressId",
                table: "Offers",
                column: "AddressId");
        }
    }
}
