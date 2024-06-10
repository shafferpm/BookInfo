using BookInfo.API.DbContexts;
using BookInfo.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

// Create the WebApplication instance.
// The WebApplication class is a part of the Microsoft.AspNetCore.Components.WebAssembly.Server namespace.
// The WebApplication class is used to create a new web application instance.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Option one: Register the PubsContext as a service in the dependency injection container with the connection string in the PubsContext class.
//builder.Services.AddDbContext<PubsContext>();

// Option two: Register the PubsContext as a service in the dependency injection container with the connection string in the appsettings.json file.
builder.Services.AddDbContext<PubsContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("BookInfoDBConnectionString"));
});

// Register the BookInfoRepository repository service in the dependency injection container.
// Scoped lifetime services are created once per request.
builder.Services.AddScoped<IBookInfoRepository, BookInfoRepository>();

// Register the AutoMapper service in the dependency injection container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseRouting();

app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.MapControllers();

app.Run();
