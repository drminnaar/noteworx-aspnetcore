using System.Text;

namespace System
{
   public static class StringExtensions
   {
      public static bool IsNullOrWhiteSpace(this string value)
      {
         return string.IsNullOrWhiteSpace(value);
      }

		public static byte[] ToBytes(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Specified value may not be null, empty, or whitespace.",
                    nameof(value));
            }

            return Encoding.UTF8.GetBytes(value);
        }
   }
}