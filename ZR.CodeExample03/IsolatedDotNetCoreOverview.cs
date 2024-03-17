using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ZR.CodeExample03
{
    public class IsolatedDotNetCoreOverview
    {
        private readonly ILogger _logger;

        public IsolatedDotNetCoreOverview(ILogger<IsolatedDotNetCoreOverview> logger)
        {
            _logger = logger;
        }

        [Function("IsolatedDotNetCoreOverview")]
        public void Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
                        FunctionContext executionContext)
        {
            _logger.LogInformation("Ziggy Rafiq Azure Isolated .NET Core Overview Function executed.");

            string overviewText = GetOverviewText();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString(overviewText);
            
        }

        private string GetOverviewText()
        {
            return @"Isolated .NET Core for Azure Functions enhances runtime and execution by enabling each function app to run independently with its .NET Core runtime, dependencies, and configurations. Benefits include:
- Independence: Avoid conflicts with other apps.
- Performance: Lightweight runtime for better performance.
- Side-by-Side Deployment: Manage multiple apps with different .NET Core versions.
- Security: Apply updates independently for improved isolation.
- Future Compatibility: Stay compatible with the latest .NET capabilities.";
        }
    }
}
