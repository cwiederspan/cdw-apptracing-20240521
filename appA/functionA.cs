using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appA {

    public class functionA {

        private readonly ILogger<functionA> Logger;

        public functionA(ILogger<functionA> logger) {
            this.Logger = logger;
        }

        [Function("functionA")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req) {

            using (var client = new HttpClient()){
                var result = await client.GetAsync("https://cdw-apptracing-20240521-appb.azurewebsites.net/api/functionB");
                var value = await result.Content.ReadAsStringAsync();
                this.Logger.LogInformation($"Result from B: {value}");
            }

            this.Logger.LogInformation("C# HTTP trigger function A processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
