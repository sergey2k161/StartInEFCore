using Microsoft.EntityFrameworkCore;
using StartInEFCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDBContext)));
    });

//builder.Services.AddDbContext<ApplicationDBContext>(
//    options =>
//    {
//        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
//    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
