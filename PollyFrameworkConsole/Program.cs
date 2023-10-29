using Models;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Traceability;

namespace PollyFrameworkConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //var polly = Policy.Handle<Exception>()
            //    .RetryAsync(3, (exception, retryCount, context) =>
            //    Console.WriteLine($"try: {retryCount}, Exception: {exception.Message}"));

            var storageRequest = new StorageRequest
            {
                ExecutionLog = JsonConvert.SerializeObject(new { Log = "This is test data." }),
                TenantContainer = "execution-logs",
                FileName = "TestFileFramework2.json"
            };

            Logger.LogMethod(storageRequest);

            //HttpClient client = new HttpClient();
            //HttpContent content = new StringContent(JsonConvert.SerializeObject(storageRequest));

            //var result = await polly.ExecuteAsync(
            //    async () => await client.PostAsync("http://localhost:7058/api/UploadLogFileStarter", content));

            //Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
