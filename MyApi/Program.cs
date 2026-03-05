using MyApi.Services;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var user = "Users";

if(user == Roles.Admin)
{
    Console.WriteLine("Admin access granted.");
}
else if (user == Roles.User)
{
    Console.WriteLine("User access granted.");
}
else
{
    Console.WriteLine("Access denied.");
}
app.Run();
