namespace System.Collections.Generic
{
   public sealed class PagedList<T> : IPagedList<T>
   {
      private readonly List<T> _list = new();

      public PagedList(
         IReadOnlyList<T> items,
         int itemCount,
         int pageNumber,
         int pageSize)
      {
         ItemCount = itemCount;
         PageNumber = pageNumber;
         PageSize = pageSize;
         PageCount = pageSize > 0 ? (int)Math.Ceiling(itemCount / (double)pageSize) : 0;

         if (items.Count > 0)
            _list.AddRange(items);
      }

      public static IPagedList<T> Empty => new PagedList<T>(Array.Empty<T>(), 0, 0, 0);

      public int ItemCount { get; private set; }

      public int PageCount { get; private set; }

      public int PageNumber { get; private set; }

      public int PageSize { get; private set; }

      public int? LastPageNumber
      {
         get
         {
            return PageCount;
         }
      }

      public int? NextPageNumber
      {
         get
         {
            if (HasNext)
               return PageNumber + 1;

            return null;
         }
      }

      public int? PreviousPageNumber
      {
         get
         {
            if (HasPrevious)
               return PageNumber - 1;

            return null;
         }
      }

      public bool HasNext
      {
         get
         {
            return PageNumber < PageCount;
         }
      }

      public bool HasPrevious
      {
         get
         {
            return PageNumber > 1;
         }
      }

      public int Count => _list.Count;

      public T this[int index] => _list[index];

      public IEnumerator<T> GetEnumerator()
      {
         return _list.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return _list.GetEnumerator();
      }
   }
}
