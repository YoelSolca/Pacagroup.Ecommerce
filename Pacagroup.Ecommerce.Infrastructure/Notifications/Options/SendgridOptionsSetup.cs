using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Pacagroup.Ecommerce.Infrastructure.Notification.Options;

namespace Pacagroup.Ecommerce.Infrastructure.Notifications.Options
{
    public class SendgridOptionsSetup : IConfigureOptions<SendgridOptions>
    {
        private const string ConfigurationSectionName = "Sendgrid";
        private readonly IConfiguration _configuration;

        public SendgridOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(SendgridOptions options)
        {
            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
