using Application.Catalogs.GetMenuItem;
using Application.Interfaces.Contexts;
using Application.Visitors.SaveVisitorInfo;
using Application.Visitors.VisitorOnline;
using Infrastructure.MappingProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.MongoContext;
using Persistence.Contexts;
using WebSite.EndPoint.Hubs;
using WebSite.EndPoint.Utilities.Filters;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.IdentityConfigs;
using System;
using Microsoft.Extensions.Hosting;
using WebSite.EndPoint.Utilities.Middlewares;
using Microsoft.Extensions.Configuration;
using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Catalogs.CatalogItems.UnComposer;
using Application.Catalogs.CatalogItems.GetCatalogItemPDP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Connection string
builder.Services.AddTransient<IDataBaseContext, DataBaseContext>();
builder.Services.AddDbContext<DataBaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Shop_Sql")));
builder.Services.AddDbContext<IdentityDatabaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Shop_Sql")));
#endregion

#region Identity
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});
#endregion

#region Add_service
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddScoped<SaveVisitorFilter>();
builder.Services.AddSignalR();
builder.Services.AddTransient<IIVisitorOnlineService, VisitorOnlineService>();
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IUriComposerService, UriComposerService>();
builder.Services.AddScoped<IGetCatalogItemPLPService, GetCatalogItemPLPService>();
builder.Services.AddScoped<IGetCatalogItemPDPService, GetCatalogItemPDPService>();
//mapper
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSetVisitorId();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<OnlineVisitorHub>("/chathub");
app.Run();
