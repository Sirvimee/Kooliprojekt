using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameHouse.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using GameHouse.Repositories;
using GameHouse.Services;
using GameHouse.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingContext") ?? throw new InvalidOperationException("Connection string 'BookingContext' not found.")));
builder.Services.AddDbContext<RoomContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RoomContext") ?? throw new InvalidOperationException("Connection string 'RoomContext' not found.")));
var connectionString = builder.Configuration.GetConnectionString("UserDBContextConnection") ?? throw new InvalidOperationException("Connection string 'UserDBContextConnection' not found.");

builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<UserDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Rooms}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
