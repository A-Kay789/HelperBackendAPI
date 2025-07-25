using System;

namespace HelperBackendAPI.Entity.Entity;

public class MasterService
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}
