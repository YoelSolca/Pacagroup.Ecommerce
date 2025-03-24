using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //antes -> Pre
            _logger.LogInformation("CleanArchitecture Request Handling: {name} {@request}", typeof(TRequest).Name, JsonSerializer.Serialize(request));

            var response = await next();

            //despues -> Post
            _logger.LogInformation("CleanArchitecture Response Handling: {name} {@response}", typeof(TRequest).Name, JsonSerializer.Serialize(response));

            return response;
        }
    }
}
