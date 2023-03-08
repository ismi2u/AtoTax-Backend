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
                name: "ReceivedBy",
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
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8361), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8364), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8366), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8366) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8367), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8368) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8216), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8217) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8218), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8266), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8266) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8268), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8270), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8272), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8272) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8273), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8274) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8275), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8275) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8276), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8278), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8280), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8280) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8282), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8282) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8283), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8286), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8288), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8288) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8289), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8290) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8291), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8293), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8293) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8314), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8318), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8319) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8320), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8322), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8322) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8323), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8324) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8325), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8326) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8327), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8327) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8236), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8237) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8240), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8240) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8242), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8243), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8245), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8245) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8247), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8174), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8181), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8181) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8183), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8185), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8186) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8187), new DateTime(2023, 3, 8, 13, 51, 51, 2, DateTimeKind.Utc).AddTicks(8188) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReceivedBy",
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
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4310), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4320), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4322), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4322) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4323), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4323) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4187), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4189), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4233), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4236), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4237), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4238), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4240), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4241), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4242) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4243), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4244), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4245), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4247), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4248), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4249), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4251), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4252), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4253), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4255), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4271), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4273) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4274), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4276), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4276) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4277), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4278) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4278), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4280), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4281), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4206), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4207) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4208), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4210), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4211), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4213), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4214), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4150), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4157) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4159), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4161), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4161) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4163), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4164), new DateTime(2023, 3, 7, 19, 58, 41, 843, DateTimeKind.Utc).AddTicks(4165) });
        }
    }
}
