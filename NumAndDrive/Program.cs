using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Areas.Admin.Service;
using NumAndDrive.Areas.UserArea.Services;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository;
using NumAndDrive.Repository.Interfaces;
using NumAndDrive.Services;
using NumAndDrive.Services.Interfaces;
using NumAndDrive.Utilities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IActivationDayRepository, ActivationDayRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IClassroomRepository, ClassroomRepository>();
builder.Services.AddScoped<IDriverTypeRepository, DriverTypeRepository>();
builder.Services.AddScoped<IFilterRepository, FilterRepository>();
builder.Services.AddScoped<IFuelRepository, FuelRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<ITravelActivationDayRepository, TravelActivationDayRepository>();
builder.Services.AddScoped<ITravelFilterRepository, TravelFilterRepository>();
builder.Services.AddScoped<ITravelPreferenceRepository, TravelPreferenceRepository>();
builder.Services.AddScoped<ITravelRepository, TravelRepository>();
builder.Services.AddScoped<ITravelStopPointRepository, TravelStopPointRepository>();
builder.Services.AddScoped<IUserNotificationRepository, UserNotificationRepository>();
builder.Services.AddScoped<IUserReviewRepository, UserReviewRepository>();
builder.Services.AddScoped<IUserRewardRepository, UserRewardRepository>();
builder.Services.AddScoped<IUserTravelPreferenceRepository, UserTravelPreferenceRepository>();

builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<AddressUtilities>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NumAndDriveContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Change to real Password Requirement after development
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<NumAndDriveContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Ajust timespan after development
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.LoginPath = "/Account/Login";
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "AdminArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "UserArea",
    areaName: "UserArea",
    pattern: "UserArea/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
