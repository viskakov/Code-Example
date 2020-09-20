using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GreenProject.UI
{
   public class FadeOutUI : MonoBehaviour
   {
      [SerializeField] private Image _fadeImage;
      [SerializeField] private float _fadeDuration;

      private void Awake()
      {
         if (_fadeImage)
         {
            _fadeImage.color = Color.black;
         }
      }

      private void Start()
      {
         _fadeImage.DOFade(0f, _fadeDuration);
      }
   }
}