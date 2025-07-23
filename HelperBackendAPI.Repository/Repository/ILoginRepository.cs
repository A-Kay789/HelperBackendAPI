using System;
using HelperBackendAPI.Entity.Entity;

namespace HelperBackendAPI.Repository.Repository;

public interface ILoginRepository
{
    Task<object?> UserAuthenticate(User user);
}
