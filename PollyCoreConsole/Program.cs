using Polly;
using Models;
using Newtonsoft.Json;
using Traceability;

namespace PollyCoreConsole
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
                FileName = "TestFileCore3.json"
            };

            await Logger.LogMethod(storageRequest);

            //using HttpClient client = new HttpClient();
            //using HttpContent content = new StringContent(JsonConvert.SerializeObject(storageRequest));
            

            //var result = await polly.ExecuteAsync(
            //    async () => await client.PostAsync("http://localhost:7058/api/UploadLogFileStarter", content));

            Console.ReadLine();

        }
    }
}
