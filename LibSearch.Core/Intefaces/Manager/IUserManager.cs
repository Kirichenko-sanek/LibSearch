using LibSearch.Core.Model;
using LibSearch.Core.ViewModel;

namespace LibSearch.Core.Intefaces.Manager
{
    public interface IUserManager<T> : IManager<T> where T : User
    {
        LoginViewModel LogInApi(string email, string password);
    }
}
