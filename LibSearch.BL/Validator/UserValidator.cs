using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSearch.Core.Intefaces.Repository;
using LibSearch.Core.Intefaces.Validator;
using LibSearch.Core.Model;

namespace LibSearch.BL.Validator
{
    public class UserValidator : IValidator<User>
    {
        private readonly IRepository<User> _userRepository;

        public UserValidator(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsExists(long id)
        {
            return _userRepository.GetByID(id) != null;
        }

        public bool IsValid(User entity)
        {
            return _userRepository.GetAll().FirstOrDefault(m => m.Email == entity.Email) == null
                 && !string.IsNullOrEmpty(entity.FirstName)
                 && !string.IsNullOrEmpty(entity.LastName)
                 && !string.IsNullOrEmpty(entity.Email)
                 && !string.IsNullOrEmpty(entity.Password)
                 && !string.IsNullOrEmpty(entity.PasswordSalt);
        }
    }
}
