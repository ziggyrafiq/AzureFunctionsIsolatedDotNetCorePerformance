using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace ZR.CodeExample;

public class HttpTriggerFunction
{
    private readonly ILogger _logger;

    public HttpTriggerFunction(ILogger<HttpTriggerFunction> logger)
    {
        _logger = logger;
    }

    [Function("HttpTriggerFunction")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        FunctionContext executionContext)
    {
        _logger.LogInformation("Ziggy Rafiq Code Example of HttpTriggerFunction Runing.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        response.WriteString("Welcome to Ziggy Rafiq HttpTrigger Azure Functions!");

        var queryParams = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
        string name = queryParams["name"];

        using (StreamReader reader = new StreamReader(req.Body))
        {
            string requestBody = await reader.ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
        }

        if (!string.IsNullOrEmpty(name))
        {
            response.WriteString($"Hello, {name}. This is an Azure Function response.");
            return response;
        }
        else
        {
            response = req.CreateResponse(HttpStatusCode.BadRequest);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Please pass a name on the query string or in the request body.");
            return response;
        }
    }
}
