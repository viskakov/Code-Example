using System;
using UnityEngine;

namespace GreenProject.Managers
{
   public class ScoreManager : MonoBehaviour
   {
      public static event Action<int> OnScoreChanged;
      public static int Score => _score;

      private const string SCORE_KEY = "ScoreKey";
      private static int _score;

      private void Awake()
      {
         LoadScore();
      }

      public static void AddScore(int value)
      {
         _score += value;
         OnScoreChanged?.Invoke(_score);
      }

      private static void LoadScore()
      {
         if (PlayerPrefs.HasKey(SCORE_KEY))
         {
            _score = PlayerPrefs.GetInt(SCORE_KEY);
         }
      }

      private static void SaveScore()
      {
         PlayerPrefs.SetInt(SCORE_KEY, _score);
         PlayerPrefs.Save();
      }

      private void OnApplicationPause(bool pauseStatus)
      {
         if (pauseStatus)
         {
            SaveScore();
         }
      }
   }
}