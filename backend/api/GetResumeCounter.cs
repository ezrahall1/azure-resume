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
                containerName: "Counter", // Use 'containerName' instead of 'collectionName'
                Connection = "AzureResumeConnectionString", // Use 'Connection' instead of 'ConnectionStringSetting'
                Id = "1",
                PartitionKey = "1")] Counter counter,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            counter.Count += 1;

            return new OkObjectResult(counter);
        }
    }
}