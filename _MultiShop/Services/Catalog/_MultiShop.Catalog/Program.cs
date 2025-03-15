using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Services.CategoryServices;
using _MultiShop.Catalog.Services.FeatureServices;
using _MultiShop.Catalog.Services.FeatureSliderServices;
using _MultiShop.Catalog.Services.OfferDiscountService;
using _MultiShop.Catalog.Services.ProductServices;
using _MultiShop.Catalog.Services.ProductImageServices;
using _MultiShop.Catalog.Services.ProductDetailServices;
using _MultiShop.Catalog.Services.SpecialOfferServices;
using _MultiShop.Catalog.Services.BrandServices;
using _MultiShop.Catalog.Services.AboutServices;
using _MultiShop.Catalog.Services.ContactServices;
using _MultiShop.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using _MultiShop.Catalog.Services.ProductImageImageServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;

});

builder.Services.AddAuthorization();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderServices>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
