using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MobileBackend.Application;

namespace MobileBackend
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly IMediator _mediator;

        public Function1(ILogger<Function1> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Function("Function1")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var cmd = await req.ReadFromJsonAsync<RecepcionCommand>();
            if (cmd is null)
                return new BadRequestResult();
            var result = await _mediator.Send(cmd);
            if (result.Ok)
                return new OkObjectResult(result);
            return new BadRequestObjectResult(result);
        }
    }
}
