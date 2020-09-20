using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GreenProject.UI
{
   public class ButtonScaleUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
   {
      [SerializeField] private Vector3 _targetScale;
      [SerializeField] private float _scaleDuration;
      [SerializeField] private Ease _easeType;

      public void OnPointerDown(PointerEventData eventData)
      {
         ScaleButton(_targetScale, _scaleDuration, _easeType);
      }

      public void OnPointerUp(PointerEventData eventData)
      {
         ScaleButton(Vector3.one, _scaleDuration, _easeType);
      }

      private void ScaleButton(Vector3 target, float duration, Ease easeType)
      {
         transform
            .DOScale(target, duration)
            .SetEase(easeType)
            .SetUpdate(true);
      }
   }
}