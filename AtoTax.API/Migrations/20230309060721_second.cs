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
            migrationBuilder.DropForeignKey(
                name: "FK_AccountLedgers_GSTClients_GSTClientId",
                table: "AccountLedgers");

            migrationBuilder.AlterColumn<Guid>(
                name: "GSTClientId",
                table: "AccountLedgers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8531), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8532) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8537), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8540), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8540) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8542), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8323), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8329), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8329) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8399), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8399) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8401), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8402) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8409), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8411), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8412) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8413), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8414) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8416), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8418), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8419) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8420), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8422), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8423) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8424), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8426), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8428), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8430), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8432), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8434), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8434) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8435), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8467), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8468) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8470), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8472), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8473) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8474), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8475) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8476), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8476) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8478), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8478) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8480), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8480) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8354), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8358), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8360), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8360) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8362), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8364), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8366), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8366) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8272), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8280) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8282), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8283) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8285), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8288), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8288) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8290), new DateTime(2023, 3, 9, 6, 7, 21, 352, DateTimeKind.Utc).AddTicks(8291) });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLedgers_GSTClients_GSTClientId",
                table: "AccountLedgers",
                column: "GSTClientId",
                principalTable: "GSTClients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountLedgers_GSTClients_GSTClientId",
                table: "AccountLedgers");

            migrationBuilder.AlterColumn<Guid>(
                name: "GSTClientId",
                table: "AccountLedgers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1476), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1479), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1482), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1482) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1484), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1260), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1261) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1264), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1265) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1342), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1343) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1345), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1345) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1353), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1353) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1354), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1355) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1356), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1357) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1358), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1359) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1360), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1361) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1362), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1365), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1365) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1367), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1367) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1368), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1369) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1370), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1371) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1372), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1374), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1376), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1376) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1377), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1378) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1409), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1413), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1413) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1415), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1415) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1416), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1417) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1418), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1420), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1422), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1423) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1299), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1304), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1305) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1306), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1307) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1308), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1310), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1311) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1312), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1313) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1209), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1214) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1217), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1219), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1222), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1222) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1224), new DateTime(2023, 3, 9, 6, 5, 42, 484, DateTimeKind.Utc).AddTicks(1224) });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLedgers_GSTClients_GSTClientId",
                table: "AccountLedgers",
                column: "GSTClientId",
                principalTable: "GSTClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
