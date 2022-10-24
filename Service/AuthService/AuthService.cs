using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Service.AuthService
{
  public class AuthService : IAuthService
  {
    public Task<ServiceResponse<string>> Login(string username, string password)
    {
      throw new NotImplementedException();
    }

    public Task<ServiceResponse<int>> Register(User user, string password)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UserExist(string username)
    {
      throw new NotImplementedException();
    }
  }
}