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
            
            var storageRequest = new StorageRequest
            {
                ExecutionLog = JsonConvert.SerializeObject(new { Log = "This is test data." }),
                TenantContainer = "execution-logs",
                FileName = "TestFileCore3.json"
            };

            await Logger.LogMethod(storageRequest);

            Console.ReadLine();

        }
    }
}
