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
            var storageRequest = new StorageRequest
            {
                ExecutionLog = JsonConvert.SerializeObject(new { Log = "This is test data." }),
                TenantContainer = "execution-logs",
                FileName = "TestFileFramework2.json"
            };

            Logger.LogMethod(storageRequest);

            Console.ReadLine();
        }
    }
}
