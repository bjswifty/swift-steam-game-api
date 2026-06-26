using Microsoft.EntityFrameworkCore;
using SwiftSteamGameApi.Data;
using SwiftSteamGameApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GameLibraryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GameLibraryDatabase")));
builder.Services.AddScoped<IGameRecordService, GameRecordService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
