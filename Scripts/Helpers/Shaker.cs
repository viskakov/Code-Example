using DG.Tweening;
using UnityEngine;

namespace GreenProject.Helpers
{
   public static class Shaker
   {
      public static void ShakePlayer(Transform playerTransform)
      {
         playerTransform.parent
            .DOShakeScale(0.3f, 0.5f, 1, 0f)
            .OnComplete(() => playerTransform.parent
               .DOScale(Vector3.one, 0.2f)
               .SetEase(Ease.OutQuad));
      }
   }
}