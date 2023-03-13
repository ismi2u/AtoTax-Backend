using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtoTax.API.Migrations
{
    /// <inheritdoc />
    public partial class newtest : Migration
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
                    ClientRelationMgrId = table.Column<Guid>(type: "uuid", nullable: true),
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
                name: "ReturnFrequencyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReturnFreqType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FixedCharge = table.Column<double>(type: "double precision", nullable: false),
                    PreviousCharge = table.Column<double>(type: "double precision", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnFrequencyType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnFrequencyType_Status_StatusId",
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
                name: "ClientFeeMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnFrequencyTypeId = table.Column<int>(type: "integer", nullable: false),
                    DefaultCharge = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFeeMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientFeeMaps_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFeeMaps_ReturnFrequencyType_ReturnFrequencyTypeId",
                        column: x => x.ReturnFrequencyTypeId,
                        principalTable: "ReturnFrequencyType",
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
                    ReturnFrequencyTypeId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_ClientMonthlyPayments_ReturnFrequencyType_ReturnFrequencyTy~",
                        column: x => x.ReturnFrequencyTypeId,
                        principalTable: "ReturnFrequencyType",
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
                    ReturnFrequencyTypeId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_GSTBillsProcessings_ReturnFrequencyType_ReturnFrequencyType~",
                        column: x => x.ReturnFrequencyTypeId,
                        principalTable: "ReturnFrequencyType",
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
                    ReturnFrequencyTypeId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_GSTPaidDetails_ReturnFrequencyType_ReturnFrequencyTypeId",
                        column: x => x.ReturnFrequencyTypeId,
                        principalTable: "ReturnFrequencyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessTrackingAndFeeBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnFrequencyTypeId = table.Column<int>(type: "integer", nullable: false),
                    DueMonth = table.Column<string>(type: "text", nullable: false),
                    DueYear = table.Column<int>(type: "integer", nullable: false),
                    RackFileNo = table.Column<string>(type: "text", nullable: false),
                    SalesInvoice = table.Column<bool>(type: "boolean", nullable: true),
                    SalesBillsNil = table.Column<bool>(type: "boolean", nullable: true),
                    PurchaseInvoice = table.Column<bool>(type: "boolean", nullable: true),
                    PurchaseNil = table.Column<bool>(type: "boolean", nullable: true),
                    GSTTaxAmount = table.Column<string>(type: "text", nullable: false),
                    FeesAmount = table.Column<string>(type: "text", nullable: false),
                    AmountPaid = table.Column<string>(type: "text", nullable: false),
                    CurrentBalance = table.Column<string>(type: "text", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SalesFiled = table.Column<bool>(type: "boolean", nullable: true),
                    SalesNotFiled = table.Column<bool>(type: "boolean", nullable: true),
                    SalesNilFiled = table.Column<bool>(type: "boolean", nullable: true),
                    SalesNilNotFiled = table.Column<bool>(type: "boolean", nullable: true),
                    SalesFiledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GSTR3BFiled = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR3BNotFiled = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR3BNILFiled = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR3BNilNotFiled = table.Column<bool>(type: "boolean", nullable: true),
                    GSTR3BFiledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessTrackingAndFeeBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessTrackingAndFeeBalances_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessTrackingAndFeeBalances_ReturnFrequencyType_ReturnFre~",
                        column: x => x.ReturnFrequencyTypeId,
                        principalTable: "ReturnFrequencyType",
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
                    ReturnFrequencyTypeId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_ServiceChargeUpdateHistories_ReturnFrequencyType_ReturnFreq~",
                        column: x => x.ReturnFrequencyTypeId,
                        principalTable: "ReturnFrequencyType",
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
                    { 1, "Postal Street address", "Office Street Address", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(188), new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(190), 1 },
                    { 2, "Residential Street address", "Residential Address", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(193), new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(194), 1 },
                    { 3, "Godown/Factory Address", "Godown/Factory Address", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(197), new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(198), 1 },
                    { 4, "Postoffice Box Number", "PostBox Address", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(200), new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(201), 1 }
                });

            migrationBuilder.InsertData(
                table: "AmendTypes",
                columns: new[] { "Id", "AmendTypeName", "CreatedDate", "LastModifiedDate", "StatusId" },
                values: new object[,]
                {
                    { 1, "Core", new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9921), new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9929), 1 },
                    { 2, "Non-Core", new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9932), new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9933), 1 }
                });

            migrationBuilder.InsertData(
                table: "GSTFilingTypes",
                columns: new[] { "Id", "CreatedDate", "FilingType", "LastModifiedDate", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(48), "GSTR-1", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(51), 1 },
                    { 2, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(56), "GSTR-3B", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(57), 1 },
                    { 9, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(59), "GSTR-9", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(59), 1 },
                    { 10, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(61), "GSTR-9C", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(62), 1 },
                    { 11, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(64), "GSTR-10", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(65), 1 },
                    { 14, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(67), "NILGSTR1", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(67), 1 },
                    { 15, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(69), "NIL3B", new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(70), 1 }
                });

            migrationBuilder.InsertData(
                table: "MultimediaTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Media", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(105), null, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(107), "HardCopy", 1 },
                    { 2, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(110), null, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(111), "Email", 1 },
                    { 3, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(113), null, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(114), "WhatsApp", 1 },
                    { 4, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(116), null, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(117), "USB/Pen Drive", 1 },
                    { 5, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(118), null, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(119), "Courier", 1 },
                    { 6, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(121), null, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(122), "Cloud Drive", 1 },
                    { 7, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(123), null, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(124), "Hard Disk", 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "PaymentMethod", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9983), new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9985), "Cash", 1 },
                    { 2, new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9992), new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9993), "Bank Transfer", 1 },
                    { 3, new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9995), new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9996), "UPIPay", 1 },
                    { 4, new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9998), new DateTime(2023, 3, 13, 12, 28, 2, 551, DateTimeKind.Utc).AddTicks(9999), "GooglePay", 1 },
                    { 5, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(1), new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(2), "Bank Cheque", 1 },
                    { 6, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(5), new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(6), "PayTM", 1 }
                });

            migrationBuilder.InsertData(
                table: "ReturnFrequencyType",
                columns: new[] { "Id", "CreatedDate", "Description", "FixedCharge", "LastModifiedDate", "PreviousCharge", "ReturnFreqType", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(237), "GSTR-1 & GSTR-3B", 500.0, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(239), 500.0, "Monthly-Return", 1 },
                    { 2, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(243), "GSTR-1 & GSTR-3B", 300.0, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(244), 300.0, "NilGSTR", 1 },
                    { 3, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(247), "GSTR-1 & GSTR-3B", 1000.0, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(248), 1000.0, "Quaterly-Return", 1 },
                    { 4, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(250), "GSTR-1 & GSTR-3B", 1000.0, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(251), 1000.0, "Annual-Return", 1 },
                    { 5, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(254), "GSTR-1 & GSTR-3B", 500.0, new DateTime(2023, 3, 13, 12, 28, 2, 552, DateTimeKind.Utc).AddTicks(255), 500.0, "FinalReturn", 1 }
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
                name: "IX_ClientFeeMaps_GSTClientId",
                table: "ClientFeeMaps",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFeeMaps_ReturnFrequencyTypeId",
                table: "ClientFeeMaps",
                column: "ReturnFrequencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMonthlyPayments_GSTClientId",
                table: "ClientMonthlyPayments",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMonthlyPayments_PaymentTypeId",
                table: "ClientMonthlyPayments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMonthlyPayments_ReturnFrequencyTypeId",
                table: "ClientMonthlyPayments",
                column: "ReturnFrequencyTypeId");

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
                name: "IX_GSTBillsProcessings_ReturnFrequencyTypeId",
                table: "GSTBillsProcessings",
                column: "ReturnFrequencyTypeId");

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
                name: "IX_GSTPaidDetails_ReturnFrequencyTypeId",
                table: "GSTPaidDetails",
                column: "ReturnFrequencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaTypes_StatusId",
                table: "MultimediaTypes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_StatusId",
                table: "PaymentTypes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessTrackingAndFeeBalances_GSTClientId",
                table: "ProcessTrackingAndFeeBalances",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessTrackingAndFeeBalances_ReturnFrequencyTypeId",
                table: "ProcessTrackingAndFeeBalances",
                column: "ReturnFrequencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnFrequencyType_StatusId",
                table: "ReturnFrequencyType",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChargeUpdateHistories_GSTClientId",
                table: "ServiceChargeUpdateHistories",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChargeUpdateHistories_ReturnFrequencyTypeId",
                table: "ServiceChargeUpdateHistories",
                column: "ReturnFrequencyTypeId");
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
                name: "GSTBillsProcessings");

            migrationBuilder.DropTable(
                name: "GSTClientAddressExtensions");

            migrationBuilder.DropTable(
                name: "GSTPaidDetails");

            migrationBuilder.DropTable(
                name: "MonthAndYears");

            migrationBuilder.DropTable(
                name: "ProcessTrackingAndFeeBalances");

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
                name: "ReturnFrequencyType");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
