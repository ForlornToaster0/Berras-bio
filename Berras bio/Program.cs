using Microsoft.EntityFrameworkCore;
using Berras_bio.Data;
using Berras_bio.Model;
using Berras_bio.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<Berras_bioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Berras_bioContext") ?? throw new InvalidOperationException("Connection string 'Berras_bioContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Berras_bioContext>();
    context.Database.Migrate();
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
DataBase data = new();
data.takenSeats(); 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
