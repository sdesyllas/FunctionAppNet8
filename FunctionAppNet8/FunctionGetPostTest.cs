using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppNet8
{
    public class FunctionGetPostTest
    {
        private readonly ILogger _logger;

        public FunctionGetPostTest(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FunctionGetPostTest>();
        }

        [Function("FunctionGetPostTest")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
