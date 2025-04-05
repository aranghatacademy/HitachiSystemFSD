using System;
using System.Security.Claims;

namespace Ecom.Services.Users;

public interface IAuthenticationService 
{
    Task<List<Claim>> LoginAsync(LoginRequest request);

    Task<string> GenerateJwtToken(List<Claim> claims);
}
