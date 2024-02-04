using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security;
using Warehouse.Data;
using Warehouse.Repository;
using Warehouse.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ItemRepository, ItemRepository>();//krijon nje fusheveprim per repositorin

builder.Services.AddTransient<IItemService, ItemService>(); //krijon nje fusheveprim per servisin
//ketu i thua qe web app do te njohi ne database te ri dhe ky server i ketej database do reveroj ne "Server=DESKTOP-8EJ06EC\\SQLEXPRESS;Database=WarehouseDatabase;Trusted_Connection=True;TrustServerCertificate=True;"
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-2KFP9OG\\SQLEXPRESS;Database=WarehouseDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
