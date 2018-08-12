using CRP.Domain.Infrastructure;
using CRP.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRP.Storage.Services
{
    public class UserService : IUserService
    {
        readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public bool Add(User user)
        {
            var isExists = _repository.Project<User, bool>(list => (from b in list where b.Email == user.Email select b.Email).Any());
            if (isExists)
            {
                return false;
            }
            user = _repository.Add(user);
            return true;
        }

        public bool Delete(int id)
        {
            var user = _repository.Load<User>(x => x.UserId == id);
            if (user == null)
            {
                return false;
            }
            else
            {
                _repository.Delete(user);
                return true;
            }
        }

        public User GetById(int id)
        {
            return _repository.Project<User, User>(list => (from b in list where b.UserId == id select b).FirstOrDefault());
        }

        public IEnumerable<User> GetUsers()
        {
            return _repository.Project<User, List<User>>(list => (from b in list select b).ToList());
        }

        public bool Update(User user)
        {
            var isExists = _repository.Project<User, bool>(list => (from b in list where b.Email == user.Email && b.UserId != user.UserId select b.FullName).Any());
            if (isExists)
            {
                return false;
            }
            var usr = _repository.Load<User>(x => x.UserId == user.UserId);
            if (usr != null)
            {
                usr.FullName = user.FullName;
                usr.UserType = user.UserType;
            }
            return true;
        }
    }
}
