using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ZR.CodeExample04;
public static class AzureFunctionsAndDotNetCore
{
    [FunctionName("DateTimeFunction")]
    public static void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
    {
        log.LogInformation("Azure Function executed at: " + DateTime.Now);
    }
}




