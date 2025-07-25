using System;

namespace HelperBackendAPI.Entity.Entity;

public class SearchHistory
{
    public int Id { get; set; }
    public string? HistoryName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
