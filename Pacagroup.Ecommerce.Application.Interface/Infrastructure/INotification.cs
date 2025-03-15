using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.Infrastructure
{
    public interface INotification
    {
        Task<bool> SendMailAsync(string subject, string body, CancellationToken cancellationToken = default);
    }
}
