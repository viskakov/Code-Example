using UnityEngine;

namespace GreenProject.Helpers
{
   public static class ShaderIDs
   {
      public static readonly int Color = Shader.PropertyToID("_Color");
      public static readonly int UnscaledTime = Shader.PropertyToID("_UNSCALED_TIME");
   }
}