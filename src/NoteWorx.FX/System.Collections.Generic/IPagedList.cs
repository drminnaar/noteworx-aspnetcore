using System.Collections.Generic;

namespace System.Collections.Generic
{
   public interface IPagedList<T> : IReadOnlyList<T>
   {
      int ItemCount { get; }
      int PageCount { get; }
      int PageNumber { get; }
      int PageSize { get; }
      int? LastPageNumber { get; }
      int? NextPageNumber { get; }
      int? PreviousPageNumber { get; }
      bool HasNext { get; }
      bool HasPrevious { get; }
   }
}