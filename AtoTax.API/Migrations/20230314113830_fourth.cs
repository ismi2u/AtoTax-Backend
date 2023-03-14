using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtoTax.API.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DueYear",
                table: "ProcessTrackingAndFeeBalances",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DueMonth",
                table: "ProcessTrackingAndFeeBalances",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(194), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(195) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(198), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(198) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(200), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(202), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(202) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9945), new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9949) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9965), new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9966) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(29), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(30) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(33), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(33) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(35), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(35) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(36), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(37) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(38), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(39) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(40), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(42), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(42) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(114), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(116) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(119), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(119) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(121), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(121) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(123), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(123) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(124), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(125) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(126), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(127) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(128), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(129) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9993), new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9994) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9996), new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9996) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9998), new DateTime(2023, 3, 14, 11, 38, 30, 65, DateTimeKind.Utc).AddTicks(9998) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(1), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(1) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(3), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(3) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(4), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(5) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(230), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(232), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(233) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(235), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(236) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(238), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(238) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(240), new DateTime(2023, 3, 14, 11, 38, 30, 66, DateTimeKind.Utc).AddTicks(241) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DueYear",
                table: "ProcessTrackingAndFeeBalances",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DueMonth",
                table: "ProcessTrackingAndFeeBalances",
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
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6792), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6793) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6795), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6795) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6796), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6797) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6798), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6799) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6620), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6626) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6627), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6628) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6691), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6692) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6693), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6694) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6695), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6696) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6697), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6697) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6698), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6699) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6700), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6701), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6702) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6744), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6745) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6747), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6748) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6749), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6751), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6751) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6752), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6753) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6754), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6754) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6755), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6755) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6653), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6653) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6655), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6656) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6657), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6658) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6659), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6659) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6660), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6661) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6662), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6663) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6824), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6826), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6827) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6829), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6831), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6833), new DateTime(2023, 3, 14, 4, 59, 12, 712, DateTimeKind.Utc).AddTicks(6833) });
        }
    }
}
