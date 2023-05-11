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
            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2083), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2085) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2087), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2087) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2088), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2089) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2090), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2091) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1937), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1941) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1942), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1993), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1994) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1995), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1996) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1997), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1998) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1999), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1999) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2000), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2001) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2002), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2002) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2003), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2004) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2032), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2035), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2036) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2037), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2037) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2038), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2039) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2040), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2040) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2041), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2042) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2043), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2043) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1959), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1961), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1963), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1963) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1964), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1965) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1966), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1966) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1967), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(1968) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2110), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2113), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2113) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2115), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2115) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2117), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2119), new DateTime(2023, 4, 9, 12, 11, 44, 769, DateTimeKind.Utc).AddTicks(2119) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1141), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1143) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1144), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1145) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1146), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1146) });

            migrationBuilder.UpdateData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1148), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1148) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1007), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1009) });

            migrationBuilder.UpdateData(
                table: "AmendTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1011), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1011) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1061), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1064), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1066), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1067) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1067), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1069), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1070), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "GSTFilingTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1072), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1092), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1098) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1101), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1102) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1103), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1103) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1104), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1105) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1106), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1107), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1107) });

            migrationBuilder.UpdateData(
                table: "MultimediaTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1108), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1109) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1031), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1034), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1036), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1037), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1038) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1039), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1040), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1041) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1167), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1170), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1172), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1173) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1174), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1175) });

            migrationBuilder.UpdateData(
                table: "ReturnFrequencyType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1176), new DateTime(2023, 4, 9, 11, 52, 57, 429, DateTimeKind.Utc).AddTicks(1176) });
        }
    }
}
