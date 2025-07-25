using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace func_container;

public class HttpTriggerFunction
{
    [Function("HttpTriggerFunction")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        var response = req.CreateResponse();
        response.WriteString("Hello from HTTP trigger!");
        return response;
    }
}