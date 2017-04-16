using System;
using System.Linq;
using System.Web.Security;
using LibSearch.Core.Intefaces.Manager;
using LibSearch.Core.Intefaces.Repository;
using LibSearch.Core.Intefaces.Validator;
using LibSearch.Core.Model;
using LibSearch.Resources.App_GlobalResources;
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
            try
            {
                var user = GetAll().FirstOrDefault(x => x.Email == email);
                if (user == null) throw new Exception(Resource.EmailNotRegistered);
                var pass = PasswordHashing.HashPassword(password, user.PasswordSalt);
                if (user.Password != pass) throw new Exception(Resource.WrongPassword);
                if (!user.IsActivated) throw new Exception();
                FormsAuthentication.SetAuthCookie(user.Email, false);
                model.IdUser = user.Id;
                model.Role = user.Roles.Role;
                return model;
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return model;
            }

        }

        public User GetUserByEmail(string email)
        {
            return GetAll().FirstOrDefault(x => x.Email == email);
        }
    }
}
