using UnityEngine;

namespace GreenProject.Core
{
   [RequireComponent(typeof(Rigidbody))]
   public class PlayerInputSwipe : MonoBehaviour
   {
      [SerializeField] private float _moveSpeed;

      private Rigidbody _rigidbody;
      private Vector3 _direction;

#if UNITY_IOS && !UNITY_EDITOR
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            if (Input.touchCount <= 0) return;
            var touch = Input.GetTouch(0);

            _direction = touch.phase == TouchPhase.Moved
                ? new Vector3(-touch.deltaPosition.x * _moveSpeed, 0f, 0f)
                : Vector3.zero;
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _direction * Time.deltaTime);
        }
#endif
   }
}