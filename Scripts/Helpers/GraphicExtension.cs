using UnityEngine.UI;

namespace GreenProject.Helpers
{
   public static class GraphicExtension
   {
      public static void SetAlpha(this Graphic graphic, float alpha)
      {
         var newColor = graphic.color;
         newColor.a = alpha;
         graphic.color = newColor;
      }
   }
}