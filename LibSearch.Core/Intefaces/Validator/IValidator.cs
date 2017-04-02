using LibSearch.Core.Model;

namespace LibSearch.Core.Intefaces.Validator
{
    public interface IValidator<in T> where T : BaseEntity
    {
        bool IsValid(T entity);
        bool IsExists(long id);
    }
}
