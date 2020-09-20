using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

namespace GreenProject.Managers
{
   [RequireComponent(typeof(AudioSource))]
   public class AudioManager : MonoBehaviour
   {
      public static AudioManager Instance { get; private set; }

      [SerializeField] private AudioMixer _audioMixer;

      private AudioSource _audioSource;
      private AudioSource _musicAudioSource;
      private AudioSource _menuAudioSource;

      private void Awake()
      {
         if (Instance)
         {
            Destroy(gameObject);
         }
         else
         {
            Instance = this;
            DontDestroyOnLoad(this);
            Init();
         }
      }

      private void Init()
      {
         _audioSource = GetComponent<AudioSource>();

         _musicAudioSource = transform.GetChild(0).GetComponent<AudioSource>();
         _musicAudioSource.ignoreListenerPause = true;

         _menuAudioSource = transform.GetChild(1).GetComponent<AudioSource>();
         _menuAudioSource.ignoreListenerPause = true;
      }

      public void PlaySound(AudioClip audioClip)
      {
         if (audioClip)
         {
            _audioSource.PlayOneShot(audioClip);
         }
      }

      public void PlayMenuSound(AudioClip audioClip)
      {
         if (audioClip)
         {
            _menuAudioSource.PlayOneShot(audioClip);
         }
      }

      public void FadeMusicAudioMixer(float endValue, float duration)
      {
         if (_audioMixer)
         {
            _audioMixer
               .DOSetFloat("MusicVolume", endValue, duration)
               .SetUpdate(true);
         }
      }

      public void ControlMusicSource(bool state)
      {
         if (_musicAudioSource)
         {
            _musicAudioSource.enabled = state;
         }
      }
   }
}