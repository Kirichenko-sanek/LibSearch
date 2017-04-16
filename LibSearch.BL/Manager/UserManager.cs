using LibSearch.Core.Intefaces.Manager;
using LibSearch.Core.Intefaces.Repository;
using LibSearch.Core.Intefaces.Validator;
using LibSearch.Core.Model;
using LibSearch.Core.ViewModel;

namespace LibSearch.BL.Manager
{
    public class UserManager<T> : Manager<T>, IUserManager<T> where T : User
    {
        public UserManager(IRepository<T> repository, IValidator<T> validator)
           : base(repository, validator)
        {
        }

        public LoginViewModel LogInApi(string email, string password)
        {
            var model = new LoginViewModel();


            return model;
        }
    }
}
