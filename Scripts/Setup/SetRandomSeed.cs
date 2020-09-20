using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GreenProject.Setup
{
   public class SetRandomSeed : MonoBehaviour
   {
      [SerializeField] private int _randomSeed;

      private void Awake()
      {
         _randomSeed = Environment.TickCount & int.MaxValue;
         Random.InitState(_randomSeed);
      }
   }
}