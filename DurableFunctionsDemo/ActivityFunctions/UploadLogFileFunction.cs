using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Models;

namespace DurableFunctionsDemo.ActivityFunctions
{
    public static class UploadLogFileFunction
    {

        [FunctionName(nameof(UploadLogFile))]
        public static async Task<string> UploadLogFile([ActivityTrigger] StorageRequest storageRequest, ILogger log)
        {
            var connectionString = Environment.GetEnvironmentVariable("StorageAccountConnectionString");

            BlobServiceClient blobServiceClient = null;
            blobServiceClient = new BlobServiceClient(connectionString);

            var containerClient = blobServiceClient.GetBlobContainerClient(storageRequest.TenantContainer);

            // This can cause concurrency issues
            // await containerClient.CreateIfNotExistsAsync();

            var blobName = $"{Guid.NewGuid()}-{storageRequest.FileName}";
            
            await containerClient.UploadBlobAsync(blobName, BinaryData.FromString(storageRequest.ExecutionLog));

            return blobName;
        }


    }
}