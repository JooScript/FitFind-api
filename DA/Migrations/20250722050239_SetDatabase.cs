using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Da.Migrations
{
    /// <inheritdoc />
    public partial class SetDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "orders");

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
                name: "shipping");

            migrationBuilder.EnsureSchema(
                name: "payments");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastLogin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                name: "TbAttributes",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCampaignProductMappings",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_campaign_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCampaigns",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCategories",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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
                });

            migrationBuilder.CreateTable(
                name: "TbDiscounts",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MaxUses = table.Column<int>(type: "int", nullable: true),
                    CurrentUses = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    MinOrderAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsSingleUse = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbLanguages",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbMethods",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    cost = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    calculation_method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbProducts",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    cost_price = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    length = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    width = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    height = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    is_digital = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    stock_quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    low_stock_threshold = table.Column<int>(type: "int", nullable: true, defaultValue: 5),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__products__47027DF55CAF7E08", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbSuppliers",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contact_person = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__supplier__6EE594E818AE7C46", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTags",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tags__4296A2B658388606", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTaxRates",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    state = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    zip_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    rate = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    tax_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tax_rate__4B78B333FEE8F069", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AddressType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StreetAddress1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StreetAddress2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_User",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbAuditLogs",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    entity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntityId = table.Column<long>(type: "bigint", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    log_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_User",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbShoppingCarts",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    session_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__shopping__2EF52A2757A8E06B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__shopping___user___43D61337",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbSupportTickets",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__support___D596F96B0C17649A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__support_t__user___7A3223E8",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbUserActivities",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    page = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ip_address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_act__482FBD630BD37819", x => x.Id);
                    table.ForeignKey(
                        name: "FK__user_acti__user___04AFB25B",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbWishlists",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK__wishlists__user___395884C4",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbAttributeValues",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<long>(type: "bigint", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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
                });

            migrationBuilder.CreateTable(
                name: "TbDiscountCategoryMappings",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discount_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_discount_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK__discount___categ__2BFE89A6",
                        column: x => x.category_id,
                        principalSchema: "products",
                        principalTable: "TbCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__discount___disco__2B0A656D",
                        column: x => x.discount_id,
                        principalSchema: "marketing",
                        principalTable: "TbDiscounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbDiscountProductMappings",
                schema: "marketing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discount_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_discount_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK__discount___disco__2739D489",
                        column: x => x.discount_id,
                        principalSchema: "marketing",
                        principalTable: "TbDiscounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__discount___produ__282DF8C2",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbImages",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    image_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    is_primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__images__DC9AC955C10A25A0", x => x.Id);
                    table.ForeignKey(
                        name: "FK__images__product___59063A47",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProductCategoryMappings",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    is_primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProductCategoryMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK__product_c__categ__5535A963",
                        column: x => x.category_id,
                        principalSchema: "products",
                        principalTable: "TbCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__product_c__produ__5441852A",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProductTranslationMappings",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    language_id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK__product_t__produ__0B5CAFEA",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_product_translations_tb_languages",
                        column: x => x.language_id,
                        principalSchema: "core",
                        principalTable: "TbLanguages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbReviews",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    review_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    is_approved = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reviews__60883D90FEF6BE02", x => x.Id);
                    table.ForeignKey(
                        name: "FK__reviews__product__32AB8735",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__reviews__user_id__339FAB6E",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbSeoMata",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    meta_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    meta_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    meta_keywords = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    canonical_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSeoMata", x => x.Id);
                    table.ForeignKey(
                        name: "FK__seo_meta__produc__7755B73D",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbSubscriptions",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    frequency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    next_billing_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__subscrip__863A7EC1E33CC7B0", x => x.Id);
                    table.ForeignKey(
                        name: "FK__subscript__produ__16CE6296",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__subscript__user___15DA3E5D",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbVariations",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    variation_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price_adjustment = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    stock_quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__variatio__B03CFD0A4BE23787", x => x.Id);
                    table.ForeignKey(
                        name: "FK__variation__produ__5EBF139D",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProductSuppliers",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    cost_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    lead_time_days = table.Column<int>(type: "int", nullable: true),
                    is_primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProductSuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK__product_s__produ__57DD0BE4",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__product_s__suppl__58D1301D",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "TbSuppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbProductTagMappings",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    tag_id = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK__product_t__produ__73852659",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__product_t__tag_i__74794A92",
                        column: x => x.tag_id,
                        principalSchema: "products",
                        principalTable: "TbTags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbOrders",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    order_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    order_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    order_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    total_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    shipping_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    discount_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    payment_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    shipping_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    billing_address_id = table.Column<long>(type: "bigint", nullable: true),
                    shipping_address_id = table.Column<long>(type: "bigint", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__4659622900F7E894", x => x.Id);
                    table.ForeignKey(
                        name: "FK__orders__billing___778AC167",
                        column: x => x.billing_address_id,
                        principalSchema: "core",
                        principalTable: "TbAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__orders__shipping__787EE5A0",
                        column: x => x.shipping_address_id,
                        principalSchema: "core",
                        principalTable: "TbAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__orders__user_id__71D1E811",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbTicketReplies",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticket_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    replied_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ticket_r__EE405698DE1279BE", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ticket_re__ticke__7FEAFD3E",
                        column: x => x.ticket_id,
                        principalSchema: "core",
                        principalTable: "TbSupportTickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ticket_re__user___00DF2177",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbWishlistItems",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wishlist_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    added_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Wishlist",
                        column: x => x.wishlist_id,
                        principalSchema: "customers",
                        principalTable: "TbWishlists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__wishlist___produ__40058253",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbCartItems",
                schema: "customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    VariationId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AddedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart",
                        column: x => x.CartId,
                        principalSchema: "customers",
                        principalTable: "TbShoppingCarts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Product",
                        column: x => x.ProductId,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Variation",
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    variation_id = table.Column<long>(type: "bigint", nullable: true),
                    quantity_change = table.Column<int>(type: "int", nullable: false),
                    transaction_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    reference_id = table.Column<long>(type: "bigint", nullable: true),
                    reference_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    transaction_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__85C600AF8DFDE60A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__inventory__produ__4E53A1AA",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__inventory__user___5224328E",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__inventory__varia__4F47C5E3",
                        column: x => x.variation_id,
                        principalSchema: "products",
                        principalTable: "TbVariations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbVariationAttributeMappings",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    variation_id = table.Column<long>(type: "bigint", nullable: false),
                    attribute_id = table.Column<long>(type: "bigint", nullable: false),
                    value_id = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_variation_attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK__variation__attri__6D0D32F4",
                        column: x => x.attribute_id,
                        principalSchema: "products",
                        principalTable: "TbAttributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__variation__value__6E01572D",
                        column: x => x.value_id,
                        principalSchema: "products",
                        principalTable: "TbAttributeValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__variation__varia__6C190EBB",
                        column: x => x.variation_id,
                        principalSchema: "products",
                        principalTable: "TbVariations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_invoices",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    invoice_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    issued_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    total_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    due_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__invoices__F58DFD49D1BB3566", x => x.Id);
                    table.ForeignKey(
                        name: "FK__invoices__order___6CD828CA",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbOrderItems",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    variation_id = table.Column<long>(type: "bigint", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    discount_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    item_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_it__3764B6BCBA7EA358", x => x.Id);
                    table.ForeignKey(
                        name: "FK__order_ite__order__7B5B524B",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__order_ite__produ__7C4F7684",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "TbProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__order_ite__varia__7D439ABD",
                        column: x => x.variation_id,
                        principalSchema: "products",
                        principalTable: "TbVariations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbOrderStatusHistories",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    status_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_st__096AA2E90118DDC9", x => x.Id);
                    table.ForeignKey(
                        name: "FK__order_sta__order__02FC7413",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__order_sta__user___04E4BC85",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbPayments",
                schema: "payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    payment_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    transaction_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true, defaultValue: "USD"),
                    payment_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    payment_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    gateway_response = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    billing_address_id = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__payments__ED1FC9EA68D0DEAF", x => x.Id);
                    table.ForeignKey(
                        name: "FK__payments__billin__0B91BA14",
                        column: x => x.billing_address_id,
                        principalSchema: "core",
                        principalTable: "TbAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__payments__order___07C12930",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbShipments",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    shipping_method_id = table.Column<long>(type: "bigint", nullable: true),
                    tracking_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    carrier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    shipment_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    estimated_delivery_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    actual_delivery_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    shipment_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    shipping_cost = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__shipment__41466E5962A3E801", x => x.Id);
                    table.ForeignKey(
                        name: "FK__shipments__order__17036CC0",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "TbOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__shipments__shipp__17F790F9",
                        column: x => x.shipping_method_id,
                        principalSchema: "shipping",
                        principalTable: "TbMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbOrderReturns",
                schema: "orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    requested_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    processed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__returns__35C23473EFD75761", x => x.Id);
                    table.ForeignKey(
                        name: "FK__returns__order_i__671F4F74",
                        column: x => x.order_item_id,
                        principalSchema: "orders",
                        principalTable: "TbOrderItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbPaymentTransactions",
                schema: "payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_id = table.Column<long>(type: "bigint", nullable: true),
                    transaction_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    transaction_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    gateway_transaction_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    response_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    response_message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__payment___85C600AFA1BB98D9", x => x.Id);
                    table.ForeignKey(
                        name: "FK__payment_t__payme__0E6E26BF",
                        column: x => x.payment_id,
                        principalSchema: "payments",
                        principalTable: "TbPayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbShipmentItemMappings",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shipment_id = table.Column<long>(type: "bigint", nullable: true),
                    order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__shipment__731D6A95F9E9C668", x => x.Id);
                    table.ForeignKey(
                        name: "FK__shipment___order__1CBC4616",
                        column: x => x.order_item_id,
                        principalSchema: "orders",
                        principalTable: "TbOrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__shipment___shipm__1BC821DD",
                        column: x => x.shipment_id,
                        principalSchema: "shipping",
                        principalTable: "TbShipments",
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
                name: "IX_tb_invoices_order_id",
                schema: "orders",
                table: "tb_invoices",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "UQ__invoices__8081A63AF3DA1EA1",
                schema: "orders",
                table: "tb_invoices",
                column: "invoice_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbAddresses_UserId",
                schema: "core",
                table: "TbAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_AttributeName",
                schema: "products",
                table: "TbAttributes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Attribute_&_Value",
                schema: "products",
                table: "TbAttributeValues",
                columns: new[] { "AttributeId", "Value" },
                unique: true,
                filter: "[AttributeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TbAuditLogs_UserId",
                schema: "core",
                table: "TbAuditLogs",
                column: "UserId");

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
                name: "UQ_Category_Slug",
                schema: "products",
                table: "TbCategories",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_category_mapping_category_id",
                schema: "marketing",
                table: "TbDiscountCategoryMappings",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_category_mapping_discount_id",
                schema: "marketing",
                table: "TbDiscountCategoryMappings",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_product_mapping_discount_id",
                schema: "marketing",
                table: "TbDiscountProductMappings",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_product_mapping_product_id",
                schema: "marketing",
                table: "TbDiscountProductMappings",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "UQ_Discount",
                schema: "marketing",
                table: "TbDiscounts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbImages_product_id",
                schema: "products",
                table: "TbImages",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbInventoryTransactions_product_id",
                schema: "inventory",
                table: "TbInventoryTransactions",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbInventoryTransactions_user_id",
                schema: "inventory",
                table: "TbInventoryTransactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbInventoryTransactions_variation_id",
                schema: "inventory",
                table: "TbInventoryTransactions",
                column: "variation_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItems_order_id",
                schema: "orders",
                table: "TbOrderItems",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItems_product_id",
                schema: "orders",
                table: "TbOrderItems",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItems_variation_id",
                schema: "orders",
                table: "TbOrderItems",
                column: "variation_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_returns_order_item_id",
                schema: "orders",
                table: "TbOrderReturns",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "idx_orders_user_id",
                schema: "orders",
                table: "TbOrders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrders_billing_address_id",
                schema: "orders",
                table: "TbOrders",
                column: "billing_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrders_shipping_address_id",
                schema: "orders",
                table: "TbOrders",
                column: "shipping_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderStatusHistories_order_id",
                schema: "orders",
                table: "TbOrderStatusHistories",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderStatusHistories_user_id",
                schema: "orders",
                table: "TbOrderStatusHistories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbPayments_billing_address_id",
                schema: "payments",
                table: "TbPayments",
                column: "billing_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbPayments_order_id",
                schema: "payments",
                table: "TbPayments",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbPaymentTransactions_payment_id",
                schema: "payments",
                table: "TbPaymentTransactions",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductCategoryMappings_category_id",
                schema: "products",
                table: "TbProductCategoryMappings",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductCategoryMappings_product_id",
                schema: "products",
                table: "TbProductCategoryMappings",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "UQ__products__DDDF4BE71C9483E5",
                schema: "products",
                table: "TbProducts",
                column: "sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbProductSuppliers_product_id",
                schema: "inventory",
                table: "TbProductSuppliers",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductSuppliers_supplier_id",
                schema: "inventory",
                table: "TbProductSuppliers",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_tag_mapping_product_id",
                schema: "products",
                table: "TbProductTagMappings",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_tag_mapping_tag_id",
                schema: "products",
                table: "TbProductTagMappings",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_translation_mapping_language_id",
                schema: "products",
                table: "TbProductTranslationMappings",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_translation_mapping_product_id",
                schema: "products",
                table: "TbProductTranslationMappings",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbReviews_product_id",
                schema: "customers",
                table: "TbReviews",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbReviews_user_id",
                schema: "customers",
                table: "TbReviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbSeoMata_product_id",
                schema: "products",
                table: "TbSeoMata",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shipment_item_mapping_order_item_id",
                schema: "shipping",
                table: "TbShipmentItemMappings",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shipment_item_mapping_shipment_id",
                schema: "shipping",
                table: "TbShipmentItemMappings",
                column: "shipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbShipments_order_id",
                schema: "shipping",
                table: "TbShipments",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbShipments_shipping_method_id",
                schema: "shipping",
                table: "TbShipments",
                column: "shipping_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbShoppingCarts_user_id",
                schema: "customers",
                table: "TbShoppingCarts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbSubscriptions_product_id",
                schema: "orders",
                table: "TbSubscriptions",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbSubscriptions_user_id",
                schema: "orders",
                table: "TbSubscriptions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbSupportTickets_user_id",
                schema: "core",
                table: "TbSupportTickets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__tags__72E12F1BCC2F292B",
                schema: "products",
                table: "TbTags",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbTicketReplies_ticket_id",
                schema: "core",
                table: "TbTicketReplies",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbTicketReplies_user_id",
                schema: "core",
                table: "TbTicketReplies",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbUserActivities_user_id",
                schema: "core",
                table: "TbUserActivities",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_attribute_id",
                schema: "products",
                table: "TbVariationAttributeMappings",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_value_id",
                schema: "products",
                table: "TbVariationAttributeMappings",
                column: "value_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_variation_id",
                schema: "products",
                table: "TbVariationAttributeMappings",
                column: "variation_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbVariations_product_id",
                schema: "products",
                table: "TbVariations",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "UQ__variatio__DDDF4BE785394C8E",
                schema: "products",
                table: "TbVariations",
                column: "sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbWishlistItems_product_id",
                schema: "customers",
                table: "TbWishlistItems",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbWishlistItems_wishlist_id",
                schema: "customers",
                table: "TbWishlistItems",
                column: "wishlist_id");

            migrationBuilder.CreateIndex(
                name: "IX_TbWishlists_user_id",
                schema: "customers",
                table: "TbWishlists",
                column: "user_id");
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
                name: "tb_invoices",
                schema: "orders");

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
                name: "TbReviews",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "TbSeoMata",
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
