using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        var assembly = AppDomain.CurrentDomain.Load("MobileBackend.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    })
    .Build();

host.Run();
