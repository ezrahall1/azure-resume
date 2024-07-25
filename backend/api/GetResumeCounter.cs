using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "AzureResume",
                collectionName: "Counter",
                ConnectionStringSetting = "COSMOSDB_KEY",  // Use your environment variable here
                Id = "1",
                PartitionKey = "1")] Counter counter,
            ILogger log)
        {
            // Here is where the counter gets updated.
            log.LogInformation("C# HTTP trigger function processed a request.");

            counter.Count += 1;

            return new OkObjectResult(counter);
        }
    }
}

