using System;
using JetBrains.Annotations;
using UnityEngine;

namespace GreenProject.Managers
{
   public class GameManager : MonoBehaviour
   {
      public static event Action<bool> OnPauseGame;

      [UsedImplicitly]
      public static void PauseGame()
      {
         Time.timeScale = 0f;
         AudioListener.pause = true;
         AudioManager.Instance.FadeMusicAudioMixer(-10f, 0.2f);
         OnPauseGame?.Invoke(true);
      }

      [UsedImplicitly]
      public static void ResumeGame()
      {
         Time.timeScale = 1f;
         AudioListener.pause = false;
         AudioManager.Instance.FadeMusicAudioMixer(5f, 0.2f);
         OnPauseGame?.Invoke(false);
      }
   }
}