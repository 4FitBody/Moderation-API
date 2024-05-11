using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Moderation_API.Infrastructure.Data;
using Moderation_API.Core.Food.Repositories;
using Moderation_API.Core.Exercises.Repositories;
using Moderation_API.Core.SportSupplements.Repositories;
using Moderation_API.Infrastructure.Exercises.Repositories;
using Moderation_API.Infrastructure.Food.Repositories;
using Moderation_API.Infrastructure.SportSupplements.Repositories;

var builder = WebApplication.CreateBuilder(args);

var infrastructureAssembly = typeof(ModerationDbContext).Assembly;

builder.Services.AddMediatR(configurations =>
{
    configurations.RegisterServicesFromAssembly(infrastructureAssembly);
});

builder.Services.AddScoped<IFoodRepository, FoodSqlRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseSqlRepository>();
builder.Services.AddScoped<ISportSupplementRepository, SportSupplementRepository>();

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("ModerationDb");

builder.Services.AddDbContext<ModerationDbContext>(dbContextOptionsBuilder =>
{
    dbContextOptionsBuilder.UseNpgsql(connectionString, o =>
    {
        o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
    });
});

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
            .WithOrigins("http://localhost:5160")
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
