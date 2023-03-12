using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtoTax.API.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DOJ = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthAndYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonthIdx = table.Column<string>(type: "text", nullable: false),
                    Month = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    MonthYear = table.Column<string>(type: "text", nullable: false),
                    FiscalYear = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthAndYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLoggedActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    Activity = table.Column<string>(type: "text", nullable: false),
                    AdditionalDetails = table.Column<string>(type: "text", nullable: false),
                    loggedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoggedActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressTypeName = table.Column<string>(type: "text", nullable: false),
                    AddressTypeDesc = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressTypes_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmendTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AmendTypeName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmendTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmendTypes_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GSTReturnFreqType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FixedCharge = table.Column<double>(type: "double precision", nullable: false),
                    PreviousCharge = table.Column<double>(type: "double precision", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frequencies_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GSTClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProprietorName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    GSTIN = table.Column<string>(type: "text", nullable: false),
                    ContactName = table.Column<string>(type: "text", nullable: true),
                    isRegular = table.Column<bool>(type: "boolean", nullable: false),
                    GSTUserName = table.Column<string>(type: "text", nullable: true),
                    GSTUserPassword = table.Column<string>(type: "text", nullable: true),
                    GSTRegDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GSTSurrenderedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GSTRelievedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GSTAnnualTurnOver = table.Column<double>(type: "double precision", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ContactEmailId = table.Column<string>(type: "text", nullable: true),
                    GSTEmailId = table.Column<string>(type: "text", nullable: false),
                    GSTEmailPassword = table.Column<string>(type: "text", nullable: true),
                    GSTRecoveryEmailId = table.Column<string>(type: "text", nullable: true),
                    GSTRecoveryEmailPassword = table.Column<string>(type: "text", nullable: true),
                    EWAYBillUserName = table.Column<string>(type: "text", nullable: true),
                    EWAYBillPassword = table.Column<string>(type: "text", nullable: true),
                    RackFileNo = table.Column<string>(type: "text", nullable: true),
                    TallyDataFilePath = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSTClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GSTClients_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GSTFilingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilingType = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSTFilingTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GSTFilingTypes_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultimediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Media = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultimediaTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultimediaTypes_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FixedCharge = table.Column<double>(type: "double precision", nullable: false),
                    PreviousCharge = table.Column<double>(type: "double precision", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCategories_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amendments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    AmendTypeId = table.Column<int>(type: "integer", nullable: false),
                    ARN = table.Column<string>(type: "text", nullable: false),
                    SumittedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ApprovalStatusTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amendments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amendments_AmendTypes_AmendTypeId",
                        column: x => x.AmendTypeId,
                        principalTable: "AmendTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amendments_ApprovalStatusTypes_ApprovalStatusTypeId",
                        column: x => x.ApprovalStatusTypeId,
                        principalTable: "ApprovalStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amendments_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFeeMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    FrequencyId = table.Column<int>(type: "integer", nullable: false),
                    DefaultCharge = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFeeMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientFeeMaps_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFeeMaps_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionAndBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    FrequencyId = table.Column<int>(type: "integer", nullable: false),
                    DueMonth = table.Column<string>(type: "text", nullable: true),
                    DueYear = table.Column<int>(type: "integer", nullable: true),
                    FeesAmount = table.Column<double>(type: "double precision", nullable: false),
                    AmountPaid = table.Column<double>(type: "double precision", nullable: true),
                    CurrentBalance = table.Column<double>(type: "double precision", nullable: false),
                    IsInvoiceBillsRecvd = table.Column<bool>(type: "boolean", nullable: true),
                    IsReturnFiled = table.Column<bool>(type: "boolean", nullable: true),
                    IsMixedWithNILFiling = table.Column<bool>(type: "boolean", nullable: true),
                    IsNilFiling = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR1 = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR3B = table.Column<bool>(type: "boolean", nullable: true),
                    NILGSTR1 = table.Column<bool>(type: "boolean", nullable: true),
                    NIL3B = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR9 = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR9C = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR10 = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionAndBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionAndBalances_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionAndBalances_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GSTClientAddressExtensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressTypeId = table.Column<int>(type: "integer", nullable: false),
                    AddressLine1 = table.Column<string>(type: "text", nullable: false),
                    AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    AddressLine3 = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: false),
                    Pincode = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSTClientAddressExtensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GSTClientAddressExtensions_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTClientAddressExtensions_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTClientAddressExtensions_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountLedgers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IncomeAmount = table.Column<double>(type: "double precision", nullable: true),
                    ExpenseAmount = table.Column<double>(type: "double precision", nullable: true),
                    IsGSTClientPaid = table.Column<bool>(type: "boolean", nullable: true),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    TransactionReferenceNo = table.Column<string>(type: "text", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionRecordedBy = table.Column<string>(type: "text", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountLedgers_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountLedgers_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientMonthlyPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DueMonth = table.Column<string>(type: "text", nullable: false),
                    DueYear = table.Column<int>(type: "integer", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "integer", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    PaymentReferenceNumber = table.Column<string>(type: "text", nullable: false),
                    ReceivedAmount = table.Column<double>(type: "double precision", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionRecordedBy = table.Column<string>(type: "text", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMonthlyPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientMonthlyPayments_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientMonthlyPayments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientMonthlyPayments_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GSTBillsProcessings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DueMonth = table.Column<string>(type: "text", nullable: false),
                    DueYear = table.Column<int>(type: "integer", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "integer", nullable: false),
                    GSTFilingTypeId = table.Column<int>(type: "integer", nullable: false),
                    ReceivedBy = table.Column<string>(type: "text", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MultimediaTypeId = table.Column<int>(type: "integer", nullable: false),
                    FiledBy = table.Column<string>(type: "text", nullable: true),
                    FiledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsBillsReceived = table.Column<bool>(type: "boolean", nullable: true),
                    IsFiled = table.Column<bool>(type: "boolean", nullable: true),
                    ReceivedAckEmailSent = table.Column<bool>(type: "boolean", nullable: true),
                    GSTFiledAckEmailSent = table.Column<bool>(type: "boolean", nullable: true),
                    ReceivedAckSMSSent = table.Column<bool>(type: "boolean", nullable: true),
                    GSTFiledAckSMSSent = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSTBillsProcessings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GSTBillsProcessings_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTBillsProcessings_GSTFilingTypes_GSTFilingTypeId",
                        column: x => x.GSTFilingTypeId,
                        principalTable: "GSTFilingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTBillsProcessings_MultimediaTypes_MultimediaTypeId",
                        column: x => x.MultimediaTypeId,
                        principalTable: "MultimediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTBillsProcessings_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GSTPaidDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentDueMonth = table.Column<string>(type: "text", nullable: false),
                    PaymentDueYear = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "integer", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    SettledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsPending = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSTPaidDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GSTPaidDetails_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTPaidDetails_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTPaidDetails_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceChargeUpdateHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    AmendedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "integer", nullable: false),
                    PreviousRate = table.Column<double>(type: "double precision", nullable: false),
                    NewRate = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceChargeUpdateHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceChargeUpdateHistories_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceChargeUpdateHistories_ServiceCategories_ServiceCateg~",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApprovalStatusTypes",
                columns: new[] { "Id", "StatusType" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "StatusType" },
                values: new object[,]
                {
                    { 1, "active" },
                    { 2, "inactive" }
                });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "AddressTypeDesc", "AddressTypeName", "CreatedDate", "LastModifiedDate", "StatusId" },
                values: new object[,]
                {
                    { 1, "Postal Street address", "Office Street Address", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7399), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7400), 1 },
                    { 2, "Residential Street address", "Residential Address", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7402), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7403), 1 },
                    { 3, "Godown/Factory Address", "Godown/Factory Address", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7404), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7405), 1 },
                    { 4, "Postoffice Box Number", "PostBox Address", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7406), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7406), 1 }
                });

            migrationBuilder.InsertData(
                table: "AmendTypes",
                columns: new[] { "Id", "AmendTypeName", "CreatedDate", "LastModifiedDate", "StatusId" },
                values: new object[,]
                {
                    { 1, "Core", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7272), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7276), 1 },
                    { 2, "Non-Core", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7278), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7278), 1 }
                });

            migrationBuilder.InsertData(
                table: "Frequencies",
                columns: new[] { "Id", "CreatedDate", "Description", "FixedCharge", "GSTReturnFreqType", "LastModifiedDate", "PreviousCharge", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7428), "GSTR-1 & GSTR-3B", 500.0, "Monthly-Return", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7429), 500.0, 1 },
                    { 2, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7431), "GSTR-1 & GSTR-3B", 300.0, "NilGSTR", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7431), 300.0, 1 },
                    { 3, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7433), "GSTR-1 & GSTR-3B", 1000.0, "Quaterly-Return", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7433), 1000.0, 1 },
                    { 4, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7435), "GSTR-1 & GSTR-3B", 1000.0, "Annual-Return", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7435), 1000.0, 1 },
                    { 5, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7437), "GSTR-1 & GSTR-3B", 500.0, "FinalReturn", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7437), 500.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "GSTFilingTypes",
                columns: new[] { "Id", "CreatedDate", "FilingType", "LastModifiedDate", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7327), "GSTR-1", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7328), 1 },
                    { 2, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7329), "GSTR-3B", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7330), 1 },
                    { 9, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7331), "GSTR-9", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7331), 1 },
                    { 10, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7332), "GSTR-9C", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7333), 1 },
                    { 11, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7334), "GSTR-10", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7334), 1 },
                    { 14, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7336), "NILGSTR1", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7336), 1 },
                    { 15, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7337), "NIL3B", new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7337), 1 }
                });

            migrationBuilder.InsertData(
                table: "MultimediaTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Media", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7353), null, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7355), "HardCopy", 1 },
                    { 2, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7358), null, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7358), "Email", 1 },
                    { 3, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7359), null, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7360), "WhatsApp", 1 },
                    { 4, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7361), null, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7361), "USB/Pen Drive", 1 },
                    { 5, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7362), null, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7362), "Courier", 1 },
                    { 6, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7363), null, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7364), "Cloud Drive", 1 },
                    { 7, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7367), null, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7367), "Hard Disk", 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "PaymentMethod", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7297), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7297), "Cash", 1 },
                    { 2, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7299), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7299), "Bank Transfer", 1 },
                    { 3, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7300), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7301), "UPIPay", 1 },
                    { 4, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7302), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7302), "GooglePay", 1 },
                    { 5, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7303), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7304), "Bank Cheque", 1 },
                    { 6, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7305), new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7306), "PayTM", 1 }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "FixedCharge", "LastModifiedDate", "PreviousCharge", "ServiceName", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7466), "GSTR-1 & GSTR-3B", 500.0, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7467), 500.0, "MonthlyFiling", 1 },
                    { 2, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7469), "GST Amendment", 1000.0, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7469), 500.0, "GSTAnnualReturnFiling", 1 },
                    { 3, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7471), "GST Annual Return Filing", 1000.0, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7471), 1000.0, "GSTAmendment", 1 },
                    { 4, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7473), "GST Notice Service", 1000.0, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7473), 1000.0, "GSTNoticeService", 1 },
                    { 5, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7474), "Penalty while transporting", 1000.0, new DateTime(2023, 3, 12, 7, 16, 30, 695, DateTimeKind.Utc).AddTicks(7475), 1000.0, "PenaltyBySquad", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountLedgers_GSTClientId",
                table: "AccountLedgers",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLedgers_PaymentTypeId",
                table: "AccountLedgers",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_StatusId",
                table: "AddressTypes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Amendments_AmendTypeId",
                table: "Amendments",
                column: "AmendTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Amendments_ApprovalStatusTypeId",
                table: "Amendments",
                column: "ApprovalStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Amendments_GSTClientId",
                table: "Amendments",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AmendTypes_StatusId",
                table: "AmendTypes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientFeeMaps_FrequencyId",
                table: "ClientFeeMaps",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFeeMaps_GSTClientId",
                table: "ClientFeeMaps",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMonthlyPayments_GSTClientId",
                table: "ClientMonthlyPayments",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMonthlyPayments_PaymentTypeId",
                table: "ClientMonthlyPayments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMonthlyPayments_ServiceCategoryId",
                table: "ClientMonthlyPayments",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionAndBalances_FrequencyId",
                table: "CollectionAndBalances",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionAndBalances_GSTClientId",
                table: "CollectionAndBalances",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_StatusId",
                table: "Frequencies",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTBillsProcessings_GSTClientId",
                table: "GSTBillsProcessings",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTBillsProcessings_GSTFilingTypeId",
                table: "GSTBillsProcessings",
                column: "GSTFilingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTBillsProcessings_MultimediaTypeId",
                table: "GSTBillsProcessings",
                column: "MultimediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTBillsProcessings_ServiceCategoryId",
                table: "GSTBillsProcessings",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTClientAddressExtensions_AddressTypeId",
                table: "GSTClientAddressExtensions",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTClientAddressExtensions_GSTClientId",
                table: "GSTClientAddressExtensions",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTClientAddressExtensions_StatusId",
                table: "GSTClientAddressExtensions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTClients_StatusId",
                table: "GSTClients",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTFilingTypes_StatusId",
                table: "GSTFilingTypes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTPaidDetails_GSTClientId",
                table: "GSTPaidDetails",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTPaidDetails_PaymentTypeId",
                table: "GSTPaidDetails",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTPaidDetails_ServiceCategoryId",
                table: "GSTPaidDetails",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaTypes_StatusId",
                table: "MultimediaTypes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_StatusId",
                table: "PaymentTypes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategories_StatusId",
                table: "ServiceCategories",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChargeUpdateHistories_GSTClientId",
                table: "ServiceChargeUpdateHistories",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChargeUpdateHistories_ServiceCategoryId",
                table: "ServiceChargeUpdateHistories",
                column: "ServiceCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLedgers");

            migrationBuilder.DropTable(
                name: "Amendments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClientFeeMaps");

            migrationBuilder.DropTable(
                name: "ClientMonthlyPayments");

            migrationBuilder.DropTable(
                name: "CollectionAndBalances");

            migrationBuilder.DropTable(
                name: "GSTBillsProcessings");

            migrationBuilder.DropTable(
                name: "GSTClientAddressExtensions");

            migrationBuilder.DropTable(
                name: "GSTPaidDetails");

            migrationBuilder.DropTable(
                name: "MonthAndYears");

            migrationBuilder.DropTable(
                name: "ServiceChargeUpdateHistories");

            migrationBuilder.DropTable(
                name: "UserLoggedActivities");

            migrationBuilder.DropTable(
                name: "AmendTypes");

            migrationBuilder.DropTable(
                name: "ApprovalStatusTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "GSTFilingTypes");

            migrationBuilder.DropTable(
                name: "MultimediaTypes");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "GSTClients");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
