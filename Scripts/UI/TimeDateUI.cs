using System;
using TMPro;
using UnityEngine;

namespace GreenProject.UI
{
   public class TimeDateUI : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI _label;

      private void Update()
      {
         var dateTime = DateTime.Now;
         _label.SetText($"{dateTime.Hour:D2}:{dateTime.Minute:D2}:{dateTime.Second:D2}");
      }
   }
}