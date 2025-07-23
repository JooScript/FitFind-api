using ECommerce.Bl;
using ECommerce.Da;
using ECommerce.Mapping;
using ECommerce.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Entity Framework
builder.Services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ECommerceContext>();
#endregion

#region DI

#region Bl

builder.Services.AddScoped<IAttribute, ClsAttribute>();
builder.Services.AddScoped<IAddress, ClsAddress>();
builder.Services.AddScoped<IWishlist, ClsWishlist>();
builder.Services.AddScoped<IAttributeValue, ClsAttributeValue>();
builder.Services.AddScoped<ICategory, ClsCategory>();
builder.Services.AddScoped<IShoppingCart, ClsShoppingCart>();
builder.Services.AddScoped<IDiscountProductMapping, ClsDiscountProductMapping>();
builder.Services.AddScoped<IDiscountCategoryMapping, ClsDiscountCategoryMapping>();
builder.Services.AddScoped<IDiscount, ClsDiscount>();
builder.Services.AddScoped<IImage, ClsImage>();
builder.Services.AddScoped<IAuditLog, ClsAuditLog>();
builder.Services.AddScoped<ICartItem, ClsCartItem>();
builder.Services.AddScoped<ICampaign, ClsCampaign>();
builder.Services.AddScoped<ICampaignProductMapping, ClsCampaignProductMapping>();
builder.Services.AddScoped<ILanguage, ClsLanguage>();
builder.Services.AddScoped<ISupplier, ClsSupplier>();
builder.Services.AddScoped<IInventoryTransaction, ClsInventoryTransaction>();
builder.Services.AddScoped<IInvoice, ClsInvoice>();
builder.Services.AddScoped<IOrderReturn, ClsOrderReturn>();
builder.Services.AddScoped<ISubscription, ClsSubscription>();
builder.Services.AddScoped<ITag, ClsTag>();
builder.Services.AddScoped<ITaxRate, ClsTaxRate>();
builder.Services.AddScoped<ITicketReply, ClsTicketReply>();
builder.Services.AddScoped<IVariation, ClsVariation>();
builder.Services.AddScoped<IVariationAttributeMapping, ClsVariationAttributeMapping>();
builder.Services.AddScoped<IWishlistItem, ClsWishlistItem>();
builder.Services.AddScoped<IUserActivity, ClsUserActivity>();
builder.Services.AddScoped<IProductCategoryMapping, ClsProductCategoryMapping>();
builder.Services.AddScoped<IOrderStatusHistory, ClsOrderStatusHistory>();
builder.Services.AddScoped<IProduct, ClsProduct>();
builder.Services.AddScoped<ISupportTicket, ClsSupportTicket>();
builder.Services.AddScoped<IProductTagMapping, ClsProductTagMapping>();
builder.Services.AddScoped<IReview, ClsReview>();
builder.Services.AddScoped<IProductSupplier, ClsProductSupplier>();
builder.Services.AddScoped<IOrderItem, ClsOrderItem>();
builder.Services.AddScoped<IPayment, ClsPayment>();
builder.Services.AddScoped<IOrder, ClsOrder>();
builder.Services.AddScoped<IShipment, ClsShipment>();
builder.Services.AddScoped<IPaymentTransaction, ClsPaymentTransaction>();
builder.Services.AddScoped<IShipmentItemMapping, ClsShipmentItemMapping>();
builder.Services.AddScoped<IProductTranslationMapping, ClsProductTranslationMapping>();
builder.Services.AddScoped<ISeoMetum, ClsSeoMetum>();
builder.Services.AddScoped<IMethod, ClsMethod>();

#endregion

#region Da

builder.Services.AddScoped<IAttributeData, AttributeData>();
builder.Services.AddScoped<IAddressData, AddressData>();
builder.Services.AddScoped<IWishlistData, WishlistData>();
builder.Services.AddScoped<IAttributeValueData, AttributeValueData>();
builder.Services.AddScoped<ICategoryData, CategoryData>();
builder.Services.AddScoped<IShoppingCartData, ShoppingCartData>();
builder.Services.AddScoped<IDiscountProductMappingData, DiscountProductMappingData>();
builder.Services.AddScoped<IDiscountCategoryMappingData, DiscountCategoryMappingData>();
builder.Services.AddScoped<IDiscountData, DiscountData>();
builder.Services.AddScoped<IImageData, ImageData>();
builder.Services.AddScoped<IAuditLogData, AuditLogData>();
builder.Services.AddScoped<ICartItemData, CartItemData>();
builder.Services.AddScoped<ICampaignData, CampaignData>();
builder.Services.AddScoped<ICampaignProductMappingData, CampaignProductMappingData>();
builder.Services.AddScoped<ILanguageData, LanguageData>();
builder.Services.AddScoped<ISupplierData, SupplierData>();
builder.Services.AddScoped<IInventoryTransactionData, InventoryTransactionData>();
builder.Services.AddScoped<IInvoiceData, InvoiceData>();
builder.Services.AddScoped<IOrderReturnData, OrderReturnData>();
builder.Services.AddScoped<ISubscriptionData, SubscriptionData>();
builder.Services.AddScoped<ITagData, TagData>();
builder.Services.AddScoped<ITaxRateData, TaxRateData>();
builder.Services.AddScoped<ITicketReplyData, TicketReplyData>();
builder.Services.AddScoped<IVariationData, VariationData>();
builder.Services.AddScoped<IVariationAttributeMappingData, VariationAttributeMappingData>();
builder.Services.AddScoped<IWishlistItemData, WishlistItemData>();
builder.Services.AddScoped<IUserActivityData, UserActivityData>();
builder.Services.AddScoped<IProductCategoryMappingData, ProductCategoryMappingData>();
builder.Services.AddScoped<IOrderStatusHistoryData, OrderStatusHistoryData>();
builder.Services.AddScoped<IProductData, ProductData>();
builder.Services.AddScoped<ISupportTicketData, SupportTicketData>();
builder.Services.AddScoped<IProductTagMappingData, ProductTagMappingData>();
builder.Services.AddScoped<IReviewData, ReviewData>();
builder.Services.AddScoped<IProductSupplierData, ProductSupplierData>();
builder.Services.AddScoped<IOrderItemData, OrderItemData>();
builder.Services.AddScoped<IPaymentData, PaymentData>();
builder.Services.AddScoped<IOrderData, OrderData>();
builder.Services.AddScoped<IShipmentData, ShipmentData>();
builder.Services.AddScoped<IPaymentTransactionData, PaymentTransactionData>();
builder.Services.AddScoped<IShipmentItemMappingData, ShipmentItemMappingData>();
builder.Services.AddScoped<IProductTranslationMappingData, ProductTranslationMappingData>();
builder.Services.AddScoped<ISeoMetumData, SeoMetumData>();
builder.Services.AddScoped<IMethodData, MethodData>();

#endregion

#endregion

builder.Services.AddAutoMapper(typeof(MappingProfile));

#region JWT

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,  // Typically set to true in production
        ValidateIssuerSigningKey = true
    };
});

#endregion

#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "E-Commerce API",
        Description = "API to access E-Commerce items and related categories",
        TermsOfService = new Uri("https://JooScript.com"),
        Contact = new OpenApiContact
        {
            Email = "contactyousefrefat@gmail.com",
            Name = "Yousef R Awad",
            Url = new Uri("https://JooScript.com")
        },
        License = new OpenApiLicense
        {
            Name = "Joo Script Licence",
            Url = new Uri("https://JooScript.com")
        }
    });

    //var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // Edit In Properities Of Project
    //var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // Edit In Properities Of Project
    //var fullPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    //options.IncludeXmlComments(fullPath);
});
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
