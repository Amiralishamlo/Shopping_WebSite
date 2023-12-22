using Microsoft.EntityFrameworkCore;
using Shop.Application.Catalogs.CatalogTypes.CrudService;
using Shop.Application.Interfaces.Contexts;
using Shop.Application.Visitors.GetTodayReport;
using Shop.Application.Visitors.VisitorOnline;
using Shop.Infrastructure.IdentityConfig;
using Shop.Infrastructure.MappingProfile;
using Shop.Persistence.Context;
using Shop.Persistence.Context.MongoContext;
using Shop_Admin_EndPoint.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
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
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));

#region Add_Service
builder.Services.AddTransient<IGetTodayReportService, GetTodayReportService>();
builder.Services.AddTransient<IVisitorOnlineService, VisitorOnlineService>();
builder.Services.AddTransient<ICatalogService, CatalogService>();
#endregion
#region Mapper_Service
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
builder.Services.AddAutoMapper(typeof(CatalogVMMappingProfile));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
