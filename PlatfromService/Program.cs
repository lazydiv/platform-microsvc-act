using Microsoft.EntityFrameworkCore;
using PlatfromService.Data;
using PlatfromService.SyncDateServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// if (builder.Environment.IsProduction())
// {
    Console.WriteLine("--> Using SQL Server");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("PlatformConnection")));
// }
// else
// {
//     Console.WriteLine("--> Using InMem DB");
//     builder.Services.AddDbContext<AppDbContext>(options =>
//         options.UseInMemoryDatabase("InMem"));
// }

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine($"--> CommandService Endpoint: {app.Configuration["CommandService"]}");

app.UseHttpsRedirection();
app.MapControllers();

// Seed the database after building the app but before running it.
// PrepDb.PrepPopulation(app, app.Environment.IsProduction());

app.Run();
