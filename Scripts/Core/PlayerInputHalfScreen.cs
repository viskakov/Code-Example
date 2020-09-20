using UnityEngine;

namespace GreenProject.Core
{
   [RequireComponent(typeof(Rigidbody))]
   public class PlayerInputHalfScreen : MonoBehaviour
   {
      [SerializeField] private float _moveSpeed;

      private Rigidbody _rigidbody;
      private Camera _mainCamera;
      private Transform _transform;
      private Vector3 _moveDirection;
      private float _direction;

      private void Awake()
      {
         _rigidbody = GetComponent<Rigidbody>();
         _mainCamera = Camera.main;
         _transform = transform;
      }

      private void Update()
      {
         if (Input.touchCount > 0)
         {
            var normalizeTouchPosition = _mainCamera.ScreenToViewportPoint(Input.GetTouch(0).position);
            _direction = normalizeTouchPosition.x > 0.5f ? 1f : -1f;
         }
         else
         {
            _direction = 0f;
         }

         _moveDirection = new Vector3(_direction, 0f, 0f).normalized;
         _moveDirection = _transform.TransformDirection(_moveDirection);
      }

      private void FixedUpdate()
      {
         _rigidbody.MovePosition(_rigidbody.position + _moveDirection * (_moveSpeed * Time.deltaTime));
      }
   }
}