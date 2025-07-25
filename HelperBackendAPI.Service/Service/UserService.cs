using System;
using HelperBackendAPI.Entity.DataContext;
using HelperBackendAPI.Entity.Entity;
using HelperBackendAPI.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace HelperBackendAPI.Services.Service;

public class UserService : IUserRepository
{
    private readonly ApplicationDBContext _applicationDBContext;
    public UserService(ApplicationDBContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _applicationDBContext.Users.ToListAsync();
    }
    public async Task<User?> GetUser(int id)
    {
        return await _applicationDBContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User> CreateUser(User userInfo)
    {
        userInfo.IsActive = true;
        userInfo.IsDeleted = false;
        userInfo.CreatedDate = DateTime.Now;
        _applicationDBContext.Users.Add(userInfo);
        await _applicationDBContext.SaveChangesAsync();
        return userInfo;
    }

    public async Task<User> UpdateUser(User userInfo)
    {
        var result = await _applicationDBContext.Users.Where(x => x.Id == userInfo.Id).FirstOrDefaultAsync();
        result.FirstName = userInfo.FirstName;
        result.LastName = userInfo.LastName;
        result.Email = userInfo.Email;
        result.Phone = userInfo.Phone;
        result.UpdatedDate = DateTime.Now;
        await _applicationDBContext.SaveChangesAsync();
        return result;
    }
}
