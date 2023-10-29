using Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Traceability;

namespace PollyFrameworkConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var storageRequest = new StorageRequest
            {
                ExecutionLog = JsonConvert.SerializeObject(new { Log = "This is test data." }),
                TenantContainer = "execution-logs",
                FileName = "TestFileFramework2.json"
            };

            await Logger.LogMethod(storageRequest);
        }
    }
}
