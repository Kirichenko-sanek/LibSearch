using System.Collections.Generic;
using System.Web;
using LibSearch.Core.Model;
using LibSearch.Core.ViewModel;

namespace LibSearch.Core.Intefaces.Manager
{
    public interface IBookManager<T>: IManager<T> where T : Book
    {
        void AddBooksOnDB(HttpPostedFileBase filebase);
        List<string> GetCategory();
        List<BookViewModel> GetBooks(string category);
    }
}
