using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
   public static class QueryableExtensions
   {
      public static async Task<IPagedList<T>> ToPagedListAsync<T>(
         this IQueryable<T> items,
         int pageNumber,
         int pageSize)
      {
         var itemCount = await items.CountAsync();

         var list = await items
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

         return new PagedList<T>(list, itemCount, pageNumber, pageSize);
      }
   }
}