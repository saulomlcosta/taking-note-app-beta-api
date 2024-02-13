using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using TakingNoteApp.Application.Behaviours;
using TakingNoteApp.Application.Common.Interfaces;
using TakingNoteApp.Data;
using TakingNoteApp.Extensions;
using TakingNoteApp.Middlewares;
using TakingNoteApp.Services;
using TakingNoteApp.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var assembly = Assembly.GetExecutingAssembly();

builder.Services.AddMediatR(cfg => cfg
    .RegisterServicesFromAssembly(assembly));

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddControllers(options => options.Filters.Add(typeof(ExceptionMiddleware)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddScoped<ILoggedUser, LoggedUser>();
builder.Services.AddHttpContextAccessor();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TakingNoteAppContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ITakingNoteAppContext>(provider => provider.GetRequiredService<TakingNoteAppContext>());
builder.Services.AddScoped<TakingNoteAppContextInitialiser>();

builder.Services.AddAutoMapper(assembly);

builder.Services.AddAuthJwt();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.InitialiseDatabaseAsync();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
