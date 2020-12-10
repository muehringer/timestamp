using TimeStamp.Application.Interfaces;
using TimeStamp.Domain.Entities;

namespace TimeStamp.Application.Apps
{
    public class AuthenticationApp : IAuthenticationApp
    {
        private User user;

        public bool Authorize(string email, string password)
        {
            user = new User(email, password);

            return user.Authorize();
        }
    }
}
