using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PesKit.DAL;
using PesKit.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>((options) => { options.UseSqlServer(builder.Configuration.GetConnectionString("Default")); });



builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength= 7;
    options.Password.RequireNonAlphanumeric= false;


    options.User.RequireUniqueEmail= true;


    options.Lockout.MaxFailedAccessAttempts= 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);


}








).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    "Default",
    "{area}/{controller=home}/{action=index}/{id?}");

app.MapControllerRoute(
    "Default",
    "{controller=home}/{action=index}/{id?}");


app.Run();
//Aqil