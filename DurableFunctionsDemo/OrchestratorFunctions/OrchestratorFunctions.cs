using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;
using Models;
using Azure.Storage.Blobs.Models;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace DurableFunctionsDemo.OrchestratorFunctions
{
    public static class OrchestratorFunctions
    {
        [FunctionName(nameof(UploadLogFileOrchestrator))]
        public static async Task<string> UploadLogFileOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var storageRequest = context.GetInput<StorageRequest>();

            var blobName = await context.CallActivityAsync<string>("UploadLogFile", storageRequest);

            var metaDataRequest = new BlobMetaDataRequest { BlobName = blobName, StorageRequest = storageRequest };

            var storageResult = await context.CallActivityAsync<BlobStorageResult>("SetBlobMetaData", metaDataRequest);

            return storageResult.Uri;
        }
    }
}
