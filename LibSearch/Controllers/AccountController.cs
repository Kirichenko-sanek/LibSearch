using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using LibSearch.Core.Intefaces.Manager;
using LibSearch.Core.Model;
using LibSearch.Core.ViewModel;

namespace LibSearch.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IBookManager<Book> _bookManager;

        public AccountController(IBookManager<Book> bookManager)
        {
            _bookManager = bookManager;
        }

        [Route("userInSystem")]
        [HttpPost]
        public string UserInSystem()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var role = identity.Claims.Where(c => c.Type == "role").Select(c => c.Value).SingleOrDefault();
            return role;
        }

        [Route("getCategories")]
        [HttpGet]
        public List<string> GetCategories()
        {
            return _bookManager.GetCategory();
        }

        [Route("getBooks")]
        [HttpPost]
        public List<BookViewModel> ListBooks([FromBody]string category)
        {
            return _bookManager.GetBooks(category);
        }

        [Route("book/{id}")]
        [HttpGet]
        public BookViewModel GetBook(long id)
        {
            return _bookManager.GetBook(id);
        }


    }
}