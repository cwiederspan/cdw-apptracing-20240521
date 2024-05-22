using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appB {

    public class functionB {

        private readonly ILogger<functionB> Logger;

        public functionB(ILogger<functionB> logger) {
            this.Logger = logger;
        }

        [Function("functionB")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req) {
            this.Logger.LogInformation("C# HTTP trigger function B processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
