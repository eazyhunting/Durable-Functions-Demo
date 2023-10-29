using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DurableFunctionsDemo.ActivityFunctions
{
    public static class SetBlobMetaDataFunction
    {
        [FunctionName(nameof(SetBlobMetaData))]
        public static async Task<BlobStorageResult> SetBlobMetaData([ActivityTrigger] BlobMetaDataRequest metaDataRequest, ILogger log)
        {
            var connectionString = Environment.GetEnvironmentVariable("StorageAccountConnectionString");

            BlobServiceClient blobServiceClient = null;
            blobServiceClient = new BlobServiceClient(connectionString);

            var containerClient = blobServiceClient.GetBlobContainerClient(metaDataRequest.StorageRequest.TenantContainer);
            var blob = containerClient.GetBlobClient(metaDataRequest.BlobName);

            IDictionary<string, string> metadata = new Dictionary<string, string>();

            // Add metadata to the dictionary by calling the Add method
            metadata.Add("originalName", metaDataRequest.StorageRequest.FileName);

            await blob.SetMetadataAsync(metadata);

            var properties = await blob.GetPropertiesAsync();

            return new BlobStorageResult() { Uri = blob.Uri.AbsoluteUri, Properties = properties.Value };

        }
    }
}
