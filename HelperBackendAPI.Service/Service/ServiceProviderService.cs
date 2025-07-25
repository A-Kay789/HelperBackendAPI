using System;
using HelperBackendAPI.Entity.DataContext;
using HelperBackendAPI.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace HelperBackendAPI.Services.Service;

public class ServiceProviderService
{
    private readonly ApplicationDBContext _applicationDBContext;
    public ServiceProviderService(ApplicationDBContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }

    public async Task<List<ServiceProvider>> GetServiceProviders()
    {
        return await _applicationDBContext.ServiceProviders.ToListAsync();
    }

    public async Task<ServiceProvider?> GetServiceProvider(int id)
    {
        return await _applicationDBContext.ServiceProviders.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ServiceProvider> CreateServiceProvider(ServiceProvider serviceProvider)
    {
        serviceProvider.CreatedDate = DateTime.Now;
        serviceProvider.IsActive = true;
        serviceProvider.IsDeleted = false;
        _applicationDBContext.ServiceProviders.Add(serviceProvider);
        await _applicationDBContext.SaveChangesAsync();
        return serviceProvider;
    }

    public async Task<ServiceProvider> UpdateServiceProvider(ServiceProvider serviceProvider)
    {
        var result = await _applicationDBContext.ServiceProviders.FirstOrDefaultAsync(x => x.Id == serviceProvider.Id);
        if (result != null)
        {
            result.FirstName = serviceProvider.FirstName;
            result.LastName = serviceProvider.LastName;
            result.Email = serviceProvider.Email;
            result.Phone = serviceProvider.Phone;
            result.Address = serviceProvider.Address;
            result.City = serviceProvider.City;
            result.State = serviceProvider.State;
            result.ServiceCost = serviceProvider.ServiceCost;
            result.ServiceId = serviceProvider.ServiceId;
            result.UpdatedDate = DateTime.Now;
            await _applicationDBContext.SaveChangesAsync();
        }
        return serviceProvider;
    }


}
