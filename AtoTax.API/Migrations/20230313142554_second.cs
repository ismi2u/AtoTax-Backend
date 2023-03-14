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
                name: "TallyDataFilePath",
                table: "GSTClients",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RackFileNo",
                table: "GSTClients",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TallyDataFilePath",
                table: "GSTClients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "RackFileNo",
                table: "GSTClients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8110), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8111) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8113), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8114) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8115), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8116) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8117), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8117) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7967), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7972), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7973) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8021), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8022) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8024), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8024) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8025), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8026) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8027), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8027) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8028), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8030), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8032), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8032) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8064), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8068), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8070), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8071), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8072) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8073), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8075), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8076), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8077) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7994), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7995) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7996), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7997) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7998), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(7999), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8001), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8002) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8003), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8003) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8136), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8141) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8143), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8145), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8147), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8149), new DateTime(2023, 3, 13, 14, 6, 26, 336, DateTimeKind.Utc).AddTicks(8150) });
        }
    }
}
