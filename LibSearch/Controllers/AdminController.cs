using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LibSearch.BL;
using LibSearch.Core.Intefaces.Manager;
using LibSearch.Core.Model;

namespace LibSearch.Controllers
{
    [Authorize]
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private readonly IBookManager<Book> _bookManager;


        public AdminController(IBookManager<Book> bookManager)
        {
            _bookManager = bookManager;
        }

        [Route("uploadInfo")]
        [AllowAnonymous]
        [HttpPost]
        public bool UploadInfo()
        {
            var request = HttpContext.Current.Request.Files;
            var a = request["Files"];
            HttpPostedFileBase filebase = new HttpPostedFileWrapper(a);
            var result = _bookManager.AddBooksOnDB(filebase);
            return true;
        }


    }
}