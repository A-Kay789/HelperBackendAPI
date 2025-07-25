using System;
using HelperBackendAPI.Entity.DataContext;
using HelperBackendAPI.Entity.Entity;
using HelperBackendAPI.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace HelperBackendAPI.Services.Service;

public class MasterUserService:IMasterService
{
    private readonly ApplicationDBContext _applicationDBContext;
    public MasterUserService(ApplicationDBContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }

    public async Task<List<MasterService>> GetServices()
    {
        return await _applicationDBContext.MasterService.ToListAsync();
    }

    public async Task<MasterService?> GetService(int id)
    {
        return await _applicationDBContext.MasterService.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<MasterService> CreateService(MasterService masterService)
    {
        var service = new MasterService
        {
            Name = masterService.Name,
            CreatedDate = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        };
        _applicationDBContext.MasterService.Add(service);
        await _applicationDBContext.SaveChangesAsync();
        return service;
    }

    public async Task<MasterService> UpdateService(MasterService masterService)
    {
        var service = new MasterService
        {
            Name = masterService.Name,
            UpdatedDate = DateTime.Now
        };
        _applicationDBContext.MasterService.Add(service);
        await _applicationDBContext.SaveChangesAsync();
        return service;
    }

    public async Task<bool> DeleteService(int id)
    {
        var result = await _applicationDBContext.MasterService.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (result != null)
        {
            result.IsDeleted = true;
            await _applicationDBContext.SaveChangesAsync();
        }
        return result.IsDeleted;
    }
}
