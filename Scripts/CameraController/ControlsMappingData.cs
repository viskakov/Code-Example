using UnityEngine;

namespace GreenProject.CameraController
{
   [CreateAssetMenu(fileName = "CameraControls", menuName = "Controls/ControlsMapping", order = 0)]
   public class ControlsMappingData : ScriptableObject
   {
      public KeyCode MoveForwardButton;
      public KeyCode MoveBackwardButton;
      public KeyCode MoveLeftButton;
      public KeyCode MoveRightButton;
      public KeyCode RotationRightButton;
      public KeyCode RotationLeftButton;
      public KeyCode IncreasedSpeedButton;
   }
}