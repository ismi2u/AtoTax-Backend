using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtoTax.API.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FiledBy",
                table: "GSTBillAndFeeCollections",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1140), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1142) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1147), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1149) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1152), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1154) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1157), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(765), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(772), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(907), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(909) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(913), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(922), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(923) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(926), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(928) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(931), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(932) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(935), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(939), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(944), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(945) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(948), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(952), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(957), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(961), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(966), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(971), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(973) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(975), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(977) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(980), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(981) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1032), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1040), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1045), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1046) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1048), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1053), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1058), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1062), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(810), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(813) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(817), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(818) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(822), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(823) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(826), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(827) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(830), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(834), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(675), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(693), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(695) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(699), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(707), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(709) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(712), new DateTime(2023, 3, 6, 13, 47, 55, 596, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.CreateIndex(
                name: "IX_GSTBillAndFeeCollections_MultimediaTypeId",
                table: "GSTBillAndFeeCollections",
                column: "MultimediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GSTBillAndFeeCollections_MultimediaTypes_MultimediaTypeId",
                table: "GSTBillAndFeeCollections",
                column: "MultimediaTypeId",
                principalTable: "MultimediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GSTBillAndFeeCollections_MultimediaTypes_MultimediaTypeId",
                table: "GSTBillAndFeeCollections");

            migrationBuilder.DropIndex(
                name: "IX_GSTBillAndFeeCollections_MultimediaTypeId",
                table: "GSTBillAndFeeCollections");

            migrationBuilder.AlterColumn<string>(
                name: "FiledBy",
                table: "GSTBillAndFeeCollections",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5050), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5054), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5056), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5058), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5058) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4827), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4829) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4831), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4832) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4927), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4927) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4933), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4935), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4935) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4937), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4940), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4942), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4942) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4943), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4944) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4946), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4947) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4948), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4949) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4950), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4952), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4954), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4954) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4955), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4957), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4958) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4959), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4961), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4992), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4996), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4998), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5000), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5001) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5002), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5004), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5005) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5007), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4854), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4858), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4859) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4860), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4862), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4863) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4864), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4866), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4866) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4783), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4787) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4790), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4793), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4793) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4795), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4796) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4797), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4798) });
        }
    }
}
