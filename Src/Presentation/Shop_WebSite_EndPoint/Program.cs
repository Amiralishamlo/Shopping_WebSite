using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Contexts;
using Shop.Application.Visitors.SaveVisitorInfo;
using Shop.Application.Visitors.VisitorOnline;
using Shop.Infrastructure.IdentityConfig;
using Shop.Persistence.Context;
using Shop.Persistence.Context.MongoContext;
using Shop_WebSite_EndPoint.Hubs;
using Shop_WebSite_EndPoint.Utilities.Filters;
using Shop_WebSite_EndPoint.Utilities.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Connection string
builder.Services.AddTransient<IDataBaseContext, DataBaseContext>();
builder.Services.AddDbContext<DataBaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Shop_Sql")));
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
builder.Services.AddTransient<IVisitorOnlineService, VisitorOnlineService>();
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
