using DG.Tweening;
using TMPro;
using UnityEngine;

namespace GreenProject.UI
{
   public class TapToPlayUI : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI _tapToPlayLabel;
      [SerializeField] private Ease _easeTypeIn;
      [SerializeField] private Ease _easeTypeOut;
      [SerializeField] private float _duration;

      private void Start()
      {
         if (_tapToPlayLabel)
         {
            _tapToPlayLabel.transform
               .DOScale(_tapToPlayLabel.transform.localScale + new Vector3(0.2f, 0.2f, 0.2f), _duration)
               .SetEase(_easeTypeIn)
               .OnComplete(() => _tapToPlayLabel.transform.DOScale(Vector3.one, _duration))
               .SetEase(_easeTypeOut)
               .SetLoops(-1, LoopType.Yoyo)
               .SetLink(gameObject, LinkBehaviour.PauseOnDisableRestartOnEnable);
         }
      }
   }
}