using UnityEngine;

namespace GreenProject.CameraController
{
   public class MouseZooming : MonoBehaviour
   {
      [SerializeField] private bool _scrollWheelZooming = true;
      [SerializeField] private float _mouseZoomSpeed;
      [SerializeField] private Vector3 _zoomAmount;
      [SerializeField] private float _movementTime;

      private Transform _cameraTransform;
      private Vector3 _newZoom;

      private void Awake()
      {
         _cameraTransform = GetComponentInChildren<Camera>().transform;
         _newZoom = _cameraTransform.localPosition;
      }

      private void Update()
      {
         if (_scrollWheelZooming)
         {
            HandleMouseInput();
         }
      }

      private void HandleMouseInput()
      {
         if (Mathf.Abs(Input.mouseScrollDelta.y) > float.Epsilon)
         {
            _newZoom += _zoomAmount * (Input.mouseScrollDelta.y * _mouseZoomSpeed);
         }
      }

      private void LateUpdate()
      {
         if (_cameraTransform)
         {
            _cameraTransform.localPosition =
               Vector3.Lerp(_cameraTransform.localPosition, _newZoom, _movementTime * Time.deltaTime);
         }
      }
   }
}