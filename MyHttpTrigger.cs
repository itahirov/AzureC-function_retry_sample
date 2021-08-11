using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LocalFunctionsProject
{
    public static class MyHttpTrigger
    {
        [FunctionName("throwsexeption")]
        [FixedDelayRetry(5, "00:00:05")]
        public static async Task<IActionResult> ThrowsExeption(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
			var text="";
            try
            {
                string name="10";
				name = req.Query["name"];
				int div = 100;
				div = Convert.ToInt32(name);
                var a = 100 / div;
				text = Convert.ToString(a);
            }
            catch (Exception x)
            {
                x = null;
                text = x.ToString();
                //throw;
            }
            return new OkObjectResult(text);
        }
		
		[FunctionName("MyHttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
