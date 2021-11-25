using TftTracker.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<TftSeeder>();

//Setup DBContext
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<TftContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
else
    builder.Services.AddDbContext<TftContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//Seed the DB with dummy data when provided with "/seed"
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetService<TftSeeder>();
    seeder.Seed();
}

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
