using GreenProject.Helpers;
using GreenProject.Managers;
using UnityEngine;

namespace GreenProject.UI
{
   public class SetUnscaledTime : MonoBehaviour
   {
      private bool isPaused;

      private void OnEnable()
      {
         GameManager.OnPauseGame += OnPausedHandler;
      }

      private void OnDisable()
      {
         GameManager.OnPauseGame -= OnPausedHandler;
      }

      private void OnPausedHandler(bool onGamePause)
      {
         isPaused = onGamePause;
      }

      private void Update()
      {
         if (isPaused)
         {
            Shader.SetGlobalFloat(ShaderIDs.UnscaledTime, Time.unscaledTime);
         }
      }
   }
}