using Care.Api.Repository.Validation;
using System.Linq.Expressions;

namespace Care.Api.Repository.Interfaces;

public interface ICommonRepository<T> where T : class
{
    List<T> GetAll();
    T GetValue(Expression<Func<T, bool>> predicate);
    Task<T?> GetValueAsync(Expression<Func<T, bool>> predicate);
    List<T> GetValues(Expression<Func<T, bool>> predicate);
    List<T> GetValuesByPagination(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicateOrderBy, int currentPage, int pageSize, bool orderAsc = true);
    ValidationResult Insert(T data);
    Task<ValidationResult> InsertAsync(T data);
    T Update(T data);
    Task<ValidationResult> UpdateAsync(T data);
    void Delete(T data);
    List<T> Find(Expression<Func<T, bool>> predicate);
}
