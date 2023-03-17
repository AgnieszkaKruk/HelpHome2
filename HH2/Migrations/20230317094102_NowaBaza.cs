using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class NowaBaza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Street",
                value: "Majowa 5");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Street",
                value: "Kopernika 34");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "OfferentId", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 4, "Katowice", null, "43-190", "Głogowa 8" },
                    { 5, "Wrocław", null, "13-190", "Główna 10" },
                    { 6, "Kraków", null, "43-190", "Moja 14" },
                    { 7, "Katowice", null, "43-190", "Zielona 5" }
                });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5077), "Oferuję usługi spzątania najlepiej i najtaniej" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Description", "Name", "PriceOffer", "Regularity", "UpdateDate", "UserId", "offerType" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5125), "Posprzątam u Ciebie!", "Sprzątanie", 100, null, null, 1, 0 },
                    { 7, 1, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5514), "Oferuję usługi mycia okien na błysk!", "Mycie okien", 100, null, null, 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "jankowalski@com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "agakruk@wp.pl");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 3, "Offerent", "monikal@wp.pl", "Monika L", "#$%%^^&&", "444555333", 2 },
                    { 4, "Offerent", "olgaz@wp.pl", "Olga Z", "#$%%^^&&", "444555333", 2 },
                    { 5, "Offerent", "krzysiekk@wp.pl", "Krzysiek k", "#$%%^^&&", "444555333", 2 },
                    { 6, "Offerent", "łukaszszus@wp.pl", "Łukasz szus", "#$%%^^&&", "444555333", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "OfferentId", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 7, "Seeker", "janian@com", "Janian", null, "#1234#", "123456", 1 },
                    { 8, "Seeker", "zosia@wp.pl", "Zosia", null, "#$%%^^&&", "444555333", 1 },
                    { 9, "Seeker", "gosia@wp.pl", "Gosia", null, "#$%%^^&&", "444555333", 1 },
                    { 10, "Seeker", "mietek@wp.pl", "Mietek", null, "#$%%^^&&", "444555333", 1 },
                    { 11, "Seeker", "filip@wp.pl", "Filip Sz", null, "#$%%^^&&", "444555333", 1 },
                    { 12, "Seeker", "andrzej@wp.pl", "Andrzej", null, "#$%%^^&&", "444555333", 1 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Description", "Name", "PriceOffer", "Regularity", "UpdateDate", "UserId", "offerType" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5332), "Oferuję usługi myycia okien", "Mycie okien", 800, null, null, 1, 1 },
                    { 5, 5, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5403), "Myje okna az sie błyszczą", "Mycie okien", 100, null, null, 2, 1 },
                    { 6, 6, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5463), "Najtaniej, najelpiej i najszybciej umyje Ci okna", "Mycie okien", 100, null, null, 2, 1 },
                    { 8, 2, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5567), "Oferuję usługi spzątania biur w Twoim miescie", "Sprzątanie", 100, null, null, 3, 0 },
                    { 9, 3, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5614), "SPRZATANIE NA JUZ", "Sprzątanie", 100, null, null, 4, 0 },
                    { 10, 4, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5715), "SPRZATANIE NA JUZ", "Sprzątanie", 100, null, null, 5, 0 },
                    { 11, 5, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5778), "sprzatam jutro", "Sprzątanie", 100, null, null, 6, 0 },
                    { 12, 6, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5860), "SPRZATANIE teraz", "Sprzątanie", 100, null, null, 5, 0 },
                    { 13, 1, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(5963), "Piore dywany", "Pranie dywanów", 100, null, null, 5, 2 },
                    { 14, 2, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(6039), "wyprawne dywany i juz nie masz alergii", "Pranie dywanów", 100, null, null, 6, 2 },
                    { 15, 3, new DateTime(2023, 3, 17, 10, 41, 1, 664, DateTimeKind.Local).AddTicks(6091), "Profesjonalne pranie dywanów", "Pranie dywanów", 100, null, null, 4, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

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

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Street",
                value: "Majowa");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Street",
                value: "Głogowa");

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 20, 13, 37, 58, 281, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2023, 2, 20, 13, 37, 58, 281, DateTimeKind.Local).AddTicks(4362), "Oferuję usługi spzątania biur we Wrocławiu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "jdsks@com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "agak@wp.pl");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "OfferentId", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 3, "Seeker", "jdsks@com", "Janian", null, "#1234#", "123456", 1 },
                    { 4, "Seeker", "agak@wp.pl", "Zsoia", null, "#$%%^^&&", "444555333", 1 }
                });
        }
    }
}
