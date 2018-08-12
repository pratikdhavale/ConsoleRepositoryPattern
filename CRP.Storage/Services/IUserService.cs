using CRP.Domain.Models;
using System.Collections.Generic;

namespace CRP.Storage.Services
{
    public interface IUserService
    {
        User Add(User user);
        User Update(User user);
        bool Delete(int id);
        User GetById(int id);
        IEnumerable<User> GetUsers();
    }
}
