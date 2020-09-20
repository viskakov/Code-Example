using UnityEngine;

namespace GreenProject.Obstacle
{
   [RequireComponent(typeof(Rigidbody))]
   public class MoveObstacle : MonoBehaviour
   {
      [SerializeField] [Range(1f, 20f)] private float _moveSpeedMax;
      [SerializeField] [Range(1f, 20f)] private float _moveSpeedMin;
      [SerializeField] private float _rayDistance = 3f;
      [SerializeField] private LayerMask _layerMask = 1 << 9;
      [SerializeField] private Vector3 _offset = new Vector3(0f, 0.5f, 1.5f);

      private Rigidbody _rigidbody;
      private Transform _transform;
      private Ray _ray;
      private float _moveSpeed;

      public float MoveSpeed => _moveSpeed;

      private void Awake()
      {
         _rigidbody = GetComponent<Rigidbody>();
         _transform = transform;
      }

      private void OnEnable()
      {
         _moveSpeed = Random.Range(_moveSpeedMin, _moveSpeedMax);
      }

#if UNITY_EDITOR
      private void Update()
      {
         Debug.DrawRay(_ray.origin, _ray.direction * _rayDistance, Color.green);
      }
#endif

      private void FixedUpdate()
      {
         _rigidbody.MovePosition(_rigidbody.position + Vector3.forward * (_moveSpeed * Time.deltaTime));

         _ray = new Ray(_transform.position + _transform.TransformVector(_offset), _transform.forward);
         if (Physics.Raycast(_ray, out var hitInfo, _rayDistance, _layerMask, QueryTriggerInteraction.Ignore))
         {
            if (hitInfo.transform.TryGetComponent<MoveObstacle>(out var obstacle))
            {
               _moveSpeed = obstacle.MoveSpeed;
            }
         }
      }
   }
}