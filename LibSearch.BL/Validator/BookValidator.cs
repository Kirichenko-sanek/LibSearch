using LibSearch.Core.Intefaces.Repository;
using LibSearch.Core.Intefaces.Validator;
using LibSearch.Core.Model;

namespace LibSearch.BL.Validator
{
    public class BookValidator: IValidator<Book>
    {
        private readonly IRepository<Book> _repository;

        public BookValidator(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public bool IsExists(long id)
        {
            return _repository.GetByID(id) != null;
        }

        public bool IsValid(Book entity)
        {
            return true;
        }

    }
}
