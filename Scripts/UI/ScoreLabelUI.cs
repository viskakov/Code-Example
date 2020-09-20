using System.Collections;
using DG.Tweening;
using GreenProject.Helpers;
using GreenProject.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GreenProject.UI
{
   public class ScoreLabelUI : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI _scoreLabel;
      [SerializeField] private Ease _easeTypeIn;
      [SerializeField] private Ease _easeTypeOut;
      [SerializeField] private float _scoreUpdateDuration;
      [SerializeField] private float _hideInLabelDuration;
      [SerializeField] private float _hideOutLabelDuration;

      private int _oldValue;

      private void Start()
      {
         var initScore = ScoreManager.Score;
         SetScoreLabel(initScore);
         _oldValue = initScore;
      }

      private void OnEnable()
      {
         ScoreManager.OnScoreChanged += UpdateScore;
         GameManager.OnPauseGame += HideScoreLabel;
      }

      private void OnDisable()
      {
         ScoreManager.OnScoreChanged -= UpdateScore;
         GameManager.OnPauseGame -= HideScoreLabel;
      }

      private void HideScoreLabel(bool onGamePause)
      {
         DoAnchorPos(_scoreLabel.rectTransform,
            onGamePause ? new Vector2(200, -35) : new Vector2(-70, -50),
            onGamePause ? _hideInLabelDuration : _hideOutLabelDuration,
            true,
            Ease.OutQuint);
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

      private void UpdateScore(int value)
      {
         if (_scoreLabel)
         {
            StartCoroutine(LerpValue(_oldValue, value, _scoreUpdateDuration, SetScoreLabel));
            _oldValue = value;
            ScaleScoreLabel();
            ChangeVertexColor();
         }
      }

      private IEnumerator LerpValue(float startValue, float endValue, float duration, UnityAction<float> action)
      {
         var elapsed = 0f;
         while (elapsed < duration)
         {
            var nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            action?.Invoke(nextValue);
            elapsed += Time.deltaTime;
            yield return null;
         }

         action?.Invoke(endValue);
      }

      private void SetScoreLabel(float value)
      {
         var valueInt = (int) value;
         if (_scoreLabel)
         {
            _scoreLabel.text = valueInt.ToStringCached();
         }
      }

      private void ScaleScoreLabel()
      {
         _scoreLabel.transform
            .DOScale(_scoreLabel.transform.localScale + new Vector3(0.2f, 0.2f, 0f), _scoreUpdateDuration)
            .From(Vector3.one)
            .SetEase(_easeTypeIn)
            .OnComplete(() => _scoreLabel.transform.DOScale(Vector3.one, _scoreUpdateDuration))
            .SetEase(_easeTypeOut);
      }

      private void ChangeVertexColor()
      {
         _scoreLabel
            .DOColor(Color.green, _scoreUpdateDuration)
            .SetEase(_easeTypeIn)
            .OnComplete(() => _scoreLabel.DOColor(Color.white, _scoreUpdateDuration))
            .SetEase(_easeTypeOut);
      }
   }
}