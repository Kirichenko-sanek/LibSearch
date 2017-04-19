using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AutoMapper;
using LibSearch.Core.Intefaces.Manager;
using LibSearch.Core.Intefaces.Repository;
using LibSearch.Core.Intefaces.Validator;
using LibSearch.Core.Model;
using LibSearch.Core.ViewModel;

namespace LibSearch.BL.Manager
{
    public class BookManager<T> : Manager<T>, IBookManager<T> where T : Book
    {
        private readonly IManager<Book> _manager;

        public BookManager(IRepository<T> repository, IValidator<T> validator, IManager<Book> manager) : base(repository, validator)
        {
            _manager = manager;
        }


        public void AddBooksOnDB(HttpPostedFileBase filebase)
        {
            using (var reader = new StreamReader(filebase.InputStream))
            {
                for (;;)
                {
                    try
                    {
                        var str = reader.ReadLine();
                        if (str == null)
                        {
                            break;
                        }
                        var result = str.Split(';');
                        var entity = new Book
                        {
                            Name = result[0],
                            Category = result[2],
                            Author = result[3],
                            Summary = result[4],
                            PageUrl = result[5],
                            Photo = new Photo
                            {
                                Url = result[1]
                            }
                        };
                        _manager.Add(entity);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                var a = 9;

            }
        }



        public List<string> GetCategory()
        {
            var result = new List<string>();
            var books = GetAll();
            foreach (var book in books)
            {
                if (result.Count == 0)
                {
                    result.Add(book.Category);
                }
                else
                {
                    if (result.Contains(book.Category))
                    {
                        continue;
                    }
                    result.Add(book.Category);
                }
            }

            return result;
        }

        public List<BookViewModel> GetBooks(string category)
        {
            var result = new List<BookViewModel>();
            var books = GetAll().Where(x => x.Category == category);
            foreach (var book in books)
            {
                result.Add(Mapper.Map<Book, BookViewModel>(book));
            }
            return result;
        }

        public BookViewModel GetBook(long id)
        {
            var book = GetById(id);
            var result = Mapper.Map<Book, BookViewModel>(book);
            return result;
        }


    }
}
