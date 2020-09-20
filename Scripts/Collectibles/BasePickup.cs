using GreenProject.Interfaces;
using GreenProject.Managers;
using UnityEngine;

namespace GreenProject.Collectibles
{
   public abstract class BasePickup : MonoBehaviour, IPickable
   {
      [SerializeField] private int _scoreForPick;
      [SerializeField] private AudioClip[] _audioClips;

      public void PickUp()
      {
         AddScore();
         PlaySound();
         SelfDestroy();
      }

      private void AddScore()
      {
         ScoreManager.AddScore(_scoreForPick);
      }

      private void PlaySound()
      {
         AudioManager.Instance.PlaySound(GetRandomSound());
      }

      private void SelfDestroy()
      {
         Destroy(gameObject);
      }

      private AudioClip GetRandomSound()
      {
         return _audioClips.Length > 0 ? _audioClips[Random.Range(0, _audioClips.Length)] : null;
      }
   }
}