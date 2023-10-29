using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using Models;

namespace DurableFunctionsDemo.HttpTriggerFunctions
{
    public static class StarterFunctions
    {
        [FunctionName(nameof(UploadLogFileStarter))]
        public static async Task<IActionResult> UploadLogFileStarter(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            var executionLogJson = await new StreamReader(req.Body).ReadToEndAsync();
            var storageRequest = JsonConvert.DeserializeObject<StorageRequest>(executionLogJson);

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("UploadLogFileOrchestrator", null, storageRequest);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
