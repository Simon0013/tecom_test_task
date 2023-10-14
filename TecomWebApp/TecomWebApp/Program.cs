using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using TecomWebApp.Models;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Employee>("Employees");

builder.Services.AddControllers().AddOData(
    options => options.EnableQueryFeatures().AddRouteComponents(
        routePrefix: "odata",
        model: modelBuilder.GetEdmModel()));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TecomTestContext>();

builder.Services.AddSwaggerGen();

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
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
