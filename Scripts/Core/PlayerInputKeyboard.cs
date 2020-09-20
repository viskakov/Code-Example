using UnityEngine;

namespace GreenProject.Core
{
   [RequireComponent(typeof(Rigidbody))]
   public class PlayerInputKeyboard : MonoBehaviour
   {
      [SerializeField] private float _moveSpeed;

      private Rigidbody _rigidbody;
      private Vector3 _direction;

#if UNITY_EDITOR || !UNITY_IOS
      private void Awake()
      {
         _rigidbody = GetComponent<Rigidbody>();
      }

      private void Update()
      {
         _direction = new Vector3(-Input.GetAxisRaw("Horizontal"), 0f, 0f);
      }

      private void FixedUpdate()
      {
         _rigidbody.MovePosition(_rigidbody.position + _direction * (_moveSpeed * Time.deltaTime));
      }
#endif
   }
}