using Pacagroup.Ecommerce.Application.Interface.Presentation;
using Pacagroup.Ecommerce.Application.UseCases.Common.Constants;
using System.Security.Claims;

namespace Pacagroup.Ecommerce.Services.WebApi.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext.User?.FindFirstValue("userid") ?? GlobalConstant.DefaultUserId;

        public string UserName => _httpContextAccessor.HttpContext.User?.FindFirstValue("username") ?? GlobalConstant.DefaultUserName;

    }
}
