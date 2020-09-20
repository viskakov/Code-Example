using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GreenProject.Helpers
{
   public class Drag : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler
   {
      private Image _image;
      private Canvas _canvas;

      private void Awake()
      {
         _image = GetComponent<Image>();
         _canvas = transform.parent.GetComponent<Canvas>();
      }

      public void OnDrag(PointerEventData eventData)
      {
         _image.rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
      }

      public void OnPointerDown(PointerEventData eventData)
      {
         _image.rectTransform.SetAsLastSibling();
      }

      public void OnBeginDrag(PointerEventData eventData)
      {
         _image.SetAlpha(0.5f);
      }

      public void OnEndDrag(PointerEventData eventData)
      {
         _image.SetAlpha(1f);
      }
   }
}