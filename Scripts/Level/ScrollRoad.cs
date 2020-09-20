using UnityEngine;

namespace GreenProject.Level
{
   [RequireComponent(typeof(Renderer))]
   public class ScrollRoad : MonoBehaviour
   {
      [SerializeField] private Vector2 _offset;
      [SerializeField] private float _speed;

      private Renderer _renderer;

      private void Awake()
      {
         _renderer = GetComponent<Renderer>();
      }

      private void Update()
      {
         _renderer.material.mainTextureOffset += _offset * (_speed * Time.deltaTime);
      }
   }
}