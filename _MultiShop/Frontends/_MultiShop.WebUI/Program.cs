using _MultiShop.WebUI.Handlers;
using _MultiShop.WebUI.Services.BasketServices;
using _MultiShop.WebUI.Services.CatalogServices;
using _MultiShop.WebUI.Services.CatalogServices.AboutServices;
using _MultiShop.WebUI.Services.CatalogServices.BrandServices;
using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using _MultiShop.WebUI.Services.CatalogServices.ContactServices;
using _MultiShop.WebUI.Services.CatalogServices.FeatureService;
using _MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using _MultiShop.WebUI.Services.CatalogServices.OfferDiscountService;
using _MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using _MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using _MultiShop.WebUI.Services.CommentServices;
using _MultiShop.WebUI.Services.Concrete;
using _MultiShop.WebUI.Services.DiscountServcies;
using _MultiShop.WebUI.Services.Interfaces;
using _MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using _MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;
using _MultiShop.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MultiShop.IdentityServer.Tools;
using MultiShop.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index"; // Kullanýcý sisteme giriþ yapmadan girmeye çalýþtýðýnda yönlendirilecek olan sayfa
    opt.LogoutPath = "/Login/logout"; // Kullanýcý sistemden çýktýðýnda yönlendirilecek olan sayfa
    opt.AccessDeniedPath = "/Pages/AccesDenied"; // Kullanýcý yetkisi olmayan bir sayfaya girmek isteðinde yönlendirilecek olan sayfa
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "MultiShopJwt";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.Cookie.Name = "MultiShopCookie";
    opt.SlidingExpiration = true;
});


//builder.Services.AddAccesTokenManagement();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();


// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
builder.Services.AddHttpClient<IuserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}/");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderAddressService, OrderAddressService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}/");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderOrderingService, OrderOrderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}/");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureService, FeatureService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IBrandServices, BrandService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IAboutService, AboutService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IDiscountService, DiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}/");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
