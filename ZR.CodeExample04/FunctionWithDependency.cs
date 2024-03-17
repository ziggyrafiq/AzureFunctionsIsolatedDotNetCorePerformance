using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ZR.CodeExample04.Models;

namespace ZR.CodeExample04;
public class FunctionWithDependency
{
    private readonly PersonName _personName;

    public FunctionWithDependency(PersonName personName)
    {
        _personName = personName;
    }

    [FunctionName("FunctionWithDependency")]
    public void Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
                    FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("FunctionWithDependency");
        logger.LogInformation("Ziggy Rafiq Code Example of Azure Function with dependency executed.");

        // We can Use _personName properties here
        string personName = $"{_personName.FirstName} {_personName.LastName}";
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        response.WriteString(personName);       
    }
}
