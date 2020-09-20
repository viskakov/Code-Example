using UnityEngine;

namespace GreenProject.Collectibles
{
   public class DestroyByTime : MonoBehaviour
   {
      [SerializeField] private float _lifeTime;

      private void Start()
      {
         Destroy(gameObject, _lifeTime);
      }
   }
}