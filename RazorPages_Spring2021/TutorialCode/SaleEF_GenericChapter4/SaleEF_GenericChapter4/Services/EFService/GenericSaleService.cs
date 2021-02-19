using Microsoft.EntityFrameworkCore;
using SaleEF_GenericChapter4.Models;
using SaleEF_GenericChapter4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SaleEF_GenericChapter4.Services.EFService
{
    public class GenericSaleService<T>: IService<T> where T:class , new ()
    {
         private SaleDbContext context { get; set; }
        public GenericSaleService(SaleDbContext saleService)
        {
            context = saleService;
         }
        public async Task AddItemAsync(T item)
        {
             context.Set<T>().Add(item);
             await context.SaveChangesAsync();
        }
        public async Task<T> GetItemByIdAsync(int id)
        {
            T item = await context.Set<T>().FindAsync(id);
            if (item== null)
            {
                return null;
            }
            return item;
        }
        public async Task DeleteItemAsync(T item)
        {
            context.Set<T>().Remove(item);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> CheckExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
