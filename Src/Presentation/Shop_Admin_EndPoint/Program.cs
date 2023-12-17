using Shop.Infrastructure.IdentityConfig;

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
