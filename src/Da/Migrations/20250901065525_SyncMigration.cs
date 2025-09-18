using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Da.Migrations
{
    /// <inheritdoc />
    public partial class SyncMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.EnsureSchema(
                name: "products");

            migrationBuilder.EnsureSchema(
                name: "marketing");

            migrationBuilder.EnsureSchema(
                name: "customers");

            migrationBuilder.EnsureSchema(
                name: "inventory");

            migrationBuilder.EnsureSchema(
                name: "orders");

            migrationBuilder.EnsureSchema(
                name: "shipping");

            migrationBuilder.EnsureSchema(
                name: "payments");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolePermisstions = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    LastLogin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                name: "TbAddresses",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StreetAddress1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StreetAddress2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbAddresses_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbAttributes",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbAttributes_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbAuditLogs",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Entity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbAuditLogs_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbCampaignProductMappings",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_campaign_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCampaignProductMappings_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbCampaigns",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCampaigns_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbCategories",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InverseParentCategories_ParentCategory",
                        column: x => x.ParentCategoryId,
                        principalSchema: "products",
                        principalTable: "TbCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbCategories_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbDiscounts",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MaxUses = table.Column<int>(type: "int", nullable: true),
                    CurrentUses = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    MinOrderAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    IsSingleUse = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbDiscounts_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbLanguages",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbLanguages_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbMethods",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    CalculationMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbMethods_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProducts",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Length = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IsDigital = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    LowStockThreshold = table.Column<int>(type: "int", nullable: true, defaultValue: 5),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProducts_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbRefreshTokens",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbRefreshTokens_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbShoppingCarts",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbShoppingCarts_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbSuppliers",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbSuppliers_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbSupportTickets",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbSupportTickets_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbTags",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbTags_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbTaxRates",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    TaxName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbTaxRates_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbUserActivities",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Page = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbUserActivities_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbWishlists",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbWishlists_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbOrders",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    TotalAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    ShippingAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    DiscountAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderBillingAddresses_BillingAddress",
                        column: x => x.BillingAddressId,
                        principalSchema: "core",
                        principalTable: "TbAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderShippingAddresses_ShippingAddress",
                        column: x => x.ShippingAddressId,
                        principalSchema: "core",
                        principalTable: "TbAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbOrders_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbAttributeValues",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute_Value", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attribute",
                        column: x => x.AttributeId,
                        principalSchema: "products",
                        principalTable: "TbAttributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbAttributeValues_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbDiscountCategoryMappings",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_discount_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_Category",
                        column: x => x.CategoryId,
                        principalSchema: "products",
                        principalTable: "TbCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountCategories_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "marketing",
                        principalTable: "TbDiscounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbDiscountCategoryMappings_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbDiscountProductMappings",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_discount_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "marketing",
                        principalTable: "TbDiscounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbDiscountProductMapping_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbImages",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbImages_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProductCategoryMappings",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProductCategoryMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategoryMappings_Category",
                        column: x => x.CategoryId,
                        principalSchema: "products",
                        principalTable: "TbCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategoryMappings_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbProductCategoryMappings_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProductTranslationMappings",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslationMappings_Language",
                        column: x => x.LanguageId,
                        principalSchema: "core",
                        principalTable: "TbLanguages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTranslationMappings_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbProductTranslationMappings_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbReviews",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReviewDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbReviews_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbSeoMeta",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CanonicalUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSeoMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeoMeta_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbSeoMeta_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbSubscriptions",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NextBillingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbSubscriptions_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbVariations",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VariationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PriceAdjustment = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    StockQuantity = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbVariations_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Variations_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProductSuppliers",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    LeadTimeDays = table.Column<int>(type: "int", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProductSuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Supplier",
                        column: x => x.SupplierId,
                        principalSchema: "inventory",
                        principalTable: "TbSuppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbProductSuppliers_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbTicketReplies",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RepliedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbTicketReplies_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketReplies_Ticket",
                        column: x => x.TicketId,
                        principalSchema: "core",
                        principalTable: "TbSupportTickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProductTagMappings",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTagMappings_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTagMappings_Tag",
                        column: x => x.TagId,
                        principalSchema: "products",
                        principalTable: "TbTags",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbProductTagMappings_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbWishlistItems",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbWishlistItems_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WishlistItems_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WishlistItems_Wishlist",
                        column: x => x.WishlistId,
                        principalSchema: "customers",
                        principalTable: "TbWishlists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbInvoices",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IssuedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    TotalAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Order",
                        column: x => x.OrderId,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbInvoices_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbOrderStatusHistories",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatusHistories_Order",
                        column: x => x.OrderId,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbOrderStatusHistories_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbPayments",
                schema: "payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true, defaultValue: "USD"),
                    PaymentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    GatewayResponse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_BillingAddress",
                        column: x => x.BillingAddressId,
                        principalSchema: "core",
                        principalTable: "TbAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Order",
                        column: x => x.OrderId,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbPayments_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbShipments",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipmentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EstimatedDeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ActualDeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ShipmentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ShippingCost = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Order",
                        column: x => x.OrderId,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shipments_ShippingMethod",
                        column: x => x.ShippingMethodId,
                        principalSchema: "shipping",
                        principalTable: "TbMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbShipments_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbCartItems",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VariationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCartItems_Cart",
                        column: x => x.CartId,
                        principalSchema: "customers",
                        principalTable: "TbShoppingCarts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbCartItems_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbCartItems_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbCartItems_Variation",
                        column: x => x.VariationId,
                        principalSchema: "products",
                        principalTable: "TbVariations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbInventoryTransactions",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VariationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuantityChange = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Variation",
                        column: x => x.VariationId,
                        principalSchema: "products",
                        principalTable: "TbVariations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbInventoryTransactions_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbOrderItems",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VariationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    DiscountAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    ItemStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order",
                        column: x => x.OrderId,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Variation",
                        column: x => x.VariationId,
                        principalSchema: "products",
                        principalTable: "TbVariations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbOrderItems_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbVariationAttributeMappings",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VariationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariationAttributeMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbVariationAttributeMappings_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VariationAttributeMappings_Attribute",
                        column: x => x.AttributeId,
                        principalSchema: "products",
                        principalTable: "TbAttributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VariationAttributeMappings_Value",
                        column: x => x.ValueId,
                        principalSchema: "products",
                        principalTable: "TbAttributeValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VariationAttributeMappings_Variation",
                        column: x => x.VariationId,
                        principalSchema: "products",
                        principalTable: "TbVariations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbPaymentTransactions",
                schema: "payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    GatewayTransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResponseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ResponseMessage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Payment",
                        column: x => x.PaymentId,
                        principalSchema: "payments",
                        principalTable: "TbPayments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbPaymentTransactions_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbOrderReturns",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RequestedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ProcessedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderReturns_OrderItem",
                        column: x => x.OrderItemId,
                        principalSchema: "orders",
                        principalTable: "TbOrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbOrderReturns_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbShipmentItemMappings",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItemMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentItemMappings_OrderItem",
                        column: x => x.OrderItemId,
                        principalSchema: "orders",
                        principalTable: "TbOrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShipmentItemMappings_Shipment",
                        column: x => x.ShipmentId,
                        principalSchema: "shipping",
                        principalTable: "TbShipments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbShipmentItemMappings_UserUpdator",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TbAddresses_UpdatedBy",
                schema: "core",
                table: "TbAddresses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbAttributes_UpdatedBy",
                schema: "products",
                table: "TbAttributes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_AttributeName",
                schema: "products",
                table: "TbAttributes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbAttributeValues_UpdatedBy",
                schema: "products",
                table: "TbAttributeValues",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Attribute_&_Value",
                schema: "products",
                table: "TbAttributeValues",
                columns: new[] { "AttributeId", "Value" },
                unique: true,
                filter: "[AttributeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TbAuditLogs_UpdatedBy",
                schema: "core",
                table: "TbAuditLogs",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbCampaignProductMappings_UpdatedBy",
                schema: "marketing",
                table: "TbCampaignProductMappings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbCampaigns_UpdatedBy",
                schema: "marketing",
                table: "TbCampaigns",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbCartItems_CartId",
                schema: "customers",
                table: "TbCartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCartItems_ProductId",
                schema: "customers",
                table: "TbCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCartItems_UpdatedBy",
                schema: "customers",
                table: "TbCartItems",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbCartItems_VariationId",
                schema: "customers",
                table: "TbCartItems",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCategories_ParentCategoryId",
                schema: "products",
                table: "TbCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCategories_UpdatedBy",
                schema: "products",
                table: "TbCategories",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Category_Slug",
                schema: "products",
                table: "TbCategories",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_category_mapping_category_id",
                schema: "marketing",
                table: "TbDiscountCategoryMappings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_category_mapping_discount_id",
                schema: "marketing",
                table: "TbDiscountCategoryMappings",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_TbDiscountCategoryMappings_UpdatedBy",
                schema: "marketing",
                table: "TbDiscountCategoryMappings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_product_mapping_discount_id",
                schema: "marketing",
                table: "TbDiscountProductMappings",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_product_mapping_product_id",
                schema: "marketing",
                table: "TbDiscountProductMappings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbDiscountProductMappings_UpdatedBy",
                schema: "marketing",
                table: "TbDiscountProductMappings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbDiscounts_UpdatedBy",
                schema: "marketing",
                table: "TbDiscounts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Discount",
                schema: "marketing",
                table: "TbDiscounts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbImages_ProductId",
                schema: "products",
                table: "TbImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbImages_UpdatedBy",
                schema: "products",
                table: "TbImages",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbInventoryTransactions_ProductId",
                schema: "inventory",
                table: "TbInventoryTransactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbInventoryTransactions_UpdatedBy",
                schema: "inventory",
                table: "TbInventoryTransactions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbInventoryTransactions_VariationId",
                schema: "inventory",
                table: "TbInventoryTransactions",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_TbInvoices_OrderId",
                schema: "orders",
                table: "TbInvoices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TbInvoices_UpdatedBy",
                schema: "orders",
                table: "TbInvoices",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Invoices",
                schema: "orders",
                table: "TbInvoices",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbLanguages_UpdatedBy",
                schema: "core",
                table: "TbLanguages",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbMethods_UpdatedBy",
                schema: "shipping",
                table: "TbMethods",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItems_OrderId",
                schema: "orders",
                table: "TbOrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItems_ProductId",
                schema: "orders",
                table: "TbOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItems_UpdatedBy",
                schema: "orders",
                table: "TbOrderItems",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItems_VariationId",
                schema: "orders",
                table: "TbOrderItems",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_returns_order_item_id",
                schema: "orders",
                table: "TbOrderReturns",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderReturns_UpdatedBy",
                schema: "orders",
                table: "TbOrderReturns",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "idx_orders_user_id",
                schema: "orders",
                table: "TbOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrders_BillingAddressId",
                schema: "orders",
                table: "TbOrders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrders_ShippingAddressId",
                schema: "orders",
                table: "TbOrders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrders_UpdatedBy",
                schema: "orders",
                table: "TbOrders",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderStatusHistories_OrderId",
                schema: "orders",
                table: "TbOrderStatusHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderStatusHistories_UpdatedBy",
                schema: "orders",
                table: "TbOrderStatusHistories",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbPayments_BillingAddressId",
                schema: "payments",
                table: "TbPayments",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPayments_OrderId",
                schema: "payments",
                table: "TbPayments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPayments_UpdatedBy",
                schema: "payments",
                table: "TbPayments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbPaymentTransactions_PaymentId",
                schema: "payments",
                table: "TbPaymentTransactions",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPaymentTransactions_UpdatedBy",
                schema: "payments",
                table: "TbPaymentTransactions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductCategoryMappings_CategoryId",
                schema: "products",
                table: "TbProductCategoryMappings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductCategoryMappings_ProductId",
                schema: "products",
                table: "TbProductCategoryMappings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductCategoryMappings_UpdatedBy",
                schema: "products",
                table: "TbProductCategoryMappings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbProducts_UpdatedBy",
                schema: "products",
                table: "TbProducts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Product_Sku",
                schema: "products",
                table: "TbProducts",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbProductSuppliers_ProductId",
                schema: "inventory",
                table: "TbProductSuppliers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductSuppliers_SupplierId",
                schema: "inventory",
                table: "TbProductSuppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductSuppliers_UpdatedBy",
                schema: "inventory",
                table: "TbProductSuppliers",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_tag_mapping_product_id",
                schema: "products",
                table: "TbProductTagMappings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_tag_mapping_tag_id",
                schema: "products",
                table: "TbProductTagMappings",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductTagMappings_UpdatedBy",
                schema: "products",
                table: "TbProductTagMappings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_translation_mapping_language_id",
                schema: "products",
                table: "TbProductTranslationMappings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_translation_mapping_product_id",
                schema: "products",
                table: "TbProductTranslationMappings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductTranslationMappings_UpdatedBy",
                schema: "products",
                table: "TbProductTranslationMappings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbRefreshTokens_UpdatedBy",
                schema: "core",
                table: "TbRefreshTokens",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbReviews_ProductId",
                schema: "customers",
                table: "TbReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbReviews_UpdatedBy",
                schema: "customers",
                table: "TbReviews",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbSeoMeta_ProductId",
                schema: "products",
                table: "TbSeoMeta",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbSeoMeta_UpdatedBy",
                schema: "products",
                table: "TbSeoMeta",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shipment_item_mapping_order_item_id",
                schema: "shipping",
                table: "TbShipmentItemMappings",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shipment_item_mapping_shipment_id",
                schema: "shipping",
                table: "TbShipmentItemMappings",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TbShipmentItemMappings_UpdatedBy",
                schema: "shipping",
                table: "TbShipmentItemMappings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbShipments_OrderId",
                schema: "shipping",
                table: "TbShipments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TbShipments_ShippingMethodId",
                schema: "shipping",
                table: "TbShipments",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TbShipments_UpdatedBy",
                schema: "shipping",
                table: "TbShipments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbShoppingCarts_UpdatedBy",
                schema: "customers",
                table: "TbShoppingCarts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbSubscriptions_ProductId",
                schema: "orders",
                table: "TbSubscriptions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbSubscriptions_UpdatedBy",
                schema: "orders",
                table: "TbSubscriptions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbSuppliers_UpdatedBy",
                schema: "inventory",
                table: "TbSuppliers",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbSupportTickets_UpdatedBy",
                schema: "core",
                table: "TbSupportTickets",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbTags_UpdatedBy",
                schema: "products",
                table: "TbTags",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Tags",
                schema: "products",
                table: "TbTags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbTaxRates_UpdatedBy",
                schema: "marketing",
                table: "TbTaxRates",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbTicketReplies_TicketId",
                schema: "core",
                table: "TbTicketReplies",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTicketReplies_UpdatedBy",
                schema: "core",
                table: "TbTicketReplies",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbUserActivities_UpdatedBy",
                schema: "core",
                table: "TbUserActivities",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_attribute_id",
                schema: "products",
                table: "TbVariationAttributeMappings",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_value_id",
                schema: "products",
                table: "TbVariationAttributeMappings",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_variation_id",
                schema: "products",
                table: "TbVariationAttributeMappings",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_TbVariationAttributeMappings_UpdatedBy",
                schema: "products",
                table: "TbVariationAttributeMappings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbVariations_ProductId",
                schema: "products",
                table: "TbVariations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbVariations_UpdatedBy",
                schema: "products",
                table: "TbVariations",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Variation",
                schema: "products",
                table: "TbVariations",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbWishlistItems_ProductId",
                schema: "customers",
                table: "TbWishlistItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbWishlistItems_UpdatedBy",
                schema: "customers",
                table: "TbWishlistItems",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TbWishlistItems_WishlistId",
                schema: "customers",
                table: "TbWishlistItems",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_TbWishlists_UpdatedBy",
                schema: "customers",
                table: "TbWishlists",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "TbAuditLogs",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TbCampaignProductMappings",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "TbCampaigns",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "TbCartItems",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "TbDiscountCategoryMappings",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "TbDiscountProductMappings",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "TbImages",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbInventoryTransactions",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "TbInvoices",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "TbOrderReturns",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "TbOrderStatusHistories",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "TbPaymentTransactions",
                schema: "payments");

            migrationBuilder.DropTable(
                name: "TbProductCategoryMappings",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbProductSuppliers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "TbProductTagMappings",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbProductTranslationMappings",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbRefreshTokens",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TbReviews",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "TbSeoMeta",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbShipmentItemMappings",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "TbSubscriptions",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "TbTaxRates",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "TbTicketReplies",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TbUserActivities",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TbVariationAttributeMappings",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbWishlistItems",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TbShoppingCarts",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "TbDiscounts",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "TbPayments",
                schema: "payments");

            migrationBuilder.DropTable(
                name: "TbCategories",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbSuppliers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "TbTags",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbLanguages",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TbOrderItems",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "TbShipments",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "TbSupportTickets",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TbAttributeValues",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbWishlists",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "TbVariations",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbOrders",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "TbMethods",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "TbAttributes",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbProducts",
                schema: "products");

            migrationBuilder.DropTable(
                name: "TbAddresses",
                schema: "core");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
