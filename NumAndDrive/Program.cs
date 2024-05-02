using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;

var modelBuilder = WebApplication.CreateBuilder(args);
modelBuilder.Services.AddControllersWithViews();


var connectionString = modelBuilder.Configuration.GetConnectionString("DefaultConnection");
modelBuilder.Services.AddDbContext<NumAndDriveContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

modelBuilder.Services.AddIdentity<User, IdentityRole>(options =>
{
    //////// Change to real Password Requirement after development ////////

    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<NumAndDriveContext>()
    .AddDefaultTokenProviders();

modelBuilder.Services.ConfigureApplicationCookie(options =>
{
    //////// Ajust timespan after development ////////
    
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.LoginPath = "/Account/Login";
});

// Add services to the container.

var app = modelBuilder.Build();


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
