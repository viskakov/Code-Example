using UnityEngine;

namespace GreenProject.CameraController
{
   public class CameraController : MonoBehaviour
   {
      [Header("Controls Mapping")] [SerializeField]
      private ControlsMappingData _cameraControls;

      [Header("Movement Speed")] [SerializeField]
      private float _defaultSpeed;

      [SerializeField] private float _fastSpeed;
      [Space(10)] [SerializeField] private float _movementTime;
      [SerializeField] private float _rotationAmount;

      private Transform _transform;
      private Vector3 _newPosition;
      private Quaternion _newRotation;
      private float _movementSpeed;

      private void Awake()
      {
         _transform = transform;
         _newPosition = _transform.position;
         _newRotation = _transform.rotation;
      }

      private void Update()
      {
         HandleMovementInput();
      }

      private void LateUpdate()
      {
         if (!_transform) return;

         _transform.position = Vector3.Lerp(_transform.position, _newPosition, _movementTime * Time.deltaTime);
         _transform.rotation = Quaternion.Lerp(_transform.rotation, _newRotation, _movementTime * Time.deltaTime);
      }

      private void HandleMovementInput()
      {
         if (!_cameraControls) return;

         // Increase camera speed
         _movementSpeed = Input.GetKey(_cameraControls.IncreasedSpeedButton) ? _fastSpeed : _defaultSpeed;

         // Position
         if (Input.GetKey(_cameraControls.MoveForwardButton))
         {
            ChangePosition(transform.forward, _movementSpeed);
         }

         if (Input.GetKey(_cameraControls.MoveBackwardButton))
         {
            ChangePosition(-transform.forward, _movementSpeed);
         }

         if (Input.GetKey(_cameraControls.MoveRightButton))
         {
            ChangePosition(transform.right, _movementSpeed);
         }

         if (Input.GetKey(_cameraControls.MoveLeftButton))
         {
            ChangePosition(-transform.right, _movementSpeed);
         }

         // Rotation
         if (Input.GetKey(_cameraControls.RotationLeftButton))
         {
            ChangeRotation(Vector3.up, _rotationAmount);
         }

         if (Input.GetKey(_cameraControls.RotationRightButton))
         {
            ChangeRotation(Vector3.down, _rotationAmount);
         }
      }

      private void ChangePosition(Vector3 direction, float movementSpeed)
      {
         _newPosition += direction * movementSpeed;
      }

      private void ChangeRotation(Vector3 direction, float rotationAmount)
      {
         _newRotation *= Quaternion.Euler(direction * rotationAmount);
      }
   }
}