using IdentityApp.Models.Context;
using IdentityApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
services.AddControllersWithViews().AddRazorRuntimeCompilation();
services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDb")));

services.AddIdentity<IdentityUser, IdentityRole>(option =>
{
    option.Password.RequiredUniqueChars = 0;
    option.User.RequireUniqueEmail = true;
    option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddErrorDescriber<PersianIdentityErrorDescriber.PersianIdentityErrorDescriber>();

services.AddScoped<IMessageSender, MessageSender>();

services.AddAuthentication().AddGoogle(options =>
{
    options.ClientId = "171267951019-jth974leb4ejifiudmsqcqm8igcv0e6n.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

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

app.Run();
