using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZR.CodeExample06.Services.Contracts;
using ZR.CodeExample06.Services;

var host = new HostBuilder()
     .ConfigureFunctionsWorkerDefaults()
     .ConfigureServices(services =>
     {
         services.AddTransient<IGreetingService, GreetingService>();
     })
     .Build();

await host.RunAsync();


