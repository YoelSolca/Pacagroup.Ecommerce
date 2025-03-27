namespace Pacagroup.Ecommerce.Application.Interface.Presentation
{
    public interface ICurrentUser
    {
        string? UserId { get; }
        string? UserName { get; }
    }
}
