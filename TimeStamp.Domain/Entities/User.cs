namespace TimeStamp.Domain.Entities
{
    public class User : Base
    {
        public User(string email, string password)
        {
            EMail = email;
            Password = password;            
        }

        public string EMail { get; private set; }
        public string Password { get; private set; }
        
        public bool Authorize()
            => EMail == Password ? true : false;
    }
}
