namespace TimeStamp.Application.Interfaces
{
    public interface IAuthenticationApp
    {
        bool Authorize(string email, string password);
    }
}
