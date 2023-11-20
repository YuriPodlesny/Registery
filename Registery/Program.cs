using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Extensions;
using Registery.Application.Interfaces;
using Registery.Application.Mapping;
using Registery.Domain.Entities;
using Registry.DAL;
using Registry.DAL.DbInitialazer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMediatR(option => option.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IBaseDbContext, ApplicationDbContext>().AddApplications();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IInitializer, UserInitializer>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
})
    .AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Home/AccessDenied";
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

SeedDatabase();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using var scrope = app?.Services.CreateScope();
    var dbInitializer = scrope?.ServiceProvider.GetRequiredService<IInitializer>()!;
    dbInitializer.Initialize();
}