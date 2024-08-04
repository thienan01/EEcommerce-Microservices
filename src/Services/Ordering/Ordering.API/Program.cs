using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationService()
    .AddInfrastructureService(builder.Configuration)
    .AddApiService();

var app = builder.Build();
app.UseApiServices();
app.Run();
