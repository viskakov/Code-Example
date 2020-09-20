using DG.Tweening;
using GreenProject.Managers;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace GreenProject.UI
{
   public class PauseMenuUI : MonoBehaviour
   {
      [SerializeField] private RectTransform _parentPauseButton;
      [SerializeField] private GameObject _pauseMenu;
      [SerializeField] private GameObject _panel;
      [SerializeField] private CanvasGroup _mainPanelCanvasGroup;
      [SerializeField] private Image _backgroundImage;
      [SerializeField] private float _openDuration;
      [SerializeField] private float _closeDuration;
      [SerializeField] private Ease _easeTypeOpen;
      [SerializeField] private Ease _easeTypeClose;
      [SerializeField] private AudioClip _audioClip;
      [SerializeField] private float _hideInButtonDuration;
      [SerializeField] private float _hideOutButtonDuration;
      
      private void Awake()
      {
         if (_pauseMenu && _pauseMenu.activeSelf)
         {
            _pauseMenu.SetActive(false);
         }
      }

      private void OnEnable()
      {
         GameManager.OnPauseGame += OpenWindow;
         GameManager.OnPauseGame += CloseWindow;
         GameManager.OnPauseGame += PauseButtonChangeState;
      }

      private void OnDisable()
      {
         GameManager.OnPauseGame -= OpenWindow;
         GameManager.OnPauseGame -= CloseWindow;
         GameManager.OnPauseGame -= PauseButtonChangeState;
      }

      [UsedImplicitly]
      public void PlaySound()
      {
         AudioManager.Instance.PlayMenuSound(_audioClip);
      }

      private void PauseButtonChangeState(bool onGamePause)
      {
         DoAnchorPos(_parentPauseButton,
            onGamePause ? new Vector2(-96, 0) : new Vector2(15, -15),
            onGamePause ? _hideInButtonDuration : _hideOutButtonDuration,
            true,
            Ease.OutQuint);
      }

      private void OpenEffect()
      {
         DoScale(Vector3.one, _openDuration, _easeTypeOpen, Vector3.zero);
         DoFade(1f, 0.4f, 0f);

         // FadeIn background from zero to 0.7
         if (_backgroundImage)
         {
            _backgroundImage
               .DOFade(0.7f, _openDuration)
               .From(0f)
               .SetUpdate(true);
         }
      }

      private void CloseEffect()
      {
         DoScale(Vector3.zero, _closeDuration, _easeTypeClose, Vector3.one);
         DoFade(0f, 0.2f, 1f);

         // FadeOut background from 0.7 to zero
         if (_backgroundImage)
         {
            _backgroundImage
               .DOFade(0f, _closeDuration)
               .From(_backgroundImage.color.a)
               .OnComplete(DisablePauseMenu)
               .SetUpdate(true);
         }
      }

      private void DoScale(Vector3 endValue, float duration, Ease easeType, Vector3 fromValue)
      {
         if (_panel)
         {
            _panel.transform
               .DOScale(endValue, duration)
               .SetEase(easeType)
               .From(fromValue)
               .SetUpdate(true);
         }
      }

      private void DoFade(float endValue, float duration, float fromValue)
      {
         if (_mainPanelCanvasGroup)
         {
            _mainPanelCanvasGroup
               .DOFade(endValue, duration)
               .From(fromValue)
               .SetUpdate(true);
         }
      }

      private void DoAnchorPos(RectTransform rectTransform, Vector2 endValue, float duration, bool isSnapping,
         Ease easeType)
      {
         if (rectTransform)
         {
            rectTransform
               .DOAnchorPos(endValue, duration, isSnapping)
               .SetEase(easeType)
               .SetUpdate(true);
         }
      }

      private void OpenWindow(bool onGamePause)
      {
         if (onGamePause)
         {
            _pauseMenu.SetActive(true);
            OpenEffect();
         }
      }

      private void CloseWindow(bool onGamePause)
      {
         if (!onGamePause)
         {
            CloseEffect();
         }
      }

      private void DisablePauseMenu()
      {
         _pauseMenu.SetActive(false);
      }
   }
}