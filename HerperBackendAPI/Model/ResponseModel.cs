using System;

namespace HerperBackendAPI.Model;

public class ResponseModel
{
    public int Status { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; } 
}
