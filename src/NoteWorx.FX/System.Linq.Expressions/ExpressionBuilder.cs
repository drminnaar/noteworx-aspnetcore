namespace System.Linq.Expressions
{
   public static class ExpressionBuilder
   {
      public static Expression<Func<T, bool>> True<T>() => (e => true);

      public static Expression<Func<T, bool>> False<T>() => (e => false);

      public static Expression<Func<T, bool>> And<T>(
         this Expression<Func<T, bool>> left,
         Expression<Func<T, bool>> right)
      {
         var expression = Expression.Invoke(
            right, left.Parameters.Cast<Expression>());

         return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(left.Body, expression),
            left.Parameters);
      }

      public static Expression<Func<T, bool>> Or<T>(
         this Expression<Func<T, bool>> left,
         Expression<Func<T, bool>> right)
      {
         var expression = Expression.Invoke(
            right, left.Parameters.Cast<Expression>());

         return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(left.Body, expression),
            left.Parameters);
      }
   }
}