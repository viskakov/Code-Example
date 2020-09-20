using DG.Tweening;
using UnityEngine;

namespace GreenProject.Setup
{
   public class SetTweener : MonoBehaviour
   {
      private void Awake()
      {
         DOTween
            .Init(true, true, LogBehaviour.ErrorsOnly)
            .SetCapacity(50, 5);
      }
   }
}