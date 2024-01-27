using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application;
using BudgetPal.Infrastructure;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Environment.GetEnvironmentVariable(EnvironmentVariables.JwtIssuer) ?? Defaults.DefaultJwtIssuer,
        ValidAudience = Environment.GetEnvironmentVariable(EnvironmentVariables.JwtIssuer) ?? Defaults.DefaultJwtIssuer,
        IssuerSigningKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(EnvironmentVariables.JwtKey) ??
                                       "BudgetPalJwtKey"))
    };
});

builder.Services.AddMediatR(
    config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("BudgetPal.Application")));
builder.Services.AddHttpClient("HTTP_CLIENT").ConfigureHttpClient((_, client) =>
{
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("Content-Type", "application/json");
    client.Timeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();