using System;

namespace HerperBackendAPI.Model;

public class UserLoginModel
{
  public string? Email { get; set; }
  public string? Password { get; set; }
  public string? Phone { get; set; }
}
