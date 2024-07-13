public interface IAuthService
{
    bool Authenticate(string username, string password);
}

public class UserAuthService : IAuthService
{
    private readonly List<User> _users;

    public UserAuthService()
    {
        _users = new List<User>
        {
            new User { Username = "user1", Password = "password1" },
            new User { Username = "user2", Password = "password2" }
        };
    }

    public bool Authenticate(string username, string password)
    {
        return _users.Any(u => u.Username == username && u.Password == password);
    }
}
