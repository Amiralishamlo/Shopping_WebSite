using Shop.Application.Interfaces.Contexts;
using Shop.Application.Visitors.GetTodayReport;
using Shop.Application.Visitors.VisitorOnline;
using Shop.Infrastructure.IdentityConfig;
using Shop.Persistence.Context.MongoContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
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
