using System;
using HelperBackendAPI.Entity.Entity;

namespace HelperBackendAPI.Repository.Repository;

public interface IUserRepository
{
    Task<List<User>> GetUsers();
    Task<User?> GetUser(int id);
    Task<User> CreateUser(User userInfo);
    Task<User> UpdateUser(User userInfo);
}
