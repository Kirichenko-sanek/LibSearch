using System.Web;
using LibSearch.Core.Intefaces.Manager;
using LibSearch.Core.Intefaces.Repository;
using LibSearch.Core.Intefaces.Validator;
using LibSearch.Core.Model;

namespace LibSearch.BL.Manager
{
    public class BookManager<T> : Manager<T>, IBookManager<T> where T : Book
    {
        public BookManager(IRepository<T> repository, IValidator<T> validator) : base(repository, validator)
        {
            
        }


        public bool AddBooksOnDB(HttpPostedFileBase filebase)
        {
            return true;
        }


    }
}
