using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();