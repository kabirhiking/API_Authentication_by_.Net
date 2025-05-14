using API_Authentication.Models;

namespace API_Authentication.Services;

public interface IAuthService
{
    string Register(RegisterRequest request);
    AuthResponse? Login(LoginRequest request);
}