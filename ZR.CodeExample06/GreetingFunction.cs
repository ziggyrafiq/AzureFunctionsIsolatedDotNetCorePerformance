using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using ZR.CodeExample06.Services.Contracts;

namespace ZR.CodeExample06;
public class GreetingFunction
{
    private readonly IGreetingService _greetingService;

    public GreetingFunction(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    [Function("GreetingFunction")]
    public string Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        return _greetingService.GetGreeting();
    }
}
