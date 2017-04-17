using System.Web;
using LibSearch.Core.Model;

namespace LibSearch.Core.Intefaces.Manager
{
    public interface IBookManager<T>: IManager<T> where T : Book
    {
        void AddBooksOnDB(HttpPostedFileBase filebase);
    }
}
