using System;
using HelperBackendAPI.Entity.Entity;

namespace HelperBackendAPI.Repository.Repository;

public interface IMasterService
{
    Task<List<MasterService>> GetServices();
    Task<MasterService?> GetService(int id);
    Task<MasterService> CreateService(MasterService masterService);
    Task<MasterService> UpdateService(MasterService masterService);
    Task<bool> DeleteService(int id);
}
