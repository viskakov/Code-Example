using UnityEngine;

namespace GreenProject.UI.SettingsMenu
{
   public class Settings : MonoBehaviour
   {
      public void SendFeedback()
      {
         OpenURL("mailto:vsev0l0d.vsevolod@gmail.com");
      }

      public void RateThisGame()
      {
         OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
      }

      public void ExitFromGame()
      {
         if (!Application.isEditor)
         {
            Application.Quit();
         }
      }

      private void OpenURL(string url)
      {
         if (!string.IsNullOrEmpty(url))
         {
            Application.OpenURL(url);
         }
      }
   }
}