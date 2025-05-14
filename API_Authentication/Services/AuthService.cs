
using API_Authentication.Helpers;
using API_Authentication.Models;

namespace API_Authentication.Services;

public class AuthService(AppDbContext context, IConfiguration config) : IAuthService
{
    public string Register(RegisterRequest request)
    {
        if (context.Users.Any(u => u.Username == request.Username))
            return "User name already exishts";

        var newUser = new User
        {
            Username = request.Username,
            Password = request.Password
        };
        context.Users.Add(newUser);
        context.SaveChanges();

        return "User registered successfully.";
    }

    public AuthResponse? Login(LoginRequest request)
    {
        var user = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

        return user is null ? null : JwtHelper.GenerateToken(user, config);
    }
}