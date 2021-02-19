using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SaleEF_GenericChapter4.Services.Interfaces
{
    public interface IService<T>
    {
        Task AddItemAsync(T sale);
        Task DeleteItemAsync(T sale);
        Task<T> GetItemByIdAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task<IEnumerable<T>> CheckExpressionAsync(Expression<Func<T, bool>> expression);
    }
}
