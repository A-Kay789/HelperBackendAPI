using System;
using HelperBackendAPI.Entity.Entity;

namespace HelperBackendAPI.Repository.Repository;

public interface IServiceProvider
{
    Task<List<ServiceProvider>> GetServiceProviders();
    Task<ServiceProvider?> GetServiceProvider(int id);
    Task<ServiceProvider> CreateServiceProvider(ServiceProvider serviceProvider);
    Task<ServiceProvider> UpdateServiceProvider(ServiceProvider serviceProvider);
}
