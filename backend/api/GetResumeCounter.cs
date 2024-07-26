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
        [FunctionName("GetResumeCounter25")]
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
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (counter == null)
            {
                log.LogError("Counter document not found.");
                return new NotFoundResult();
            }

            counter.Count += 1;

            log.LogInformation($"Counter updated to {counter.Count}.");

            return new OkObjectResult(counter);
        }
    }
}
