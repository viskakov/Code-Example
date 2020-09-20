using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GreenProject.UI.SettingsMenu
{
   public class SettingsMenuUI : MonoBehaviour
   {
      [SerializeField] private Button _mainButton;
      [SerializeField] private Vector2 _spacingBetweenItems;

      [Header("UI Effects Settings")] [SerializeField]
      private float _rotationDuration;

      [SerializeField] private Ease _rotationEaseType;
      [SerializeField] private float _expandDuration;
      [SerializeField] private Ease _expandEaseType;
      [SerializeField] private float _collapseDuration;
      [SerializeField] private Ease _collapseEaseType;
      [SerializeField] private float _fadeDuration;
      [SerializeField] private Ease _fadeEaseType;

      private Vector2 _mainButtonPosition;
      [SerializeField] private SettingsMenuItemUI[] _menuItems;
      [SerializeField] private int _itemsCount;
      private bool _isExpanded;

      private void Awake()
      {
         _mainButton = transform.GetChild(0).GetComponent<Button>();
         _mainButton.transform.SetAsLastSibling();
         _mainButtonPosition = _mainButton.transform.position;
      }

      private void Start()
      {
         _itemsCount = transform.childCount - 1;
         _menuItems = new SettingsMenuItemUI[_itemsCount];

         for (int i = 0; i < _itemsCount; i++)
         {
            _menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItemUI>();
         }

         ResetItemsPosition();
      }

      private void ResetItemsPosition()
      {
         for (int i = 0; i < _menuItems.Length; i++)
         {
            _menuItems[i].transform.position = _mainButtonPosition;
         }
      }

      private void OnEnable()
      {
         _mainButton.onClick.AddListener(ToggleMenu);
         _mainButton.onClick.AddListener(RotateMenu);
      }

      private void OnDisable()
      {
         _mainButton.onClick.RemoveListener(ToggleMenu);
         _mainButton.onClick.RemoveListener(RotateMenu);
      }

      private void ToggleMenu()
      {
         _isExpanded = !_isExpanded;
         if (_isExpanded)
         {
            for (int i = 0; i < _itemsCount; i++)
            {
               _menuItems[i].transform
                  .DOMove(_mainButtonPosition + _spacingBetweenItems * (i + 1), _expandDuration)
                  .SetEase(_expandEaseType);

               _menuItems[i].Image
                  .DOFade(1f, _fadeDuration)
                  .From(0f)
                  .SetEase(_fadeEaseType);
            }
         }
         else
         {
            for (int i = 0; i < _itemsCount; i++)
            {
               _menuItems[i].transform
                  .DOMove(_mainButtonPosition, _collapseDuration)
                  .SetEase(_collapseEaseType);

               _menuItems[i].Image
                  .DOFade(0f, _fadeDuration)
                  .SetEase(_fadeEaseType);
            }
         }
      }

      private void RotateMenu()
      {
         if (_mainButton)
         {
            if (_isExpanded)
            {
               _mainButton.transform
                  .DORotate(Vector3.back * 180f, _rotationDuration)
                  .From(Vector3.zero)
                  .SetEase(_rotationEaseType);
            }
            else
            {
               _mainButton.transform
                  .DORotate(Vector3.zero, _rotationDuration)
                  .From(new Vector3(0f, 0f, -180f))
                  .SetEase(_rotationEaseType);
            }
         }
      }
   }
}