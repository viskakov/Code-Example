using DG.Tweening;
using GreenProject.Helpers;
using GreenProject.Interfaces;
using UnityEngine;

namespace GreenProject.Ability
{
   [RequireComponent(typeof(SphereCollider))]
   public class MagnetAbility : MonoBehaviour
   {
      [SerializeField] private float _magnetRadius;
      [SerializeField] private float _magnetSpeed;
      [SerializeField] private float _minimalDistance;

      private SphereCollider _sphereCollider;

      private void Awake()
      {
         _sphereCollider = GetComponent<SphereCollider>();
         _sphereCollider.radius = _magnetRadius;
      }

#if UNITY_EDITOR
      private void OnValidate()
      {
         GetComponent<SphereCollider>().radius = _magnetRadius;
      }
#endif

      private void OnTriggerStay(Collider other)
      {
         if (!other.TryGetComponent<IPickable>(out var item)) return;

         other.transform.position = Vector3.MoveTowards(other.transform.position, transform.position,
            _magnetSpeed * Time.deltaTime);

         if (Vector3.Distance(transform.position, other.transform.position) < _minimalDistance)
         {
            item.PickUp();
            Shaker.ShakePlayer(transform);
         }
      }
   }
}