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
                name: "ReceivedByUser",
                table: "ProcessTrackingAndFeeBalances",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "GSTR3BFiledByUser",
                table: "ProcessTrackingAndFeeBalances",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "GSTR1FiledByUser",
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
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6785), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6787) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6789), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6789) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6791), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6791) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6792), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6668), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6672) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6674), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6674) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6720), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6720) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6723), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6723) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6724), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6725) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6726), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6726) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6727), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6727) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6728), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6729) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6730), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6744), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6749), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6750), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6751), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6752) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6753), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6753) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6754), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6754) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6755), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6756) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6689), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6692), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6692) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6693), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6694) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6699), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6699) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6700), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6701) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6702), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6702) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6811), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6811) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6813), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6813) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6815), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6815) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6816), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6825), new DateTime(2023, 3, 14, 16, 37, 9, 712, DateTimeKind.Utc).AddTicks(6825) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReceivedByUser",
                table: "ProcessTrackingAndFeeBalances",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GSTR3BFiledByUser",
                table: "ProcessTrackingAndFeeBalances",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GSTR1FiledByUser",
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
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3657), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3658) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3660), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3661) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3662), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3663) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3664), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3665) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3470), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3479), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3479) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3542), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3543) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3544), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3545) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3547), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3548), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3549) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3550), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3556), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3557) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3558), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3559) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3596), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3597) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3600), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3602), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3602) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3603), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3604) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3605), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3606) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3607), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3608) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3609), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3508), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3508) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3510), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3511) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3512), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3513) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3514), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3515) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3516), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3518), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3518) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3693), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3694) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3697), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3698) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3707), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3707) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3709), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3711), new DateTime(2023, 3, 14, 16, 12, 42, 560, DateTimeKind.Utc).AddTicks(3712) });
        }
    }
}
