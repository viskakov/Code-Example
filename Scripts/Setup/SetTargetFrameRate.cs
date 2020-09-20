﻿using UnityEngine;

namespace GreenProject.Setup
{
   public class SetTargetFrameRate : MonoBehaviour
   {
      [SerializeField] private int _targetFrameRate;

      private void Awake()
      {
         Application.targetFrameRate = _targetFrameRate;
      }
   }
}