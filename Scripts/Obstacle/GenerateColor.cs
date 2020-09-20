using GreenProject.Helpers;
using UnityEngine;

namespace GreenProject.Obstacle
{
   public class GenerateColor : MonoBehaviour
   {
      [SerializeField] private MeshRenderer _renderer;
      [SerializeField] private int _materialIndex = 1;

      private MaterialPropertyBlock _propBlock;

      private void Awake()
      {
         _propBlock = new MaterialPropertyBlock();
      }

      private void OnEnable()
      {
         _renderer.GetPropertyBlock(_propBlock);
         _propBlock.SetColor(ShaderIDs.Color, Random.ColorHSV(0f, 1f, 0.9f, 1f, 0.5f, 1f));
         _renderer.SetPropertyBlock(_propBlock, _materialIndex);
      }
   }
}