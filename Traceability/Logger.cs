using Models;
using Newtonsoft.Json;
using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Traceability
{
    public static class Logger
    {
        public static async Task LogMethod(StorageRequest storageRequest)
        {
            var polly = Policy.Handle<Exception>()
               .RetryAsync(3, (exception, retryCount, context) =>
               Console.WriteLine($"try: {retryCount}, Exception: {exception.Message}"));

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(storageRequest));

            var result = await polly.ExecuteAsync(
                async () => await client.PostAsync("http://localhost:7058/api/UploadLogFileStarter", content));
        }
    }
}
