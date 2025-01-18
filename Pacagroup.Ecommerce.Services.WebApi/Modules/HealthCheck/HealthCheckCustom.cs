using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.HealthCheck
{
    public class HealthCheckCustom : IHealthCheck
    {
        private readonly Random _random = new Random();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            //llamada a un servicio externo, webservice, servicio de mensajeria etc.

            // Simulate a random health check
            var responseTime = _random.Next(1, 300);


            if (responseTime < 100)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Healthy result from HealthyCheckCustom"));
            }
            else if (responseTime < 200)
            {
                return Task.FromResult(HealthCheckResult.Degraded("Degraded result from HealthyCheckCustom"));
            }
         
            return Task.FromResult(HealthCheckResult.Unhealthy("Unhealthy result from HealthyCheckCustom"));
        }
    }
}
