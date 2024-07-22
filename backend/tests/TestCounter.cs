using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

namespace tests
{
    public class TestCounter
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void Http_trigger_should_return_known_string()
        {
            await Task.CompletedTask;
            var counter = new Company.Function.Counter();
            counter.Id = "1";
            counter.Count = 2;
            var request = TestFactory.CreateHttpRequest();
            var response = Company.Function.GetResumeCounter.Run(request, counter, logger);


            if (response is OkObjectResult result && result.Value is Company.Function.Counter updatedCounter)
            {
                Assert.Equal(3, updatedCounter.Count);
            }
            else
            {
                Assert.Fail("Response or result value was null");
            }
        }
    }
}
