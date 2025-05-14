using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_Authentication.Models;
using Microsoft.IdentityModel.Tokens;

namespace API_Authentication.Helpers;

public static class JwtHelper
{
    public static AuthResponse GenerateToken(User user, IConfiguration config)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.UtcNow.AddMinutes(int.Parse(config["Jwt:ExpireMinutes"]!));

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: new[] { new Claim(ClaimTypes.Name, user.Username) },
            expires: expires,
            signingCredentials: creds
        );

        return new AuthResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiresAt = expires
        };
    }
}
