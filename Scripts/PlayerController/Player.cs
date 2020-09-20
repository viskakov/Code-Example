using DG.Tweening;
using GreenProject.Managers;
using UnityEngine;

namespace GreenProject.PlayerController
{
   public class Player : MonoBehaviour
   {
      [SerializeField] private Vector3 _shakeStrenght;
      [SerializeField] private float _shakeDuration;
      [SerializeField] private AudioClip[] _audioClips;
      [SerializeField] private MeshRenderer _carMaterial;
      [SerializeField] private float _durationFlash;
      [SerializeField] private float _overshoot;
      [SerializeField] private int _materialIndex;

      private Tween _flashingTween;
      private Tween _shakingTween;
      private bool _isFlashing;
      private bool _isShaking;
      private Camera _mainCamera;
      private Vector3 _startCameraPosition;

      private void Awake()
      {
         _mainCamera = Camera.main;
         if (_mainCamera != null)
         {
            _startCameraPosition = _mainCamera.transform.localPosition;
         }
      }

      private void OnCollisionEnter(Collision other)
      {
         if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
         {
            if (other.relativeVelocity.magnitude >= 1f)
            {
               CameraShake();
               HitFlashing();
               AudioManager.Instance.PlaySound(GetRandomHitAudioEffect());
            }
         }
      }

      private AudioClip GetRandomHitAudioEffect()
      {
         return _audioClips.Length > 0 ? _audioClips[Random.Range(0, _audioClips.Length)] : null;
      }

      private void CameraShake()
      {
         if (!_isShaking)
         {
            _isShaking = true;
            _shakingTween = _mainCamera
               .DOShakePosition(_shakeDuration, _shakeStrenght)
               .SetEase(Ease.OutCubic)
               .OnComplete(RestoreCameraPosition)
               .SetAutoKill(false);
         }
         else
         {
            _shakingTween.Restart();
         }
      }

      private void RestoreCameraPosition()
      {
         _isShaking = false;
         _mainCamera.transform.localPosition = _startCameraPosition;
      }

      private void HitFlashing()
      {
         if (!_isFlashing)
         {
            _isFlashing = true;
            _flashingTween = _carMaterial.materials[_materialIndex]
               .DOColor(Color.red, _durationFlash)
               .SetEase(Ease.InFlash, _overshoot)
               .OnComplete(() => _isFlashing = false)
               .SetAutoKill(false);
         }
         else
         {
            _flashingTween.Restart();
         }
      }
   }
}