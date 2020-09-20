using GreenProject.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GreenProject.UI.SettingsMenu
{
   public class SettingsMenuItemUI : MonoBehaviour
   {
      [SerializeField] private Sprite _spriteOn;
      [SerializeField] private Sprite _spriteOff;

      private Button _button;
      private Image _image;
      private bool _isClicked;

      public Image Image => _image;

      private void Awake()
      {
         _image = GetComponent<Image>();
         _button = GetComponent<Button>();
      }

      private void OnEnable()
      {
         if (_button)
         {
            _button.onClick.AddListener(Toggle);
         }
      }

      private void OnDisable()
      {
         if (_button)
         {
            _button.onClick.RemoveListener(Toggle);
         }
      }

      private void Toggle()
      {
         _isClicked = !_isClicked;
         _image.sprite = _isClicked ? _spriteOff : _spriteOn;

         AudioManager.Instance.ControlMusicSource(!_isClicked);
      }
   }
}