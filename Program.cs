using e_commerce.Configrution;
using e_commerce.Servies;
using First_MVC.Servies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration.AddJsonFile("appsettings.json").Build();
var conectionstring = config.GetSection("constr").Value;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conectionstring));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddEntityFrameworkStores<AppDbContext>().AddDefaultUI().AddDefaultTokenProviders();
builder.Services.AddAuthentication().AddGoogle(options => {
    IConfigurationSection googleAuthentation = builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuthentation["ClientId"];
    options.ClientSecret = googleAuthentation["ClientSecret"];

    });
builder.Services.AddScoped<ICartServies, CartServies>();
builder.Services.AddScoped<ICatagoryServies, CatagoryServies>();
builder.Services.AddScoped<IOfferServies, OfferServies>();
builder.Services.AddScoped<IOrderServies, OrderServies>();
builder.Services.AddScoped<IProductServies, ProductServies>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
