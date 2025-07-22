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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "tb_attributes",
                schema: "products",
                columns: table => new
                {
                    attribute_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__attribut__9090C9BBAEFEABF2", x => x.attribute_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_campaign_product_mapping",
                schema: "marketing",
                columns: table => new
                {
                    map_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    campaign_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_campaign_products", x => x.map_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_campaigns",
                schema: "marketing",
                columns: table => new
                {
                    campaign_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    start_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    end_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__campaign__905B681C045B3BBF", x => x.campaign_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_categories",
                schema: "products",
                columns: table => new
                {
                    category_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_category_id = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    display_order = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__D54EE9B4C62CF89D", x => x.category_id);
                    table.ForeignKey(
                        name: "FK__categorie__paren__4F7CD00D",
                        column: x => x.parent_category_id,
                        principalSchema: "products",
                        principalTable: "tb_categories",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_discounts",
                schema: "marketing",
                columns: table => new
                {
                    discount_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discount_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    max_uses = table.Column<int>(type: "int", nullable: true),
                    current_uses = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    min_order_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    is_single_use = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__discount__BDBE9EF982722213", x => x.discount_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_languages",
                schema: "core",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_languages", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_methods",
                schema: "shipping",
                columns: table => new
                {
                    method_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    cost = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    calculation_method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__methods__747727B64ECA9ED8", x => x.method_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_products",
                schema: "products",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__products__47027DF55CAF7E08", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_suppliers",
                schema: "inventory",
                columns: table => new
                {
                    supplier_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contact_person = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__supplier__6EE594E818AE7C46", x => x.supplier_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tags",
                schema: "products",
                columns: table => new
                {
                    tag_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tags__4296A2B658388606", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tax_rates",
                schema: "marketing",
                columns: table => new
                {
                    tax_rate_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    state = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    zip_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    rate = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    tax_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tax_rate__4B78B333FEE8F069", x => x.tax_rate_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                schema: "core",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__B9BE370F80EEC35F", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "tb_audit_logs",
                schema: "core",
                columns: table => new
                {
                    log_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    entity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    entity_id = table.Column<long>(type: "bigint", nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    log_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__audit_lo__9E2397E06E29CF01", x => x.log_id);
                    table.ForeignKey(
                        name: "FK__audit_log__user___5CA1C101",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_attribute_values",
                schema: "products",
                columns: table => new
                {
                    value_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attribute_id = table.Column<long>(type: "bigint", nullable: true),
                    value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    display_order = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__attribut__0FECE282EA1B05B9", x => x.value_id);
                    table.ForeignKey(
                        name: "FK__attribute__attri__68487DD7",
                        column: x => x.attribute_id,
                        principalSchema: "products",
                        principalTable: "tb_attributes",
                        principalColumn: "attribute_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_discount_category_mapping",
                schema: "marketing",
                columns: table => new
                {
                    map_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discount_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_discount_categories", x => x.map_id);
                    table.ForeignKey(
                        name: "FK__discount___categ__2BFE89A6",
                        column: x => x.category_id,
                        principalSchema: "products",
                        principalTable: "tb_categories",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK__discount___disco__2B0A656D",
                        column: x => x.discount_id,
                        principalSchema: "marketing",
                        principalTable: "tb_discounts",
                        principalColumn: "discount_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_discount_product_mapping",
                schema: "marketing",
                columns: table => new
                {
                    map_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discount_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_discount_products", x => x.map_id);
                    table.ForeignKey(
                        name: "FK__discount___disco__2739D489",
                        column: x => x.discount_id,
                        principalSchema: "marketing",
                        principalTable: "tb_discounts",
                        principalColumn: "discount_id");
                    table.ForeignKey(
                        name: "FK__discount___produ__282DF8C2",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_images",
                schema: "products",
                columns: table => new
                {
                    image_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    image_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    alt_text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    display_order = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    is_primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__images__DC9AC955C10A25A0", x => x.image_id);
                    table.ForeignKey(
                        name: "FK__images__product___59063A47",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_product_category_mapping",
                schema: "products",
                columns: table => new
                {
                    map_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    is_primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_category_mapping", x => x.map_id);
                    table.ForeignKey(
                        name: "FK__product_c__categ__5535A963",
                        column: x => x.category_id,
                        principalSchema: "products",
                        principalTable: "tb_categories",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK__product_c__produ__5441852A",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_product_translation_mapping",
                schema: "products",
                columns: table => new
                {
                    map_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    language_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_translations", x => x.map_id);
                    table.ForeignKey(
                        name: "FK__product_t__produ__0B5CAFEA",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_tb_product_translations_tb_languages",
                        column: x => x.language_id,
                        principalSchema: "core",
                        principalTable: "tb_languages",
                        principalColumn: "language_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_seo_meta",
                schema: "products",
                columns: table => new
                {
                    mata_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    meta_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    meta_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    meta_keywords = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    canonical_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_seo_meta", x => x.mata_id);
                    table.ForeignKey(
                        name: "FK__seo_meta__produc__7755B73D",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_variations",
                schema: "products",
                columns: table => new
                {
                    variation_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    variation_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price_adjustment = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    stock_quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__variatio__B03CFD0A4BE23787", x => x.variation_id);
                    table.ForeignKey(
                        name: "FK__variation__produ__5EBF139D",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_product_suppliers",
                schema: "inventory",
                columns: table => new
                {
                    mapping_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    cost_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    lead_time_days = table.Column<int>(type: "int", nullable: true),
                    is_primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_suppliers", x => x.mapping_id);
                    table.ForeignKey(
                        name: "FK__product_s__produ__57DD0BE4",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__product_s__suppl__58D1301D",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "tb_suppliers",
                        principalColumn: "supplier_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_product_tag_mapping",
                schema: "products",
                columns: table => new
                {
                    map_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    tag_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_tags", x => x.map_id);
                    table.ForeignKey(
                        name: "FK__product_t__produ__73852659",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__product_t__tag_i__74794A92",
                        column: x => x.tag_id,
                        principalSchema: "products",
                        principalTable: "tb_tags",
                        principalColumn: "tag_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_addresses",
                schema: "core",
                columns: table => new
                {
                    address_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    address_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    street_address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    street_address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__addresse__CAA247C8CD4648FA", x => x.address_id);
                    table.ForeignKey(
                        name: "FK__addresses__user___3F466844",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_reviews",
                schema: "customers",
                columns: table => new
                {
                    review_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    review_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    is_approved = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reviews__60883D90FEF6BE02", x => x.review_id);
                    table.ForeignKey(
                        name: "FK__reviews__product__32AB8735",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__reviews__user_id__339FAB6E",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_shopping_carts",
                schema: "customers",
                columns: table => new
                {
                    cart_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    session_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__shopping__2EF52A2757A8E06B", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK__shopping___user___43D61337",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_subscriptions",
                schema: "orders",
                columns: table => new
                {
                    subscription_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    frequency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    next_billing_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__subscrip__863A7EC1E33CC7B0", x => x.subscription_id);
                    table.ForeignKey(
                        name: "FK__subscript__produ__16CE6296",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__subscript__user___15DA3E5D",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_support_tickets",
                schema: "core",
                columns: table => new
                {
                    ticket_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__support___D596F96B0C17649A", x => x.ticket_id);
                    table.ForeignKey(
                        name: "FK__support_t__user___7A3223E8",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_user_activity",
                schema: "core",
                columns: table => new
                {
                    activity_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    page = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ip_address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_act__482FBD630BD37819", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK__user_acti__user___04AFB25B",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_wishlists",
                schema: "customers",
                columns: table => new
                {
                    wishlist_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__wishlist__6151514EE2BABB5A", x => x.wishlist_id);
                    table.ForeignKey(
                        name: "FK__wishlists__user___395884C4",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_inventory_transactions",
                schema: "inventory",
                columns: table => new
                {
                    transaction_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    variation_id = table.Column<long>(type: "bigint", nullable: true),
                    quantity_change = table.Column<int>(type: "int", nullable: false),
                    transaction_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    reference_id = table.Column<long>(type: "bigint", nullable: true),
                    reference_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    transaction_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__85C600AF8DFDE60A", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK__inventory__produ__4E53A1AA",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__inventory__user___5224328E",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__inventory__varia__4F47C5E3",
                        column: x => x.variation_id,
                        principalSchema: "products",
                        principalTable: "tb_variations",
                        principalColumn: "variation_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_variation_attribute_mapping",
                schema: "products",
                columns: table => new
                {
                    map_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    variation_id = table.Column<long>(type: "bigint", nullable: false),
                    attribute_id = table.Column<long>(type: "bigint", nullable: false),
                    value_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_variation_attributes", x => x.map_id);
                    table.ForeignKey(
                        name: "FK__variation__attri__6D0D32F4",
                        column: x => x.attribute_id,
                        principalSchema: "products",
                        principalTable: "tb_attributes",
                        principalColumn: "attribute_id");
                    table.ForeignKey(
                        name: "FK__variation__value__6E01572D",
                        column: x => x.value_id,
                        principalSchema: "products",
                        principalTable: "tb_attribute_values",
                        principalColumn: "value_id");
                    table.ForeignKey(
                        name: "FK__variation__varia__6C190EBB",
                        column: x => x.variation_id,
                        principalSchema: "products",
                        principalTable: "tb_variations",
                        principalColumn: "variation_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_orders",
                schema: "orders",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
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
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__4659622900F7E894", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__orders__billing___778AC167",
                        column: x => x.billing_address_id,
                        principalSchema: "core",
                        principalTable: "tb_addresses",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK__orders__shipping__787EE5A0",
                        column: x => x.shipping_address_id,
                        principalSchema: "core",
                        principalTable: "tb_addresses",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK__orders__user_id__71D1E811",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_cart_items",
                schema: "customers",
                columns: table => new
                {
                    cart_item_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cart_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    variation_id = table.Column<long>(type: "bigint", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    added_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cart_ite__5D9A6C6E8C2E26CA", x => x.cart_item_id);
                    table.ForeignKey(
                        name: "FK__cart_item__cart___489AC854",
                        column: x => x.cart_id,
                        principalSchema: "customers",
                        principalTable: "tb_shopping_carts",
                        principalColumn: "cart_id");
                    table.ForeignKey(
                        name: "FK__cart_item__produ__498EEC8D",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__cart_item__varia__4A8310C6",
                        column: x => x.variation_id,
                        principalSchema: "products",
                        principalTable: "tb_variations",
                        principalColumn: "variation_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_ticket_replies",
                schema: "core",
                columns: table => new
                {
                    reply_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticket_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    replied_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ticket_r__EE405698DE1279BE", x => x.reply_id);
                    table.ForeignKey(
                        name: "FK__ticket_re__ticke__7FEAFD3E",
                        column: x => x.ticket_id,
                        principalSchema: "core",
                        principalTable: "tb_support_tickets",
                        principalColumn: "ticket_id");
                    table.ForeignKey(
                        name: "FK__ticket_re__user___00DF2177",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_wishlist_items",
                schema: "customers",
                columns: table => new
                {
                    wishlist_item_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wishlist_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    added_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__wishlist__190EBE28182ABD3C", x => x.wishlist_item_id);
                    table.ForeignKey(
                        name: "FK__wishlist___produ__40058253",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__wishlist___wishl__3F115E1A",
                        column: x => x.wishlist_id,
                        principalSchema: "customers",
                        principalTable: "tb_wishlists",
                        principalColumn: "wishlist_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_invoices",
                schema: "orders",
                columns: table => new
                {
                    invoice_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    invoice_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    issued_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    total_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    due_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__invoices__F58DFD49D1BB3566", x => x.invoice_id);
                    table.ForeignKey(
                        name: "FK__invoices__order___6CD828CA",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "tb_orders",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_order_items",
                schema: "orders",
                columns: table => new
                {
                    order_item_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    variation_id = table.Column<long>(type: "bigint", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    discount_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0.00m),
                    item_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_it__3764B6BCBA7EA358", x => x.order_item_id);
                    table.ForeignKey(
                        name: "FK__order_ite__order__7B5B524B",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "tb_orders",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK__order_ite__produ__7C4F7684",
                        column: x => x.product_id,
                        principalSchema: "products",
                        principalTable: "tb_products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__order_ite__varia__7D439ABD",
                        column: x => x.variation_id,
                        principalSchema: "products",
                        principalTable: "tb_variations",
                        principalColumn: "variation_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_order_status_history",
                schema: "orders",
                columns: table => new
                {
                    history_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    status_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_st__096AA2E90118DDC9", x => x.history_id);
                    table.ForeignKey(
                        name: "FK__order_sta__order__02FC7413",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "tb_orders",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK__order_sta__user___04E4BC85",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_payments",
                schema: "payments",
                columns: table => new
                {
                    payment_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    payment_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    transaction_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true, defaultValue: "USD"),
                    payment_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    payment_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    gateway_response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billing_address_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__payments__ED1FC9EA68D0DEAF", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK__payments__billin__0B91BA14",
                        column: x => x.billing_address_id,
                        principalSchema: "core",
                        principalTable: "tb_addresses",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK__payments__order___07C12930",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "tb_orders",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_shipments",
                schema: "shipping",
                columns: table => new
                {
                    shipment_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    shipping_method_id = table.Column<long>(type: "bigint", nullable: true),
                    tracking_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    carrier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    shipment_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    estimated_delivery_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    actual_delivery_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    shipment_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    shipping_cost = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__shipment__41466E5962A3E801", x => x.shipment_id);
                    table.ForeignKey(
                        name: "FK__shipments__order__17036CC0",
                        column: x => x.order_id,
                        principalSchema: "orders",
                        principalTable: "tb_orders",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK__shipments__shipp__17F790F9",
                        column: x => x.shipping_method_id,
                        principalSchema: "shipping",
                        principalTable: "tb_methods",
                        principalColumn: "method_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_order_returns",
                schema: "orders",
                columns: table => new
                {
                    order_return_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    requested_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    processed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__returns__35C23473EFD75761", x => x.order_return_id);
                    table.ForeignKey(
                        name: "FK__returns__order_i__671F4F74",
                        column: x => x.order_item_id,
                        principalSchema: "orders",
                        principalTable: "tb_order_items",
                        principalColumn: "order_item_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_payment_transactions",
                schema: "payments",
                columns: table => new
                {
                    transaction_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_id = table.Column<long>(type: "bigint", nullable: true),
                    transaction_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    transaction_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    gateway_transaction_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    response_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    response_message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__payment___85C600AFA1BB98D9", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK__payment_t__payme__0E6E26BF",
                        column: x => x.payment_id,
                        principalSchema: "payments",
                        principalTable: "tb_payments",
                        principalColumn: "payment_id");
                });

            migrationBuilder.CreateTable(
                name: "tb_shipment_item_mapping",
                schema: "shipping",
                columns: table => new
                {
                    map_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shipment_id = table.Column<long>(type: "bigint", nullable: true),
                    order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__shipment__731D6A95F9E9C668", x => x.map_id);
                    table.ForeignKey(
                        name: "FK__shipment___order__1CBC4616",
                        column: x => x.order_item_id,
                        principalSchema: "orders",
                        principalTable: "tb_order_items",
                        principalColumn: "order_item_id");
                    table.ForeignKey(
                        name: "FK__shipment___shipm__1BC821DD",
                        column: x => x.shipment_id,
                        principalSchema: "shipping",
                        principalTable: "tb_shipments",
                        principalColumn: "shipment_id");
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
                name: "IX_tb_addresses_user_id",
                schema: "core",
                table: "tb_addresses",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__attribut__349B7719F5AE74B6",
                schema: "products",
                table: "tb_attribute_values",
                columns: new[] { "attribute_id", "value" },
                unique: true,
                filter: "[attribute_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__attribut__72E12F1BA0F7CAC6",
                schema: "products",
                table: "tb_attributes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_audit_logs_user_id",
                schema: "core",
                table: "tb_audit_logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_items_cart_id",
                schema: "customers",
                table: "tb_cart_items",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_items_product_id",
                schema: "customers",
                table: "tb_cart_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_items_variation_id",
                schema: "customers",
                table: "tb_cart_items",
                column: "variation_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_categories_parent_category_id",
                schema: "products",
                table: "tb_categories",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "UQ__categori__32DD1E4C64DBC541",
                schema: "products",
                table: "tb_categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_category_mapping_category_id",
                schema: "marketing",
                table: "tb_discount_category_mapping",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_category_mapping_discount_id",
                schema: "marketing",
                table: "tb_discount_category_mapping",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_product_mapping_discount_id",
                schema: "marketing",
                table: "tb_discount_product_mapping",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_discount_product_mapping_product_id",
                schema: "marketing",
                table: "tb_discount_product_mapping",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "UQ__discount__357D4CF90697B0D5",
                schema: "marketing",
                table: "tb_discounts",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_images_product_id",
                schema: "products",
                table: "tb_images",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_inventory_transactions_product_id",
                schema: "inventory",
                table: "tb_inventory_transactions",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_inventory_transactions_user_id",
                schema: "inventory",
                table: "tb_inventory_transactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_inventory_transactions_variation_id",
                schema: "inventory",
                table: "tb_inventory_transactions",
                column: "variation_id");

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
                name: "IX_tb_order_items_order_id",
                schema: "orders",
                table: "tb_order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_items_product_id",
                schema: "orders",
                table: "tb_order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_items_variation_id",
                schema: "orders",
                table: "tb_order_items",
                column: "variation_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_returns_order_item_id",
                schema: "orders",
                table: "tb_order_returns",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_status_history_order_id",
                schema: "orders",
                table: "tb_order_status_history",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_status_history_user_id",
                schema: "orders",
                table: "tb_order_status_history",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_orders_user_id",
                schema: "orders",
                table: "tb_orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orders_billing_address_id",
                schema: "orders",
                table: "tb_orders",
                column: "billing_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orders_shipping_address_id",
                schema: "orders",
                table: "tb_orders",
                column: "shipping_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_payment_transactions_payment_id",
                schema: "payments",
                table: "tb_payment_transactions",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_payments_billing_address_id",
                schema: "payments",
                table: "tb_payments",
                column: "billing_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_payments_order_id",
                schema: "payments",
                table: "tb_payments",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_category_mapping_category_id",
                schema: "products",
                table: "tb_product_category_mapping",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_category_mapping_product_id",
                schema: "products",
                table: "tb_product_category_mapping",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_suppliers_product_id",
                schema: "inventory",
                table: "tb_product_suppliers",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_suppliers_supplier_id",
                schema: "inventory",
                table: "tb_product_suppliers",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_tag_mapping_product_id",
                schema: "products",
                table: "tb_product_tag_mapping",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_tag_mapping_tag_id",
                schema: "products",
                table: "tb_product_tag_mapping",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_translation_mapping_language_id",
                schema: "products",
                table: "tb_product_translation_mapping",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_translation_mapping_product_id",
                schema: "products",
                table: "tb_product_translation_mapping",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "UQ__products__DDDF4BE71C9483E5",
                schema: "products",
                table: "tb_products",
                column: "sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_reviews_product_id",
                schema: "customers",
                table: "tb_reviews",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reviews_user_id",
                schema: "customers",
                table: "tb_reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_seo_meta_product_id",
                schema: "products",
                table: "tb_seo_meta",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shipment_item_mapping_order_item_id",
                schema: "shipping",
                table: "tb_shipment_item_mapping",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shipment_item_mapping_shipment_id",
                schema: "shipping",
                table: "tb_shipment_item_mapping",
                column: "shipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shipments_order_id",
                schema: "shipping",
                table: "tb_shipments",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shipments_shipping_method_id",
                schema: "shipping",
                table: "tb_shipments",
                column: "shipping_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_shopping_carts_user_id",
                schema: "customers",
                table: "tb_shopping_carts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_subscriptions_product_id",
                schema: "orders",
                table: "tb_subscriptions",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_subscriptions_user_id",
                schema: "orders",
                table: "tb_subscriptions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_support_tickets_user_id",
                schema: "core",
                table: "tb_support_tickets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__tags__72E12F1BCC2F292B",
                schema: "products",
                table: "tb_tags",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_ticket_replies_ticket_id",
                schema: "core",
                table: "tb_ticket_replies",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ticket_replies_user_id",
                schema: "core",
                table: "tb_ticket_replies",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_activity_user_id",
                schema: "core",
                table: "tb_user_activity",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_attribute_id",
                schema: "products",
                table: "tb_variation_attribute_mapping",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_value_id",
                schema: "products",
                table: "tb_variation_attribute_mapping",
                column: "value_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variation_attribute_mapping_variation_id",
                schema: "products",
                table: "tb_variation_attribute_mapping",
                column: "variation_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variations_product_id",
                schema: "products",
                table: "tb_variations",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "UQ__variatio__DDDF4BE785394C8E",
                schema: "products",
                table: "tb_variations",
                column: "sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_wishlist_items_product_id",
                schema: "customers",
                table: "tb_wishlist_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_wishlist_items_wishlist_id",
                schema: "customers",
                table: "tb_wishlist_items",
                column: "wishlist_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_wishlists_user_id",
                schema: "customers",
                table: "tb_wishlists",
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
                name: "tb_audit_logs",
                schema: "core");

            migrationBuilder.DropTable(
                name: "tb_campaign_product_mapping",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "tb_campaigns",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "tb_cart_items",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "tb_discount_category_mapping",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "tb_discount_product_mapping",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "tb_images",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_inventory_transactions",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "tb_invoices",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "tb_order_returns",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "tb_order_status_history",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "tb_payment_transactions",
                schema: "payments");

            migrationBuilder.DropTable(
                name: "tb_product_category_mapping",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_product_suppliers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "tb_product_tag_mapping",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_product_translation_mapping",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_reviews",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "tb_seo_meta",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_shipment_item_mapping",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "tb_subscriptions",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "tb_tax_rates",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "tb_ticket_replies",
                schema: "core");

            migrationBuilder.DropTable(
                name: "tb_user_activity",
                schema: "core");

            migrationBuilder.DropTable(
                name: "tb_variation_attribute_mapping",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_wishlist_items",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tb_shopping_carts",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "tb_discounts",
                schema: "marketing");

            migrationBuilder.DropTable(
                name: "tb_payments",
                schema: "payments");

            migrationBuilder.DropTable(
                name: "tb_categories",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_suppliers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "tb_tags",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_languages",
                schema: "core");

            migrationBuilder.DropTable(
                name: "tb_order_items",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "tb_shipments",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "tb_support_tickets",
                schema: "core");

            migrationBuilder.DropTable(
                name: "tb_attribute_values",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_wishlists",
                schema: "customers");

            migrationBuilder.DropTable(
                name: "tb_variations",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_orders",
                schema: "orders");

            migrationBuilder.DropTable(
                name: "tb_methods",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "tb_attributes",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_products",
                schema: "products");

            migrationBuilder.DropTable(
                name: "tb_addresses",
                schema: "core");

            migrationBuilder.DropTable(
                name: "tb_users",
                schema: "core");
        }
    }
}
