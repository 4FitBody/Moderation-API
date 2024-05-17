using System.Reflection;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Moderation_API.Core.Food.Repositories;
using Moderation_API.Core.Food.Models;
using Moderation_API.Core.Exercises.Repositories;
using Moderation_API.Core.Exercises.Models;
using Moderation_API.Core.SportSupplements.Repositories;
using Moderation_API.Core.SportSupplements.Models;
using Moderation_API.Infrastructure.Exercises.Repositories;
using Moderation_API.Infrastructure.Food.Repositories;
using Moderation_API.Infrastructure.SportSupplements.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetSection("ModerationDb").Value;

var foodcollection = builder.Configuration.GetSection("FoodCollection").Value;

var exercisescollection = builder.Configuration.GetSection("ExercisesCollection").Value;

var supplemenetscollection = builder.Configuration.GetSection("SupplementsCollection").Value;

var infrastructureAssembly = typeof(FoodMongoRepository).Assembly;

builder.Services.AddMediatR(configurations =>
{
    configurations.RegisterServicesFromAssembly(infrastructureAssembly);
});

builder.Services.AddSingleton<IFoodRepository>(provider =>
{
    if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(foodcollection))
    {
        throw new Exception($"Not Found");
    }

    return new FoodMongoRepository(connectionString, "FoodDb", foodcollection);
});

builder.Services.AddSingleton<ISportSupplementRepository>(provider =>
{
    if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(supplemenetscollection))
    {
        throw new Exception($"Not Found");
    }

    return new SportSupplementMongoRepository(connectionString, "SportSupplementDb", supplemenetscollection);
});

builder.Services.AddSingleton<IExerciseRepository>(provider =>
{
    if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(exercisescollection))
    {
        throw new Exception($"Not Found");
    }

    return new ExerciseMongoRepository(connectionString, "ExercisesDb", exercisescollection);
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "4FitBody (api for moderation)",
        Version = "v1"
    });
});

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorWasmPolicy", corsBuilder =>
    {
        corsBuilder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("BlazorWasmPolicy");

app.Run();
