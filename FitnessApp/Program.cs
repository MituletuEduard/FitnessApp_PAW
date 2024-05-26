using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Services;
using FitnessApp.Models;
using FitnessApp.Services.Timer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<ITimerRepository, TimerRepository>();
builder.Services.AddScoped<ITimerService, TimerService>();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FitnessDb")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddSingleton<ILog, MyConsoleLogger>();

builder.Services.AddScoped<IMasuratoriRepository, MasuratoriRepository>();
builder.Services.AddScoped<IMasuratoriService, MasuratoriService>();

builder.Services.AddScoped<IMeasurementService, MeasurementService>();

builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
