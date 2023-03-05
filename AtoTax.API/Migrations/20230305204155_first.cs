using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtoTax.API.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
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
                    GSTUserName = table.Column<string>(type: "text", nullable: true),
                    GSTUserPassword = table.Column<string>(type: "text", nullable: true),
                    GSTRegDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GSTSurrenderedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GSTRelievedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GSTAnnualTurnOver = table.Column<double>(type: "double precision", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ContactEmailId = table.Column<string>(type: "text", nullable: true),
                    GSTEmailId = table.Column<string>(type: "text", nullable: true),
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
                name: "CollectionAndBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DueMonth = table.Column<string>(type: "text", nullable: true),
                    DueYear = table.Column<int>(type: "integer", nullable: true),
                    FeesAmount = table.Column<double>(type: "double precision", nullable: true),
                    AmountPaid = table.Column<double>(type: "double precision", nullable: false),
                    CurrentBalance = table.Column<double>(type: "double precision", nullable: false),
                    AmountReceivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionAndBalances", x => x.Id);
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
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IncomingAmount = table.Column<double>(type: "double precision", nullable: true),
                    ExpenseAmount = table.Column<double>(type: "double precision", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountLedgers_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ServiceCategoryId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_ClientFeeMaps_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GSTBillAndFeeCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GSTClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DueMonth = table.Column<string>(type: "text", nullable: false),
                    DueYear = table.Column<int>(type: "integer", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "integer", nullable: false),
                    GSTFilingTypeId = table.Column<int>(type: "integer", nullable: false),
                    ReceivedBy = table.Column<string>(type: "text", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MultimediaTypeId = table.Column<int>(type: "integer", nullable: false),
                    FiledBy = table.Column<string>(type: "text", nullable: false),
                    FiledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsBillsReceived = table.Column<bool>(type: "boolean", nullable: true),
                    IsFiled = table.Column<bool>(type: "boolean", nullable: true),
                    FeesAmount = table.Column<double>(type: "double precision", nullable: true),
                    FeesPaidAmt = table.Column<double>(type: "double precision", nullable: true),
                    Balance = table.Column<double>(type: "double precision", nullable: true),
                    ReceivedAckEmailSent = table.Column<bool>(type: "boolean", nullable: true),
                    GSTFiledAckEmailSent = table.Column<bool>(type: "boolean", nullable: true),
                    ReceivedAckSMSSent = table.Column<bool>(type: "boolean", nullable: true),
                    GSTFiledAckSMSSent = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSTBillAndFeeCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GSTBillAndFeeCollections_GSTClients_GSTClientId",
                        column: x => x.GSTClientId,
                        principalTable: "GSTClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTBillAndFeeCollections_GSTFilingTypes_GSTFilingTypeId",
                        column: x => x.GSTFilingTypeId,
                        principalTable: "GSTFilingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GSTBillAndFeeCollections_ServiceCategories_ServiceCategoryId",
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
                    { 1, "Postal Street address", "Office Street Address", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5050), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5051), 1 },
                    { 2, "Residential Street address", "Residential Address", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5054), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5054), 1 },
                    { 3, "Godown/Factory Address", "Godown/Factory Address", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5056), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5057), 1 },
                    { 4, "Postoffice Box Number", "PostBox Address", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5058), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5058), 1 }
                });

            migrationBuilder.InsertData(
                table: "AmendTypes",
                columns: new[] { "Id", "AmendTypeName", "CreatedDate", "LastModifiedDate", "StatusId" },
                values: new object[,]
                {
                    { 1, "Core", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4827), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4829), 1 },
                    { 2, "Non-Core", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4831), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4832), 1 }
                });

            migrationBuilder.InsertData(
                table: "GSTFilingTypes",
                columns: new[] { "Id", "CreatedDate", "FilingType", "LastModifiedDate", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4927), "GSTR-1", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4927), 1 },
                    { 2, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4933), "GSTR-3B", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4933), 1 },
                    { 3, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4935), "GSTR-4", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4935), 1 },
                    { 4, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4937), "GSTR-5", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4937), 1 },
                    { 5, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4940), "GSTR-5A", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4940), 1 },
                    { 6, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4942), "GSTR-6", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4942), 1 },
                    { 7, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4943), "GSTR-7", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4944), 1 },
                    { 8, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4946), "GSTR-8", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4947), 1 },
                    { 9, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4948), "GSTR-9", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4949), 1 },
                    { 10, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4950), "GSTR-9C", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4951), 1 },
                    { 11, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4952), "GSTR-10", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4952), 1 },
                    { 12, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4954), "GSTR-11", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4954), 1 },
                    { 13, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4955), "CMP-08", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4956), 1 },
                    { 14, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4957), "NILGSTR1", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4958), 1 },
                    { 15, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4959), "NIL3B", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4960), 1 },
                    { 16, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4961), "ITC-04", new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4961), 1 }
                });

            migrationBuilder.InsertData(
                table: "MultimediaTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Media", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4992), null, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4994), "HardCopy", 1 },
                    { 2, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4996), null, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4997), "Email", 1 },
                    { 3, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4998), null, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4999), "WhatsApp", 1 },
                    { 4, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5000), null, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5001), "USB/Pen Drive", 1 },
                    { 5, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5002), null, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5003), "Courier", 1 },
                    { 6, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5004), null, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5005), "Cloud Drive", 1 },
                    { 7, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5007), null, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(5007), "Hard Disk", 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "PaymentMethod", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4854), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4856), "Cash", 1 },
                    { 2, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4858), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4859), "Bank Transfer", 1 },
                    { 3, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4860), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4861), "UPIPay", 1 },
                    { 4, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4862), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4863), "GooglePay", 1 },
                    { 5, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4864), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4865), "Bank Cheque", 1 },
                    { 6, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4866), new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4866), "PayTM", 1 }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "FixedCharge", "LastModifiedDate", "PreviousCharge", "ServiceName", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4783), "GST Monthly Submission", 500.0, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4787), 500.0, "GSTMonthlySubmission", 1 },
                    { 2, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4790), "GST Amendment", 500.0, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4790), 500.0, "GSTAmendment", 1 },
                    { 3, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4793), "GST Annual Return Filing", 1000.0, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4793), 1000.0, "GSTAnnualReturnFiling", 1 },
                    { 4, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4795), "GST Notice Service", 1000.0, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4796), 1000.0, "GSTNoticeService", 1 },
                    { 5, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4797), "Penalty while transporting", 1000.0, new DateTime(2023, 3, 5, 20, 41, 54, 745, DateTimeKind.Utc).AddTicks(4798), 1000.0, "PenaltyBySquad", 1 }
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
                name: "IX_ClientFeeMaps_ServiceCategoryId",
                table: "ClientFeeMaps",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionAndBalances_GSTClientId",
                table: "CollectionAndBalances",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTBillAndFeeCollections_GSTClientId",
                table: "GSTBillAndFeeCollections",
                column: "GSTClientId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTBillAndFeeCollections_GSTFilingTypeId",
                table: "GSTBillAndFeeCollections",
                column: "GSTFilingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GSTBillAndFeeCollections_ServiceCategoryId",
                table: "GSTBillAndFeeCollections",
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
                name: "CollectionAndBalances");

            migrationBuilder.DropTable(
                name: "GSTBillAndFeeCollections");

            migrationBuilder.DropTable(
                name: "GSTClientAddressExtensions");

            migrationBuilder.DropTable(
                name: "GSTPaidDetails");

            migrationBuilder.DropTable(
                name: "MultimediaTypes");

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
