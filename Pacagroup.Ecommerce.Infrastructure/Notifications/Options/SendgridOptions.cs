namespace Pacagroup.Ecommerce.Infrastructure.Notification.Options
{
    public class SendgridOptions
    {
        public string ApiKey { get; init; }
        public string FromEmail { get; init; }
        public string FromUser { get; init; }
        public bool SandboxMode { get; init; }
        public string ToAddress { get; init; }
        public string ToUser { get; init; }
    }
}
