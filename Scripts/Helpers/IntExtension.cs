using System.Collections.Generic;

namespace GreenProject.Helpers
{
   public static class IntExtension
   {
      private static Dictionary<int, string> _intToStringCache;

      static IntExtension()
      {
         _intToStringCache = new Dictionary<int, string>(10000);

         for (var i = 0; i <= 1000; i++)
         {
            _intToStringCache[i] = i.ToString();
         }
      }

      public static string ToStringCached(this int i)
      {
         if (!_intToStringCache.ContainsKey(i))
         {
            _intToStringCache.Add(i, i.ToString());
         }

         return _intToStringCache[i];
      }
   }
}