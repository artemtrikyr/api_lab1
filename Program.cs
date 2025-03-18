using AttendanceJournalApi.Services;
using AttendanceJournalApi.Data;
using AttendanceJournalApi.Middlewares;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Реєстрація сервісів
builder.Services.AddScoped<AttendanceService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Підключення middleware
app.UseMiddleware<ServerErrorHandlingMiddleware>();
app.UseMiddleware<SimpleAuthenticationMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<UserRequestLoggingMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();
