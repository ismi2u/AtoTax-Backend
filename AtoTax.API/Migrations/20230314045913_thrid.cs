using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtoTax.API.Migrations
{
    /// <inheritdoc />
    public partial class thrid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GSTR1FiledByUser",
                table: "ProcessTrackingAndFeeBalances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GSTR3BFiledByUser",
                table: "ProcessTrackingAndFeeBalances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceivedByUser",
                table: "ProcessTrackingAndFeeBalances",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GSTR1FiledByUser",
                table: "ProcessTrackingAndFeeBalances");

            migrationBuilder.DropColumn(
                name: "GSTR3BFiledByUser",
                table: "ProcessTrackingAndFeeBalances");

            migrationBuilder.DropColumn(
                name: "ReceivedByUser",
                table: "ProcessTrackingAndFeeBalances");

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4469), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4471) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4475), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4476) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4479), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4480) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4484), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4485) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4094), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4105), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4107) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4236), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4243), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4247), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4250), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4253), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4268), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4269) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4271), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4272) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4328), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4332) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4337), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4338) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4340), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4341) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4361), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4364), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4365) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4367), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4370), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4371) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4157), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4165), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4169), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4172), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4175), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4178), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4541), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4542) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4546), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4548) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4552), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4556), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4557) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4560), new DateTime(2023, 3, 13, 14, 25, 53, 900, DateTimeKind.Utc).AddTicks(4561) });
        }
    }
}
