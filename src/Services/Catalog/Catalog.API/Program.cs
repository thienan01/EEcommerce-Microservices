using Microsoft.Extensions.Options;
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    opts.Connection(connectionString!);
}).UseLightweightSessions();
var app = builder.Build();
// Configure the HTTP request pipeline

app.MapCarter();
app.Run();
