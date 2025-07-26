using System;
using HelperBackendAPI.Entity.DataContext;
using HelperBackendAPI.Entity.Entity;
using HelperBackendAPI.Repository.Repository;
using HelperBackendAPI.Services.Service;
using Microsoft.EntityFrameworkCore;

namespace HelperBackendAPI.Service.Service;

public class LoginService : ILoginRepository
{
    private readonly ApplicationDBContext _applicationDBContext;
    public LoginService(ApplicationDBContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }

    public async Task<object?> UserAuthenticate(User user)
    {
        var result = await _applicationDBContext.Users
                    .Where(x => (x.Email == user.Email || x.Phone == user.Phone) && x.Password == user.Password)
                    .FirstOrDefaultAsync();

        if (result != null) {
            return new
            {
                id = result.Id,
                email = result.Email,
                token = JwtService.GenerateJwtAuthentication(result)
            };
        }
        return null;
    }



}
