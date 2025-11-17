using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mirra.Email.Function.Service;
using Mirra.Email.Function.Service.Interfaces;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights()
    .AddAutoMapper(config =>
    {
        config.AllowNullCollections = true;
        config.AllowNullDestinationValues = true;
        config.CreateMap<int?, int>()
            .ConvertUsing(
                    (int? src, int dest, ResolutionContext _) => src ?? dest
            );
    },
    AppDomain.CurrentDomain.GetAssemblies())
   .AddSingleton<IEmailService, EmailService>()
   .AddSingleton<IPreOrderService, PreOrderService>();

builder.Configuration
        .AddUserSecrets<Program>()
        .AddEnvironmentVariables();

builder.Build().Run();
