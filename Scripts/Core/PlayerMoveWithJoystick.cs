using UnityEngine;

namespace GreenProject.Core
{
   [RequireComponent(typeof(Rigidbody))]
   public class PlayerMoveWithJoystick : MonoBehaviour
   {
      [SerializeField] private FloatingJoystick _floatingJoystick;
      [SerializeField] private float _moveSpeed;
      [SerializeField] private float _rotationAngel;

      private Rigidbody _rigidbody;
      private Transform _transform;
      private Vector3 _moveDirection;
      private Vector3 _moveRotation;
      private Quaternion _deltaRotation;

      private void Awake()
      {
         _rigidbody = GetComponent<Rigidbody>();
         _transform = transform;
      }

      private void Update()
      {
         _moveDirection = new Vector3(_floatingJoystick.Horizontal, 0f, 0f).normalized;
         _moveDirection = _transform.TransformDirection(_moveDirection);
         //_moveRotation = new Vector3(0f, _rightJoystick.Horizontal, 0f);
         //_moveRotation = new Vector3(0f, 0f, _floatingJoystick.Horizontal);
         _deltaRotation = Quaternion.Euler(_moveRotation * (_rotationAngel * Time.deltaTime));
      }

      private void FixedUpdate()
      {
         _rigidbody.MovePosition(_rigidbody.position + _moveDirection * (_moveSpeed * Time.deltaTime));
         _rigidbody.MoveRotation(_rigidbody.rotation * _deltaRotation.normalized);
      }
   }
}