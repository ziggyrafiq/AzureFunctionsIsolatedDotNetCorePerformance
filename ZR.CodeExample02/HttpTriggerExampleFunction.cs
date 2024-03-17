using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ZR.CodeExample02;
public class TimerTriggerExampleFunction
{
    private readonly ILogger _logger;

    public TimerTriggerExampleFunction(ILogger<TimerTriggerExampleFunction> logger)
    {
        _logger = logger;
    }

    [Function("TimerTriggerExampleFunction")]
    public void Run([Microsoft.Azure.Functions.Worker.TimerTrigger("0 */5 * * * *")] Microsoft.Azure.Functions.Worker.TimerInfo myTimer,
                    FunctionContext executionContext)
    {
        _logger.LogInformation("Ziggy Rafiq example of Timer Trigger Example Function executed.");

        // Our Timer-Triggered Function Logic Goes Here

        _logger.LogInformation($"Timer trigger executed at: {DateTime.Now}");
    }
}
